using System;
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
using DbVersionLibrary;
using System.IO;
using System.Diagnostics;
using GitHubCE.Properties;
using Newtonsoft.Json;
using System.Collections;
using GitHubCE.Advantage;
using System.Management.Automation;
using System.Collections.ObjectModel;
using System.Threading;
using System.Management.Automation.Runspaces;
using GitHubCE.Forms;
using CEScriptRunner;

namespace GitHubCE
{
    public partial class GitHubHelper : Form
    {
        delegate void UpdateDisplayCallback(IList<PullRequestView> pullRequests);
        delegate void UpdateFormStateCallback(DateTime timestamp);

        #region DllImports
        [DllImport("user32.dll")]
        static extern bool FlashWindow(IntPtr hwnd, bool bInvert);
        #endregion

        #region Fields      
        private bool _messageBoxIsDisplayed = false;
        GitHubCommit _commit = null;
        Dictionary<string, GitHubRepo> Repos = new Dictionary<string, GitHubRepo>();
        IList<string> _repoNames;
        bool _formLoading = true;
        ListViewColumnSorter lvwColumnSorter;
        GitHubRepo _gitHubRepoHelper = null;
        int _daysBack = 0;
        PSScriptRunner psRunner;
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


            // Create an instance of a ListView column sorter and assign it 
            // to the ListView control.
            lvwColumnSorter = new ListViewColumnSorter();
            this.lvPullRequests.ListViewItemSorter = lvwColumnSorter;
        }
        private void GitHubHelper_Load(object sender, EventArgs e)
        {
            psRunner = new PSScriptRunner(scriptOutputDisplay1, "{dir}>", @"C:\users\rroberts\source\repos\advantage");
            psRunner.ScriptComplete += PsRunner_ScriptComplete;
            psRunner.RequestComplete += PsRunner_RequestComplete;
            LoadOptions();
            _formLoading = false;
            psRunner.AddBlankLine();
        }

        private void PsRunner_RequestComplete(object sender, string data)
        {
            if (!cmbBranches.Items.Contains(data))
                cmbBranches.Items.Add(data);
            cmbBranches.SelectedItem = data;
        }

        void LoadOptions()
        {
            cboDaysBack.SelectedIndex = 0;
            showOpenRequestsToolStripMenuItem.Checked = Settings.Default.ShowOpenRequests;
            showClosedRequestsToolStripMenuItem.Checked = Settings.Default.ShowClosedRequests;
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

        void SafeDisplayPullRequests(IList<PullRequestView> requests)
        {
            UpdateDisplayCallback cb = new UpdateDisplayCallback(DisplayPullRequests);
            this.Invoke(cb, new object[] { requests });
        }
        void DisplayPullRequests(IList<PullRequestView> requests)
        {
            if (this.lvPullRequests.InvokeRequired)
            {
                UpdateDisplayCallback cb = new UpdateDisplayCallback(DisplayPullRequests);
                this.Invoke(cb, new object[] { requests });
            }

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
                            request.RepoName,
                            request.Updated.ToLocalTime().ToString(),
                            request.Title,
                            request.JiraIssueKeyList, // request.JiraIssueNumber,
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
                            lblWarning.Text = request.JiraIssueNumber.ToUpper() +  " HAS BUILD.PS1 SCRIPT CHANGE!!!";
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
                        request.RepoName,
                        request.Updated.ToLocalTime().ToString(),
                        request.Title,
                        request.JiraIssueKeyList, // request.JiraIssueNumber,
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

                var updatedPullRequest = await Client.Repository.PullRequest.Get(Settings.Default.GitHubRepoOwner, requestView.RepoName, request.Number);
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
            _commit = await Client.Repository.Commit.Get(Settings.Default.GitHubRepoOwner, request.RepoName, commitReferenceSHA);

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

            var advantagePatchBuilder = new PullRequestAssembyHelper(request, "rroberts");
            request.AssembliesChanged = advantagePatchBuilder.AssemblyFiles;
            foreach (var assemblyName in request.AssembliesChanged)
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

            //var pullRequestComments = await Client.PullRequest.Comment.GetAll(Settings.Default.GitHubRepoOwner, request.RepoName, requestNumber);
            //sb = new StringBuilder();
            //foreach (PullRequestReviewComment comment in pullRequestComments)
            //{
            //    sb.AppendFormat("{0} {1}:\r\n{2}\r\n", comment.CreatedAt, comment.User.Login, comment.Body);
            //    sb.AppendLine("--------------------------\r\n\r\n");
            //}
            //txtComments.AppendText(sb.ToString());
        }
        #endregion

        #region External Links
        // JIRA issue link format https://centeredge.atlassian.net/browse/ADVANTAGE-6311
        //private string GetJIRAIssueLink(string jiraIssue)
        //{
        //    return string.Format(@"https://centeredge.atlassian.net/browse/ADVANTAGE-{0}", jiraIssue);
        //}
        private string GetJIRAIssueLink(string repoName, string jiraIssue)
        {
            return string.Format(@"https://centeredge.atlassian.net/browse/{0}-{1}", repoName, jiraIssue);
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
                string url = GetJIRAIssueLink(requestView.RepoName, requestView.JiraIssueNumber);
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
                    tsbTimer.Image = Properties.Resources._112_RefreshArrow_Green_32x32_72;
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
                    tsbTimer.Image = Properties.Resources._305_Close_32x32_72;
                }

                tsbOpen.Enabled = !timer1.Enabled;
                tsbClosed.Enabled = !timer1.Enabled;
                tsbAll.Enabled = !timer1.Enabled;
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
        private void lvPullRequests_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.lvPullRequests.Sort();
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

        #region context menu items
        private void openJIRAIssueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenJIRAIssue();
        }

