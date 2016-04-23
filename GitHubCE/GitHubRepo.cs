using Atlassian.Jira;
using DbVersionLibrary;
using GitHubCE.Properties;
using JiraCE;
using Octokit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubCE
{
    public class GitHubRepo
    {
        #region events
        public event EventHandler NewPullRequests;
        void OnNewPullRequest()
        {
            EventHandler handler = NewPullRequests;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        public event EventHandler GetPullRequestsComplete;
        void OnGetPullRequestsComplete()
        {
            EventHandler handler = GetPullRequestsComplete;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
        #endregion

        #region fields
        private readonly string _owner;
        private readonly string _user;
        private readonly string _token;
        #endregion

        #region properties        
        private GitHubClient _client = null;
        public GitHubClient Client
        {
            get
            {
                if (null == _client)
                {
                    _client = new GitHubClient(new ProductHeaderValue("CE.GitHub.Helper"));
                    _client.Credentials = new Credentials(_user, _token);
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

        #region ctor
        public GitHubRepo()
        {

        }

        public GitHubRepo(string owner, string user, string token)
        {
            _owner = owner;
            _user = user;
            _token = token;
        }
        #endregion

        #region public   
        public void GetRequests(IList<string> repoNames)
        {
            GetRequests(null, 0, repoNames);
        }
        public void GetRequests(ItemState? state, IList<string> repoNames)
        {
             GetRequests(state, 0, repoNames);
        }
        public void GetRequests(ItemState? state, int daysBack, IList<string> repoNames)
        {
            GetRequests(state, new DateRange(DateTime.Now.AddDays(-1 * daysBack), SearchQualifierOperator.GreaterThanOrEqualTo), repoNames);
        }
        public void GetRequests(ItemState? state, DateRange searchDates, IList<string> repoNames)
        {
            var result = GetPullRequestViews(state, searchDates, repoNames);
        }
        #endregion

        #region private [GitHub]               
        async Task GetPullRequestViews(ItemState? state, DateRange searchDates, IList<string> repoNames)
        {
            try
            {
                var hasNewRequests = false;

                var searchResults = await SearchPullRequests(state, searchDates, repoNames);

                // Gets general info on each Pull Request.
                var existingRequestIds = PullRequests.Select(r => r.Id).ToList();

                foreach (var request in searchResults.Items)
                {
                    var existingRequest = PullRequests.FirstOrDefault(r => r.Id == request.Number);
                    if (null == existingRequest)
                    {
                        var newRequest = new PullRequestView()
                        {
                            RepoName = request.PullRequest.HtmlUrl.Segments[2].TrimEnd('/'),
                            Title = request.Title,
                            Id = request.Number,
                            Created = request.CreatedAt,
                            Updated = request.UpdatedAt.GetValueOrDefault(),
                            State = request.State,
                            Developer = request.User.Login,
                            JiraIssues = GetJiraIssues(request), //TODO: Get Commits, Comments, etc?
                            Tag = request
                        };

                        // Get detailed info on each Pull Request.
                        var pullRequest = await Client.Repository.PullRequest.Get(_owner, newRequest.RepoName, request.Number);
                        //Console.WriteLine("pullRequest.Base.Sha = {0}", pullRequest.Base.Sha);
                        if (null != pullRequest)
                        {
                            newRequest.Branch = pullRequest.Base.Ref;
                            newRequest.Version = BranchHelper.Map.GetVersion(newRequest.Branch);
                            newRequest.Mergeable = pullRequest.Mergeable;
                            newRequest.Merged = pullRequest.Merged;
                            newRequest.ChangedFileCount = pullRequest.ChangedFiles;
                            newRequest.State = pullRequest.State;
                            newRequest.CommitCount = pullRequest.Commits;
                            //if (newRequest.State != ItemState.Closed)
                            //{
                            // TODO: Handle Multiple Commits

                            //Console.WriteLine("Getting Commit for pullRequest.Head.Sha = {0}", pullRequest.Head.Sha);
                            //Console.WriteLine("                   pullRequest.Base.Sha = {0}", pullRequest.Base.Sha);
                            var commitTask = await Client.Repository.Commit.Get(_owner, newRequest.RepoName, pullRequest.Head.Sha);
                            //Console.WriteLine("Got Commit: commitTask.Sha = {0}", commitTask.Sha);

                            if (null != commitTask)
                            {
                                newRequest.HasDbUpgrade = commitTask.Files.Any(f => f.Filename.Contains("AdvUpgrade"));
                                newRequest.HasBuildScriptChange = commitTask.Files.Any(f => f.Filename.Contains("build.ps1"));
                                newRequest.Files = commitTask.Files.Select(f => f.Filename).ToList();
                                var patch = new PatchBuilder(newRequest);
                                newRequest.AssembliesChanged = patch.Assemblies;
                                newRequest.Commits.Add(commitTask);

                                //if (commitTask.Parents.Count>0)
                                //{
                                //    Console.WriteLine("commitTask has {1} parents: commitTask.Sha = {0}", commitTask.Sha, commitTask.Parents.Count());

                                //    foreach (var parent in commitTask.Parents)
                                //    {
                                //        Console.WriteLine("    parent.Sha = {0}", parent.Sha);
                                //    }

                                //    Console.WriteLine("Getting Commit for commitTask.Parents[0].Sha = {0}", commitTask.Parents[0].Sha);
                                //    commitTask = await Client.Repository.Commit.Get(_owner, _reponame, commitTask.Parents[0].Sha);
                                //    Console.WriteLine("Got Commit: commitTask.Sha = {0}", commitTask.Sha);
                                //    Console.WriteLine("            pullRequest.Base.Sha = {0}", pullRequest.Base.Sha);
                                //    if (commitTask.Sha == pullRequest.Base.Sha)
                                //    {
                                //        Console.WriteLine("Breaking...");
                                //        Console.WriteLine();
                                //        break;
                                //    }
                                //}
                                //}
                            }
                        }
                        else
                        {
                            // closed pull request
                            newRequest.Branch = " - ";
                            newRequest.Version = new Version(0, 0);
                        }

                        PullRequests.Add(newRequest);

                        if (newRequest.State == ItemState.Open)
                            hasNewRequests = true;
                    }
                    else // already had a copy in our list.. update it
                    {
                        existingRequestIds.Remove(request.Number);

                        existingRequest.Updated = request.UpdatedAt.GetValueOrDefault();
                        existingRequest.State = request.State;

                        if (existingRequest.State == ItemState.Open)
                        {
                            var pullRequest = await Client.Repository.PullRequest.Get(_owner, existingRequest.RepoName, request.Number);
                            if (null != pullRequest)
                            {
                                existingRequest.Mergeable = request.PullRequest.Mergeable;
                                existingRequest.Merged = request.PullRequest.Merged;
                                existingRequest.ChangedFileCount = request.PullRequest.ChangedFiles;
                                existingRequest.CommitCount = request.PullRequest.Commits;
                                existingRequest.JiraIssues = GetJiraIssues(request);
                                var commitTask = await Client.Repository.Commit.Get(_owner, existingRequest.RepoName, pullRequest.Head.Sha);
                                existingRequest.HasBuildScriptChange = commitTask.Files.Any(f => f.Filename.Contains("build.ps1"));

                            }
                        }
                        // update the JIRA status.
                        existingRequest.JiraIssues = GetJiraIssues(request);
                    }
                }

                foreach (var requestToRemove in PullRequests.Where(r => existingRequestIds.Contains(r.Id)).ToList())
                {
                    PullRequests.Remove(requestToRemove);
                }

                if (hasNewRequests)
                    OnNewPullRequest();

                OnGetPullRequestsComplete();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        
        async Task<SearchIssuesResult> SearchPullRequests(ItemState? state, DateRange searchDates, IList<string> repoNames)
        {
            SearchIssuesRequest searchRequest = new SearchIssuesRequest()
            {
                // only search pull requests
                Type = IssueTypeQualifier.PR,
                State = state,
                Updated = searchDates
            };

            foreach (var repoName in repoNames)
            {
                searchRequest.Repos.Add(String.Format(@"{0}/{1}", _owner, repoName));
            }

            return await Client.Search.SearchIssues(searchRequest);
        }
        #endregion

        #region private [JIRA]
        IssueStatus GetJiraStatus(string jiraIssueNumber)
        {
            var jiraIssue = JiraHelper.GetJiraIssue(jiraIssueNumber);
            if (null != jiraIssue)
            {
                return jiraIssue.Status;
            }
            else
                return null;
        }

        IList<Atlassian.Jira.Issue> GetJiraIssues(Octokit.Issue request)
        {
            var jiraIssues = new List<Atlassian.Jira.Issue>();
            string titleAndBody = String.Empty;
            if (request.Title.Contains("…"))
            {
                titleAndBody = request.Title.Replace("…", "");
            }
            else
            {
                titleAndBody = request.Title;
            }
            if (request.Body.Contains("…"))
            {
                titleAndBody += request.Body.Replace("…", "");
            }
            else
            {
                titleAndBody += request.Body;
            }
            var jiraIssueNumbers = GetJiraIssueNumbers(titleAndBody);
            foreach (var jiraIssueNumber in jiraIssueNumbers)
            {
                var jiraIssue = JiraHelper.GetJiraIssue(jiraIssueNumber);
                if (null != jiraIssue)
                {
                    jiraIssues.Add(jiraIssue);
                }
            }
            return jiraIssues;
        }

        IList<string> GetJiraIssueNumbers(string body)
        {
            var issueNumbers = new List<string>();
            var token = "ADVANTAGE";
            var tokenLength = token.Length;

            if (body.Contains(token))
            {
                for (int i = 0; i < body.Length - tokenLength; i++)
                {
                    if (body.Substring(i, tokenLength) == token)
                    {
                        var issueNumberBuffer = String.Empty;
                        var nextIdx = 0;
                        // add 1 for the '-' character. (Sometimes it is a different character, so we don't hard-code it.)
                        var textSection = body.Substring(i + tokenLength + 1);
                        while (GetNumberValue(textSection, ref issueNumberBuffer, ref nextIdx))
                        {
                            if (!issueNumbers.Contains(issueNumberBuffer))
                                issueNumbers.Add(issueNumberBuffer);
                            if ("," == body.Substring(nextIdx + i + tokenLength - 1, 1))
                            {
                                textSection = body.Substring(nextIdx + i + tokenLength);
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
            }

            return issueNumbers;
        }

        bool GetNumberValue(string buffer, ref string numberValue, ref int nextIdx)
        {
            int digitLength = 0;
            for (int i = 0; i < buffer.Length; i++)
            {
                var digitBuffer = buffer.Substring(i, 1);
                if (digitBuffer != " ")
                {
                    if (!digitBuffer.All(Char.IsDigit))
                    {
                        numberValue = buffer.Substring(i - digitLength, digitLength).Trim();
                        nextIdx = i + 1;
                        return true;
                    }
                }
                digitLength++;
            }
            return false;
        }
        #endregion

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
    }
}
