using Atlassian.Jira;
using Octokit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GitHubCE
{
    public class PullRequestView
    {
        public int Id { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset Updated { get; set; }
        public string RepoName { get; set; }
        public string Title { get; set; }
        public bool HasBuildScriptChange { get; set; }
        public string JiraIssueNumber
        {
            get
            {
                if (JiraIssues.Count > 0)
                {
                    return JiraIssueNumbers.FirstOrDefault().ToString();
                }
                else
                {
                    return "-";
                }
            }
        }
        public string JiraIssueStatus
        {
            get
            {
                if (JiraIssues.Count > 0)
                {
                    return JiraIssues.FirstOrDefault().Status.Name.ToString();
                }
                else
                {
                    return "-";
                }
            }
        }
        public string Branch { get; set; }
        public Version Version { get; set; }
        public ItemState State { get; set; }
        public int ChangedFileCount { get; set; }
        public IList<string> Files { get; set; }
        public bool? Mergeable { get; set; }
        public bool Merged { get; set; }
        public bool PatchesCreated { get; set; }
        public bool JiraUpdated { get; set; }
        public bool HasDbUpgrade { get; set; }
        public bool DbScriptsApplied { get; set; }
        public bool NeedsDevAttention { get; set; }
        public string Developer { get; set; }
        public object Tag { get; set; }
        public int CommitCount { get; set; }
        public IList<GitHubCommit> Commits { get; set; }
        public IList<string> FilesChanged { get; set; }
        public IList<string> AssembliesChanged { get; set; }

        private IList<Atlassian.Jira.Issue> _jIRAIssues;
        public IList<Atlassian.Jira.Issue> JiraIssues
        {
            get
            {
                return _jIRAIssues;
            }
            set
            {
                _jIRAIssues = value;
                JiraIssueNumbers = new List<int>();
                if (JiraIssues.Count > 0)
                {
                    foreach (var issue in JiraIssues)
                    {
                        var issueKey = issue.Key.Value;
                        var issueNumberBuffer = issueKey.Replace("ADVANTAGE-", "").Replace("WEB-", "");
                        var issueNumber = Int32.Parse(issueNumberBuffer);
                        JiraIssueNumbers.Add(issueNumber);
                    }
                }
            }
        }
        public IList<int> JiraIssueNumbers { get; private set; }

        public IList<string> JiraIssueKeys
        {
            get
            {
                var keys = new List<string>();
                if (JiraIssues.Count > 0)
                {
                    foreach (var issue in JiraIssues)
                    {
                        keys.Add(issue.Key.Value);
                    }
                }
                return keys;
            }
        }
        public string JiraIssueKeyList
        {
            get
            {                
                return String.Join(", ", JiraIssueKeys);
            }
        }

        public PullRequestView()
        {
            Files = new List<string>();
            AssembliesChanged = new List<string>();
            JiraIssues = new List<Atlassian.Jira.Issue>();
            JiraIssueNumbers = new List<int>();
            Version = new Version(0, 0);
            Commits = new List<GitHubCommit>();
        }
    }
}
