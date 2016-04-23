﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Octokit;
using JiraCE;
using Atlassian.Jira;
using DbVersionLibrary;
using System.IO;
using System.Diagnostics;
using GitHubCE.Properties;
using Newtonsoft.Json;

namespace GitHubCE
{
    public partial class GitHubHelper : Form
    {
        #region DllImports
        [DllImport("user32.dll")]
        static extern bool FlashWindow(IntPtr hwnd, bool bInvert);
        #endregion

        #region Fields      
        private bool _messageBoxIsDisplayed = false;
        GitHubCommit _commit = null;
        Dictionary<string, GitHubRepo> Repos = new Dictionary<string, GitHubRepo>();
        IList<string> _repoNames;
        #endregion

        #region Properties
        private GitHubClient _client = null;
        public GitHubClient Client
        {
            get
            {
                if (null == _client)
                {
                    _client = new GitHubClient(new ProductHeaderValue("CE.GitHub.Helper"));
                    _client.Credentials = new Credentials(Settings.Default.GitHubUserName, Settings.Default.GitHubToken);
                }
                return _client;
            }
        }

        private IList<PullRequestView> _pullRequests = new List<PullRequestView>();
        public IList<PullRequestView> PullRequests
        {
            get
            {
                return _pullRequests;
            }
        }

        BranchVersionHelper _branchHelper;
        public BranchVersionHelper BranchHelper
        {
            get
            {
                if (null == _branchHelper)
                    _branchHelper = new BranchVersionHelper();

                return _branchHelper;
            }
        }

        JiraIssueHelper _jiraHelper;
        public JiraIssueHelper JiraHelper
        {
            get
            {
                if (null == _jiraHelper)
                    _jiraHelper = new JiraIssueHelper(Settings.Default.JiraUrl, Settings.Default.JiraUserName, Settings.Default.JiraUserPassword);

                return _jiraHelper;
            }
        }
        #endregion

        #region ctor/Load
        public GitHubHelper()
        {
            InitializeComponent();
        }
        private void GitHubHelper_Load(object sender, EventArgs e)
        {
            LoadRepoNamesList();
        }
        #endregion

        #region Get Pull Requests
        void GetAllRequests()
        {
            RefreshRequests(null);
        }

        void GetClosedRequests()
        {
            RefreshRequests(ItemState.Closed);
        }

        void GetOpenRequests()
        {
            RefreshRequests(ItemState.Open);
        }
        #endregion

