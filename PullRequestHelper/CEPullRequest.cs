using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PullRequestHelper
{
    class CEJiraIssue
    {
        public string JiraIssueId { get; set; }
        public string JiraIssueNumber { get; set; }
        public string JiraProject { get; set; }
        public string JiraEpic { get; set; }
        public string JiraTeam { get; set; }
        public string IssueType { get; set; }
        public string Priority { get; set; }
        public string Developer { get; set; }
        public string Status { get; set; }
        public DateTime? LastUpdated { get; set; }
        public IList<Version> FoundInVersions { get; set; }
        public IList<Version> FixVersions { get; set; }
        public IList<CEGitHubPullRequest> PullRequests { get; set; }

        public CEJiraIssue()
        {
            FoundInVersions = new List<Version>();
            FixVersions = new List<Version>();
            PullRequests = new List<CEGitHubPullRequest>();
        }
    }

    class CEGitHubPullRequest
    {
        public string GitHubId { get; set; }
        public string BranchName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime LastUpdated { get; set; }
        public Version BranchVersion { get; set; }
        public IList<CEGitHubCommit> Commits { get; set; }
        public IList<string> Files { get; set; }
        public IList<string> Assemblies { get; set; }
        public IList<CEJiraIssue> JiraIssues { get; set; }

        public CEGitHubPullRequest()
        {
            Commits = new List<CEGitHubCommit>();
            Files = new List<string>();
            Assemblies = new List<string>();
            JiraIssues = new List<CEJiraIssue>();
        }
    }

    class CEGitHubCommit
    {
        public string CommitId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public IList<CETeamCityBuild> Builds { get; set; }

        public CEGitHubCommit()
        {
            Builds = new List<CETeamCityBuild>();
        }
    }

    class CETeamCityBuild
    {
        public string TeamCityBuildId { get; set; }
        public string Status { get; set; }
    }
}