        private void openPullRequestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenGitHubIssue();
        }
        #endregion

        #region Toolbar Button Items

        private void patchFileMoverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayPatchFileMover();
        }
        private void patchHelperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayPatchFileMover();
        }
        void DisplayPatchFileMover()
        {
            try
            {
                if (lvPullRequests.SelectedItems.Count > 0)
                {
                    PullRequestView request = (PullRequestView)lvPullRequests.SelectedItems[0].Tag;
                    var assemblyHelper = new PullRequestAssembyHelper(request, "rroberts");
                    var targetVersion = request.Version;
                    var patchHelper = new PatchHelper(assemblyHelper, targetVersion);

                    var dialog = new PatchFileMoverDialog(patchHelper);
                    dialog.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtAutoProcess.Clear();
        }

        private void copyAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtAutoProcess.SelectAll();
            txtAutoProcess.Copy();
        }

        private void dllsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuildDlls();
        }
        void BuildDlls()
        {
            try
            {
                using (PowerShell PowerShellInstance = PowerShell.Create())
                {
                    // use "AddScript" to add the contents of a script file to the end of the execution pipeline.
                    // use "AddCommand" to add individual commands/cmdlets to the end of the execution pipeline.
                    //PowerShellInstance.AddScript("param($param1) $d = get-date; $s = 'test string value'; " +
                    //        "$d; $s; $param1; get-service");

                    string buildScript = @"C:\Users\rroberts\Source\Repos\Advantage\tools\build\build.ps1";

                    PowerShellInstance.AddCommand(buildScript);

                    // invoke execution on the pipeline (collecting output)
                    Collection<PSObject> PSOutput = PowerShellInstance.Invoke();

                    powershellStringBuilder = new StringBuilder();
                    // loop through each output object item
                    foreach (PSObject outputItem in PSOutput)
                    {
                        // if null object was dumped to the pipeline during the script then a null
                        // object may be present here. check for null to prevent potential NRE.
                        if (outputItem != null)
                        {
                            //TODO: do something with the output item 
                            // outputItem.BaseOBject
                            powershellStringBuilder.AppendLine(outputItem.BaseObject.ToString());
                        }
                    }
                    var scriptOutput = powershellStringBuilder.ToString();

                    Console.WriteLine(scriptOutput);
                    txtAutoProcess.Text += scriptOutput;

                    if (scriptOutput.Contains("error"))
                    {
                        NotifyError();
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }

            Console.WriteLine("Done");
        }
        private void executablesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuildExecutables();
        }
        StringBuilder powershellStringBuilder = null;
        void BuildExecutables()
        {
            try
            {
                using (PowerShell PowerShellInstance = PowerShell.Create())
                {
                    // use "AddScript" to add the contents of a script file to the end of the execution pipeline.
                    // use "AddCommand" to add individual commands/cmdlets to the end of the execution pipeline.
                    //PowerShellInstance.AddScript("param($param1) $d = get-date; $s = 'test string value'; " +
                    //        "$d; $s; $param1; get-service");

                    string buildScript = @"C:\Users\rroberts\Source\Repos\Advantage\tools\build\build.ps1";

                    PowerShellInstance.AddCommand(buildScript);
                    PowerShellInstance.AddParameter("Target", "Executables");

                    // invoke execution on the pipeline (collecting output)
                    Collection<PSObject> PSOutput = PowerShellInstance.Invoke();

                    powershellStringBuilder = new StringBuilder();
                    // loop through each output object item
                    foreach (PSObject outputItem in PSOutput)
                    {
                        // if null object was dumped to the pipeline during the script then a null
                        // object may be present here. check for null to prevent potential NRE.
                        if (outputItem != null)
                        {
                            //TODO: do something with the output item 
                            // outputItem.BaseOBject
                            powershellStringBuilder.AppendLine(outputItem.BaseObject.ToString());
                        }
                    }
                    var scriptOutput = powershellStringBuilder.ToString();

                    Console.WriteLine(scriptOutput);
                    txtAutoProcess.Text += scriptOutput;

                    if (scriptOutput.Contains("error"))
                    {
                        NotifyError();
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }

            Console.WriteLine("Done");
        }
        void NotifyError()
        {
            MessageBox.Show("Error running build script");
        }

        private void dbVersionHelperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                GitHubCE.Logic.DbVersionHelper versionHelper = new GitHubCE.Logic.DbVersionHelper("ADVANTAGE", "rroberts");
                DbVersionDialog dialog = new DbVersionDialog();
                dialog.ShowDialog();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
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
        private void tsbAdvantage_Click_1(object sender, EventArgs e)
        {
            OpenAdvantageBoard();
        }

        private void tsbBamboo_Click_1(object sender, EventArgs e)
        {
            OpenBamboo();
        }

        private void tsbJIRAIssue_Click_1(object sender, EventArgs e)
        {
            OpenJIRAIssue();
        }

        private void tsbGitHubIssue_Click_1(object sender, EventArgs e)
        {
            OpenGitHubIssue();
        }

        private void tsbPullRequests_Click_1(object sender, EventArgs e)
        {
            OpenPullRequests();
        }
        private void tsbOptions_Click(object sender, EventArgs e)
        {
            DisplayOptionsDialog();
        }
        void DisplayOptionsDialog()
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

        private void cboDaysBack_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (null == cboDaysBack.SelectedItem)
            {
                _daysBack = 0;
            }
            else
            {
                _daysBack = Convert.ToInt32(cboDaysBack.SelectedItem);
            }
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayOptionsDialog();
        }

        private void btnClearGrid_Click(object sender, EventArgs e)
        {
            ClearRequests();
        }
        #endregion

        #region search toolbar
        private void txtJiraSearchNumber_TextChanged(object sender, EventArgs e)
        {
            tsbJiraSearch.Enabled = !(String.IsNullOrEmpty(txtJiraSearchNumber.Text));
        }

        private void tsbJiraSearch_Click(object sender, EventArgs e)
        {
            SearchForJiraIssue();
        }

        private void SearchForJiraIssue()
        {
            try
            {
                ClearRequests();
                ClearRequestDetails();

                var jiraSearchNumber = txtJiraSearchNumber.Text;
                SearchForRequests(null, jiraSearchNumber);
                SafeDisplayPullRequests(PullRequests);
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        #endregion
        #endregion

        #region Form State
        private void SetFormStateBusy()
        {
            lblLastUpdate.Text = "Reading requests...";
        }

        private void SafeSetFormStateIdle(DateTime timestamp)
        {
            UpdateFormStateCallback cb = new UpdateFormStateCallback(SetFormStateIdle);
            this.Invoke(cb, new object[] { timestamp });
        }

        private void SetFormStateIdle(DateTime timestamp)
        {
            lblLastUpdate.Text = String.Format("Last Update: {0}", timestamp.ToString());
        }

        #endregion

        #region Common
        void LoadRepoNamesList()
        {
            _repoNames = JsonConvert.DeserializeObject<List<string>>(Settings.Default.ActiveRepoList);
        }
        
        private void NotifyNewPullRequest()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(() => { NotifyNewPullRequest(); }));
            }
            else {
                FlashWindow(this.Handle, true);
            }
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
            GitHubCELog.Log(message);          
        }        
        #endregion

        #region GitHubRepo          
        private async void RefreshRequests(ItemState? state)
        {
            try
            {
                SetFormStateBusy();
                if (null == _gitHubRepoHelper)
                {
                    _gitHubRepoHelper = new GitHubRepo(Settings.Default.GitHubRepoOwner, Settings.Default.GitHubUserName, Settings.Default.GitHubToken);
                    _gitHubRepoHelper.NewPullRequests += CustReports_NewPullRequests;
                    _gitHubRepoHelper.GetPullRequestsComplete += CustReports_GetPullRequestComplete;
                }
                // start new thread here
                await Task.Run(() =>
                {
                    try
                    {
                        _gitHubRepoHelper.GetRequests(state, _daysBack, _repoNames);
                    }
                    catch (Exception ex)
                    {
                        ExceptionHandler(ex);
                    }
                });
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        private async void SearchForRequests(ItemState? state, string jiraIssueNumber)
        {
            try
            {
                SetFormStateBusy();
                if (null == _gitHubRepoHelper)
                {
                    _gitHubRepoHelper = new GitHubRepo(Settings.Default.GitHubRepoOwner, Settings.Default.GitHubUserName, Settings.Default.GitHubToken);
                    _gitHubRepoHelper.NewPullRequests += CustReports_NewPullRequests;
                    _gitHubRepoHelper.GetPullRequestsComplete += CustReports_GetPullRequestComplete;
                }
                // start new thread here
                await Task.Run(() =>
                {
                    _gitHubRepoHelper.SearchRequestsByJiraIssue(state, 365, _repoNames, jiraIssueNumber);
                });
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
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
                SafeDisplayPullRequests(repo.PullRequests);
                SafeSetFormStateIdle(DateTime.Now);
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
            if (_formLoading) return;

            Settings.Default.ShowOpenRequests = showOpenRequestsToolStripMenuItem.Checked;
            Settings.Default.Save();
            ClearRequests();
            ClearRequestDetails();
            ReloadRequests();
        }

        private void showClosedRequestsToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (_formLoading) return;

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

        #region helper classes 
        /// <summary>
        /// This class is an implementation of the 'IComparer' interface.
        /// </summary>
        public class ListViewColumnSorter : IComparer
        {
            /// <summary>
            /// Specifies the column to be sorted
            /// </summary>
            private int ColumnToSort;
            /// <summary>
            /// Specifies the order in which to sort (i.e. 'Ascending').
            /// </summary>
            private SortOrder OrderOfSort;
            /// <summary>
            /// Case insensitive comparer object
            /// </summary>
            private CaseInsensitiveComparer ObjectCompare;

            /// <summary>
            /// Class constructor.  Initializes various elements
            /// </summary>
            public ListViewColumnSorter()
            {
                // Initialize the column to '0'
                ColumnToSort = 0;

                // Initialize the sort order to 'none'
                OrderOfSort = SortOrder.None;

                // Initialize the CaseInsensitiveComparer object
                ObjectCompare = new CaseInsensitiveComparer();
            }

            /// <summary>
            /// This method is inherited from the IComparer interface.  It compares the two objects passed using a case insensitive comparison.
            /// </summary>
            /// <param name="x">First object to be compared</param>
            /// <param name="y">Second object to be compared</param>
            /// <returns>The result of the comparison. "0" if equal, negative if 'x' is less than 'y' and positive if 'x' is greater than 'y'</returns>
            public int Compare(object x, object y)
            {
                int compareResult;
                ListViewItem listviewX, listviewY;

                // Cast the objects to be compared to ListViewItem objects
                listviewX = (ListViewItem)x;
                listviewY = (ListViewItem)y;

                // Compare the two items
                compareResult = ObjectCompare.Compare(listviewX.SubItems[ColumnToSort].Text, listviewY.SubItems[ColumnToSort].Text);

                // Calculate correct return value based on object comparison
                if (OrderOfSort == SortOrder.Ascending)
                {
                    // Ascending sort is selected, return normal result of compare operation
                    return compareResult;
                }
                else if (OrderOfSort == SortOrder.Descending)
                {
                    // Descending sort is selected, return negative result of compare operation
                    return (-compareResult);
                }
                else
                {
                    // Return '0' to indicate they are equal
                    return 0;
                }
            }

            /// <summary>
            /// Gets or sets the number of the column to which to apply the sorting operation (Defaults to '0').
            /// </summary>
            public int SortColumn
            {
                set
                {
                    ColumnToSort = value;
                }
                get
                {
                    return ColumnToSort;
                }
            }

            /// <summary>
            /// Gets or sets the order of sorting to apply (for example, 'Ascending' or 'Descending').
            /// </summary>
            public SortOrder Order
            {
                set
                {
                    OrderOfSort = value;
                }
                get
                {
                    return OrderOfSort;
                }
            }

        }

        private void tsbBuildExecutables_Click(object sender, EventArgs e)
        {
            try
            {
                psRunner.StartScript(@".\tools\build\build -Target Executables");
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private void tsbBuildAssemblies_Click(object sender, EventArgs e)
        {
            try
            {
                psRunner.StartScript(@".\tools\build\build.ps1");
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private void tsbPull_Click(object sender, EventArgs e)
        {
            try
            {
                //IList<string> commands = new List<string>();
                //commands.Add(@"git checkout develop");
                //commands.Add(@"git pull");
                //RunCommandList(commands);
                psRunner.GetCurrentBranch();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        private IList<string> _commandList;
        private int _currentCommandIdx = -1;
        private bool _runningCommands = false;
        private void RunCommandList(IList<string> commands)
        {
            if (_runningCommands)
            {
                MessageBox.Show("Already Running A Command List");
                return;
            }
            _commandList = commands;
            _currentCommandIdx = -1;
            try
            {
                _runningCommands = true;
                RunNextCommand();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        private void RunNextCommand()
        {
            _currentCommandIdx++;
            if (_commandList.Count > _currentCommandIdx)
            {
                var command = _commandList[_currentCommandIdx];
                psRunner.StartScript(command);
            }
            else
            {
                _runningCommands = false;
            }
        }

        private void PsRunner_ScriptComplete(object sender, bool isSuccessful)
        {
            if (_runningCommands && isSuccessful)
            {
                RunNextCommand();
            }
            else
            {
                _runningCommands = false;
            }
        }

        private void tsbRunCommand_Click(object sender, EventArgs e)
        {
            RunPsCommand();
        }

        private void txtCommand_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                RunPsCommand();
        }

        private void RunPsCommand()
        {
            try
            {
                IList<string> commands = new List<string>();
                var commandText = cboCommand.Text;
                commands.Add(commandText);
                RunCommandList(commands);
                cboCommand.Items.Insert(0, commandText);
                cboCommand.Text = "";
                cboCommand.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            CheckoutAndBuildBranch();
        }
        private void CheckoutAndBuildBranch()
        {
            try
            {
                IList<string> commands = new List<string>();
                var branchName = cmbBranches.Text;

                commands.Add(String.Format("git checkout {0}", branchName));
                commands.Add("git pull");
                commands.Add(@".\tools\build\build.ps1");

                RunCommandList(commands);
                
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        #endregion

        //private void toolStripButton1_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        var jira = new JiraIssueHelper(Settings.Default.JiraUrl, Settings.Default.JiraUserName, Settings.Default.JiraUserPassword);
        //        jira.GetJiraProjects();
        //    }
        //    catch (Exception ex)
        //    {
        //        ExceptionHandler(ex);
        //    }          
        //}
    }
}