        #region Display Pull Requests / Details
        private void ClearRequests()
        {
            PullRequests.Clear();
            lvPullRequests.Items.Clear();
        }
        private void ClearRequestDetails()
        {
            // clear the last selected request details
            lstFiles.Items.Clear();
            lstAssemblies.Items.Clear();
            txtCommitMessage.Clear();
            lnkPullRequest.Text = "";
            txtComments.Clear();
        }
        private void RequestSelected()
        {
            try
            {
                tsbJIRAIssue.Enabled = (lvPullRequests.SelectedItems.Count > 0);
                tsbGitHubIssue.Enabled = (lvPullRequests.SelectedItems.Count > 0);

                if (lvPullRequests.SelectedItems.Count > 0)
                {
                    DisplaySelectedPullRequestDetails();
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        void DisplayPullRequests(IList<PullRequestView> requests)
        {
            foreach (var request in requests.OrderBy(r => r.Updated))
            {
                if (request.State == ItemState.Open && Settings.Default.ShowOpenRequests || request.State != ItemState.Open && Settings.Default.ShowClosedRequests)
                {
                    ListViewItem match = null;
                    foreach (ListViewItem lvi in lvPullRequests.Items)
                    {
                        if (((PullRequestView)lvi.Tag).Id == request.Id)
                        {
                            match = lvi;
                            break;
                        }
                    }
                    if (null == match)
                    {
                        // add a new item.
                        var lvi = new ListViewItem(new string[] {
                    request.Id.ToString(),
                    request.Repo,
                    request.Updated.ToString(),
                    request.Title,
                    request.JiraIssueNumber,
                    request.Branch,
                    request.Version.ToString(),
                    request.HasDbUpgrade ? "** YES **":"",
                    request.State.ToString(),
                    request.Developer,
                    request.JiraIssueStatus});

                        lvi.UseItemStyleForSubItems = true;

                        if (request.HasBuildScriptChange)
                        {
                            lvi.BackColor = Color.DarkRed;
                            lvi.ForeColor = Color.LightCyan;
                            lblWarning.Text = "BUILD.PS1 SCRIPT CHANGE!!!";
                            lblWarning.BackColor = Color.Red;
                        }
                        else if (request.State == ItemState.Closed)
                        {
                            lvi.ForeColor = Color.DimGray;
                        }
                        else
                        {
                            if (request.Branch == "develop")
                            {
                                lvi.ForeColor = Color.Blue;
                            }

                            if (request.HasDbUpgrade)
                            {
                                lvi.ForeColor = Color.Red;
                            }
                        }

                        lvi.Tag = request;

                        lvPullRequests.Items.Add(lvi);
                    }
                    else
                    {
                        // update existing item.
                        match.SubItems.Clear();
                        match.Text = request.Id.ToString();
                        match.SubItems.AddRange(new string[] {
                        request.Repo,
                        request.Updated.ToString(),
                        request.Title,
                        request.JiraIssueNumber,
                        request.Branch,
                        request.Version.ToString(),
                        request.HasDbUpgrade ? "** YES **":"",
                        request.State.ToString(),
                        request.Developer,
                        request.JiraIssueStatus});

                        match.UseItemStyleForSubItems = true;
                        if (request.State == ItemState.Closed)
                        {
                            match.ForeColor = Color.DimGray;
                        }
                        else
                        {
                            if (request.Branch == "develop")
                            {
                                match.ForeColor = Color.Blue;
                            }

                            if (request.HasDbUpgrade)
                            {
                                match.ForeColor = Color.Red;
                            }
                        }

                        match.Tag = request;
                    }
                }
            }
        }

        async Task DisplaySelectedPullRequestDetails()
        {
            try
            {
                if (lvPullRequests.SelectedItems.Count == 0)
                    return;

                ClearRequestDetails();

                PullRequestView requestView = (PullRequestView)lvPullRequests.SelectedItems[0].Tag;
                var request = (Octokit.Issue)requestView.Tag;
                //if (request.State == ItemState.Open && Settings.Default.ShowOpenRequests || request.State != ItemState.Open && Settings.Default.ShowClosedRequests)
                //{

                var updatedPullRequest = await Client.Repository.PullRequest.Get(Settings.Default.GitHubRepoOwner, requestView.Repo, request.Number);
                if (null != updatedPullRequest)
                {
                    if (null != updatedPullRequest.Head)
                    {
                        var result = GetAndDisplayCommit(updatedPullRequest.Head.Sha, request.Number, requestView);
                    }
                }
                // }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        async Task GetAndDisplayCommit(string commitReferenceSHA, int requestNumber, PullRequestView request)
        {
            _commit = await Client.Repository.Commit.Get(Settings.Default.GitHubRepoOwner, request.Repo, commitReferenceSHA);

            //*** MESSAGE ***//

            var message = _commit.Commit.Message.Replace("\n", "\r\n");
            txtCommitMessage.Text = message;
            if (message.Contains(Environment.NewLine))
            {
                lnkPullRequest.Text = message.Substring(0, message.IndexOf(Environment.NewLine) - 1);
            }
            else
            {
                lnkPullRequest.Text = message;
            }

            //*** FILES ***//            
            foreach (var commitFileName in _commit.Files.Select(f => f.Filename).Distinct().ToList().OrderBy(f => f))
            {
                lstFiles.Items.Add(commitFileName);
            }

            //*** ASSEMBLIES ***//

            var patch = new PatchBuilder(request);
            request.AssembliesChanged = patch.Assemblies;
            foreach (var assemblyName in patch.Assemblies)
            {
                lstAssemblies.Items.Add(assemblyName);
            }


            //*** COMMENTS ***//

            // 3 types of comments: issue, pull request, and commit
            StringBuilder sb = new StringBuilder();

            //var commitComments = await _client.PullRequest.Comment.GetAll(_owner, _reponame, requestNumber);            
            //foreach (var comment in commitComments)
            //{
            //    sb.AppendFormat("{0} {1}:\r\n{2}\r\n", comment.CreatedAt, comment.User.Login, comment.Body);
            //    sb.AppendLine("--------------------------\r\n\r\n");
            //}
            //txtComments.AppendText(sb.ToString());

            //var issueComments = await _client.PullRequest.Comment.GetAll(_owner, _reponame, requestNumber);            
            //foreach (var comment in issueComments)
            //{
            //    sb.AppendFormat("{0} {1}:\r\n{2}\r\n", comment.CreatedAt, comment.User.Login, comment.Body);
            //    sb.AppendLine("--------------------------\r\n\r\n");
            //}
            //txtComments.AppendText(sb.ToString());

            var pullRequestComments = await Client.PullRequest.Comment.GetAll(Settings.Default.GitHubRepoOwner, request.Repo, requestNumber);
            sb = new StringBuilder();
            foreach (PullRequestReviewComment comment in pullRequestComments)
            {
                sb.AppendFormat("{0} {1}:\r\n{2}\r\n", comment.CreatedAt, comment.User.Login, comment.Body);
                sb.AppendLine("--------------------------\r\n\r\n");
            }
            txtComments.AppendText(sb.ToString());
        }
        #endregion

        #region External Links
        // JIRA issue link format https://centeredge.atlassian.net/browse/ADVANTAGE-6311
        private string GetJIRAIssueLink(string jiraIssue)
        {
            return string.Format(@"https://centeredge.atlassian.net/browse/ADVANTAGE-{0}", jiraIssue);
        }

        // GitHub issue link format https://github.com/CenterEdge/Advantage/pull/3831
        private string GetGitHubIssueLink(int gitHubIssue)
        {
            return string.Format(@"https://github.com/CenterEdge/Advantage/pull/{0}", gitHubIssue);
        }

        private void OpenPullRequests()
        {
            string url = @"https://github.com/CenterEdge/Advantage/pulls?utf8=%E2%9C%93&q=is%3Apr+is%3Aopen";
            System.Diagnostics.Process.Start(url);
        }

        // Advantage Board link https://centeredge.atlassian.net/secure/RapidBoard.jspa?rapidView=3&useStoredSettings=true

        private string GetAdvantageBoardLink()
        {
            return "https://centeredge.atlassian.net/secure/RapidBoard.jspa?rapidView=3&useStoredSettings=true";
        }

        // Bamboo Link https://centeredge.atlassian.net/builds/allPlans.action
        private string GetBambooLink()
        {
            return "https://centeredge.atlassian.net/builds/allPlans.action";
        }

        private void OpenAdvantageBoard()
        {
            string url = GetAdvantageBoardLink();
            System.Diagnostics.Process.Start(url);
        }

        private void OpenBamboo()
        {
            string url = GetBambooLink();
            System.Diagnostics.Process.Start(url);
        }

        private void OpenJIRAIssue()
        {
            try
            {
                if (lvPullRequests.SelectedItems.Count == 0)
                    return;
                PullRequestView requestView = (PullRequestView)lvPullRequests.SelectedItems[0].Tag;
                var request = (Octokit.Issue)requestView.Tag;
                string url = GetJIRAIssueLink(requestView.JiraIssueNumber);
                System.Diagnostics.Process.Start(url);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void OpenGitHubIssue()
        {
            try
            {
                if (lvPullRequests.SelectedItems.Count == 0)
                    return;
                PullRequestView requestView = (PullRequestView)lvPullRequests.SelectedItems[0].Tag;
                var request = (Octokit.Issue)requestView.Tag;
                string url = GetGitHubIssueLink(requestView.Id);
                System.Diagnostics.Process.Start(url);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void OpenGitHubCommit(string url)
        {
            System.Diagnostics.Process.Start(url);
        }
        #endregion

        #region Timer methods
        private void ToggleTimerState()
        {
            try
            {
                if (timer1.Enabled)
                {
                    timer1.Stop();
                    tsbTimer.Text = "Start Timer";
                }
                else
                {
                    if (Settings.Default.ShowClosedRequests && Settings.Default.ShowOpenRequests)
                    {
                        GetAllRequests();
                    }
                    else if (Settings.Default.ShowOpenRequests)
                    {
                        GetOpenRequests();
                    }
                    else if (Settings.Default.ShowClosedRequests)
                    {
                        GetClosedRequests();
                    }

                    timer1.Start();
                    tsbTimer.Text = "Stop Timer";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        private void TimerFired()
        {
            ReloadRequests();
        }
        private void ReloadRequests()
        {
            try
            {
                timer1.Enabled = false;
                RefreshRequests(null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                timer1.Enabled = true;
            }
        }
        #endregion

        #region Control event handlers

        #region ListView Events
        private void lvPullRequests_SelectedIndexChanged(object sender, EventArgs e)
        {
            RequestSelected();
        }
        private void lvPullRequests_DoubleClick(object sender, EventArgs e)
        {
            lvPullRequests.BackColor = Color.Linen;
        }
        #endregion

        #region Timer
        private void timer1_Tick(object sender, EventArgs e)
        {
            TimerFired();
        }
        #endregion

        #region LinkLabel event handlers
        private void lnkPullRequest_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (null == _commit) return;
            OpenGitHubCommit(_commit.HtmlUrl);
        }
        #endregion

        #region NotifyIcon event handlers
        private void notNewRequest_DoubleClick(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
                this.WindowState = FormWindowState.Normal;
            this.Activate();
        }
        private void notNewRequest_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
                this.WindowState = FormWindowState.Normal;
            this.Activate();
        }
        #endregion

        #region Toolstrip Menu Items
        private void tsmShow_Click(object sender, EventArgs e)
        {
            this.Activate();
        }
        private void tsmClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void tsmClear_Click(object sender, EventArgs e)
        {
            // does this automatically
        }
        #endregion

        #region Toolbar Button Items
        private void tsbTimer_Click(object sender, EventArgs e)
        {
            ToggleTimerState();
        }
        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            GetOpenRequests();
        }
        private void tsbAllToday_Click(object sender, EventArgs e)
        {
            GetClosedRequests();
        }
        private void tsbAll_Click(object sender, EventArgs e)
        {
            GetAllRequests();
        }
        private void tsbJIRAIssue_Click(object sender, EventArgs e)
        {
            OpenJIRAIssue();
        }
        private void tsbGitHubIssue_Click(object sender, EventArgs e)
        {
            OpenGitHubIssue();
        }
        private void tsbAdvantage_Click(object sender, EventArgs e)
        {
            OpenAdvantageBoard();
        }
        private void tsbBamboo_Click(object sender, EventArgs e)
        {
            OpenBamboo();
        }
        private void tsbPullRequests_Click(object sender, EventArgs e)
        {
            OpenPullRequests();
        }
        private void tsbOpenBinFolder_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\Users\rroberts\Source\Repos\Advantage\bin");
        }
        private void tsbOpenPatchFolder_Click(object sender, EventArgs e)
        {
            Process.Start(@"\\ceserver\Development\Test Program Setups\Advantage");
        }
        private void btnDevReportsFolder_Click(object sender, EventArgs e)
        {
            Process.Start(@"\\ceserver\Development\Development Reports");
        }
        private void btnClearGrid_Click(object sender, EventArgs e)
        {
            ClearRequests();
        }
        private void tsbOptions_Click(object sender, EventArgs e)
        {
            try
            {
                var settings = new SettingsDialog();

                if (settings.ShowDialog() == DialogResult.OK)
                {
                    // clear the repos so they use the new settings.
                    Repos.Clear();
                    // reload the list of repos.
                    LoadRepoNamesList();
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        private void tsbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
        #endregion

        #region Form State
        private void SetFormStateBusy()
        {
            lblLastUpdate.Text = "Reading requests...";
        }

        private void SetFormStateIdle(DateTime lastUpdate)
        {
            lblLastUpdate.Text = String.Format("Last Update: {0}", lastUpdate.ToString());
            lblAppStatus.Text = "";
        }

        #endregion

        #region Common
        void LoadRepoNamesList()
        {
            _repoNames = JsonConvert.DeserializeObject<List<string>>(Settings.Default.ActiveRepoList);
        }
        void NotifyNewPullRequest()
        {
            FlashWindow(this.Handle, true);
        }

        private void ExceptionHandler(Exception ex)
        {
            if (!_messageBoxIsDisplayed)
            {
                _messageBoxIsDisplayed = true;
                MessageBox.Show(ex.Message);
                _messageBoxIsDisplayed = false;
            }

            Console.WriteLine(ex.ToString());
            try
            {
                Log(ex.ToString());
            }
            catch { }
        }

        private void Log(string message)
        {
            using (StreamWriter w = File.AppendText("GitHubCELog.txt"))
            {
                Log(message, w);
            }
        }
        public static void Log(string logMessage, TextWriter w)
        {
            w.Write("\r\nLog Entry : ");
            w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                DateTime.Now.ToLongDateString());
            w.WriteLine("  :");
            w.WriteLine("  :{0}", logMessage);
            w.WriteLine("-------------------------------");
        }

        public static void DumpLog()
        {
            using (StreamReader r = File.OpenText("GitHubCELog.txt"))
            {
                DumpLog(r);
            }
        }
        public static void DumpLog(StreamReader r)
        {
            string line;
            while ((line = r.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }
        #endregion

        #region GitHubRepo   
        private void RefreshRequests(ItemState? state)
        {
            try
            {
                SetFormStateBusy();

                foreach (string repoName in _repoNames)
                {
                    lblAppStatus.Text = "Polling " + repoName;
                    GetRepo(repoName).GetRequests(state);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        GitHubRepo GetRepo(string repoName)
        {
            GitHubRepo repo = null;
            if (Repos.ContainsKey(repoName))
            {
                repo = Repos[repoName];
            }
            else
            {

                repo = new GitHubRepo(Settings.Default.GitHubRepoOwner, Settings.Default.GitHubUserName, Settings.Default.GitHubToken, repoName);
                repo.NewPullRequests += CustReports_NewPullRequests;
                repo.GetPullRequestsComplete += CustReports_GetPullRequestComplete;
                Repos.Add(repoName, repo);
            }
            return repo;
        }
        private void CustReports_NewPullRequests(object sender, EventArgs e)
        {
            try
            {
                NotifyNewPullRequest();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        private void CustReports_GetPullRequestComplete(object sender, EventArgs e)
        {
            try
            {
                GitHubRepo repo = (GitHubRepo)sender;
                lblAppStatus.Text = "Updating " + repo.RepoName;
                DisplayPullRequests(repo.PullRequests);
                SetFormStateIdle(DateTime.Now);
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        #endregion

        #region menu items
        private void showOpenRequestsToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.ShowOpenRequests = showOpenRequestsToolStripMenuItem.Checked;
            Settings.Default.Save();
            ClearRequests();
            ClearRequestDetails();
            ReloadRequests();
        }

        private void showClosedRequestsToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.ShowClosedRequests = showClosedRequestsToolStripMenuItem.Checked;
            Settings.Default.Save();
            ClearRequests();
            ClearRequestDetails();
            ReloadRequests();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion


    }
}
