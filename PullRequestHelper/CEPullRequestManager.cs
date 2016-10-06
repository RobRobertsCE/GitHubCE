using GitHubCE;
using Octokit;
using PullRequestHelper.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PullRequestHelper
{
    class CEPullRequestManager
    {

        GitHubRepo _gitHubRepoHelper;
        int _daysBack = 1;
        IList<string> _repoNames;

        public IList<CEGitHubPullRequest> PullRequests { get; set; }

        public CEPullRequestManager()
        {
            PullRequests = new List<CEGitHubPullRequest>();
            _repoNames = new List<string>();
            _repoNames.Add("Advantage");
        }

        #region common
        private void ExceptionHandler(Exception ex)
        {
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

        public async void UpdatePullRequests(ItemState? state)
        {
            try
            {
                if (null == _gitHubRepoHelper)
                {
                    _gitHubRepoHelper = new GitHubRepo(Settings.Default.GitHubRepoOwner, Settings.Default.GitHubUserName, Settings.Default.GitHubToken);
                    _gitHubRepoHelper.GetPullRequestsComplete += CustReports_GetPullRequestComplete;
                }

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

        private void CustReports_GetPullRequestComplete(object sender, EventArgs e)
        {
            try
            {
                GitHubRepo repo = (GitHubRepo)sender;
                DisplayPullRequests(repo.PullRequests);
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        void DisplayPullRequests(IList<PullRequestView> requests)
        {
            try
            {
                var assignedTeam = "None";

                foreach (var request in requests.OrderBy(r => r.Updated))
                {
                    var pullRequestId = request.Id.ToString();

                    var pullRequest = PullRequests.FirstOrDefault(r => r.GitHubId == pullRequestId);

                    if (null == pullRequest)
                    {
                        // new request
                        pullRequest = new CEGitHubPullRequest();
                        pullRequest.GitHubId = pullRequestId;
                        pullRequest.Title = request.Title;
                        pullRequest.LastUpdated = request.Updated.ToLocalTime().DateTime;

                        if (request.JiraIssues.Count > 0)
                        {
                            foreach (var jiraIssue in request.JiraIssues)
                            {
                                var newJiraIssue = new CEJiraIssue();
                                newJiraIssue.JiraIssueId = jiraIssue.Key.ToString();
                                newJiraIssue.JiraProject = jiraIssue.Project;
                                newJiraIssue.Status = jiraIssue.Status.ToString();
                                newJiraIssue.LastUpdated = jiraIssue.Updated;
                                
                                if (null != request.JiraIssues[0].CustomFields["Team"])
                                    newJiraIssue.JiraTeam = request.JiraIssues[0].CustomFields["Team"].Values[0];

                                pullRequest.JiraIssues.Add(newJiraIssue);
                            }
                        }

                        foreach (var commit in request.Commits)
                        {
                            var CECommit = new CEGitHubCommit();
                            CECommit.CommitId = commit.Ref;
                        }

                        PullRequests.Add(pullRequest);
                    }
                    else
                    {
                        // existing request
                    }

                    //if (request.JiraIssues.Count > 0)
                    //{
                    //    // Error here when pull request uses the epic branch, such as for unit tests.
                    //    if (null != request.JiraIssues[0].CustomFields["Team"])
                    //        assignedTeam = request.JiraIssues[0].CustomFields["Team"].Values[0];

                    //    if (
                    //        (request.State == ItemState.Open && Settings.Default.ShowOpenRequests ||
                    //        request.State != ItemState.Open && Settings.Default.ShowClosedRequests ||
                    //        (request.State != ItemState.Open && request.JiraIssueStatus == "In Progress") && Settings.Default.ShowClosedInProgress) &&
                    //        (((assignedTeam == "AMS") && showAMSToolStripMenuItem.Checked) ||
                    //        (assignedTeam == "R&D" && showRDToolStripMenuItem.Checked) ||
                    //        (assignedTeam == "None"))
                    //        )
                    //    {
                    //        ListViewItem match = null;
                    //        foreach (ListViewItem lvi in lvPullRequests.Items)
                    //        {
                    //            if (((PullRequestView)lvi.Tag).Id == request.Id)
                    //            {
                    //                match = lvi;
                    //                break;
                    //            }
                    //        }
                    //        if (null == match)
                    //        {
                    //            // add a new item.
                    //            var lvi = new ListViewItem(new string[] {
                    //                request.JiraIssues[0].CustomFields["Team"].Values[0],
                    //                request.Id.ToString(),
                    //                request.RepoName,
                    //                request.Updated.ToLocalTime().ToString(),
                    //                request.Title,
                    //                request.JiraIssueKeyList,
                    //                request.Branch,
                    //                request.Version.ToString(),
                    //                request.FixVersions,
                    //                request.HasDbUpgrade ? "** YES **":"",
                    //                request.State.ToString(),
                    //                request.Developer,
                    //                request.JiraIssueStatus});

                    //            lvi.UseItemStyleForSubItems = true;

                    //            if (assignedTeam == "AMS")
                    //            {
                    //                // *** Formatting - AMS *** //

                    //                if (request.HasBuildScriptChange)
                    //                {
                    //                    lvi.BackColor = Color.DarkRed;
                    //                    lvi.ForeColor = Color.LightCyan;
                    //                    lblWarning.Text = request.JiraIssueNumber.ToUpper() + " HAS BUILD.PS1 SCRIPT CHANGE!!!";
                    //                    lblWarning.BackColor = Color.Red;
                    //                }
                    //                else if (request.State == ItemState.Closed)
                    //                {
                    //                    lvi.UseItemStyleForSubItems = true;
                    //                    lvi.ForeColor = Color.DimGray;
                    //                }
                    //                else
                    //                {
                    //                    lvi.UseItemStyleForSubItems = false;
                    //                    if (request.Branch != "develop")
                    //                    {
                    //                        lvi.SubItems[6].ForeColor = Color.Blue;
                    //                    }

                    //                    if (request.HasDbUpgrade)
                    //                    {
                    //                        lvi.SubItems[9].BackColor = Color.Orange;
                    //                    }

                    //                    if (!request.VersionIsValid)
                    //                    {
                    //                        lvi.SubItems[8].BackColor = Color.Red;
                    //                        lvi.SubItems[7].BackColor = Color.Red;
                    //                    }
                    //                }
                    //            }
                    //            else
                    //            {
                    //                // *** Formatting - R&D *** //
                    //                lvi.ForeColor = Color.Gray;
                    //                lvi.BackColor = Color.WhiteSmoke;
                    //            }
                    //            lvi.Tag = request;
                    //            lvPullRequests.Items.Add(lvi);
                    //        }
                    //        else
                    //        {
                    //            // update existing item.
                    //            match.SubItems.Clear();
                    //            match.Text = assignedTeam;
                    //            match.SubItems.AddRange(new string[] {
                    //                request.Id.ToString(),
                    //                request.RepoName,
                    //                request.Updated.ToLocalTime().ToString(),
                    //                request.Title,
                    //                request.JiraIssueKeyList,
                    //                request.Branch,
                    //                request.Version.ToString(),
                    //                request.FixVersions,
                    //                request.HasDbUpgrade ? "** YES **":"",
                    //                request.State.ToString(),
                    //                request.Developer,
                    //                request.JiraIssueStatus});
                    //            if (assignedTeam == "AMS")
                    //            {
                    //                if (request.State == ItemState.Closed)
                    //                {
                    //                    match.UseItemStyleForSubItems = true;
                    //                    match.ForeColor = Color.DimGray;
                    //                }
                    //                else
                    //                {
                    //                    match.UseItemStyleForSubItems = false;
                    //                    if (request.Branch != "develop")
                    //                    {
                    //                        match.SubItems[6].ForeColor = Color.Blue;
                    //                    }

                    //                    if (request.HasDbUpgrade)
                    //                    {
                    //                        match.SubItems[9].BackColor = Color.Orange;
                    //                    }

                    //                    if (!request.VersionIsValid)
                    //                    {
                    //                        match.SubItems[8].BackColor = Color.Red;
                    //                        match.SubItems[7].BackColor = Color.Red;
                    //                    }
                    //                }
                    //            }
                    //            else
                    //            {
                    //                // *** Formatting - R&D *** //
                    //                match.ForeColor = Color.Gray;
                    //                match.BackColor = Color.WhiteSmoke;
                    //            }
                    //            match.Tag = request;
                    //        }
                    //    }
                    //  }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

    }
}
