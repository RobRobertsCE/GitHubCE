using Atlassian.Jira;
using System;
using System.Linq;

namespace JiraCE
{
    public class JiraIssueHelper : IDisposable
    {
        #region fields
        private readonly string _jiraUrl;
        private readonly string _jiraUserName;
        private readonly string _jiraUserPassword;
        private Jira _jira;
        #endregion

        #region properties
        protected internal Jira JiraService
        {
            get
            {
                if (null == _jira)
                    _jira = Jira.CreateRestClient(_jiraUrl, _jiraUserName, _jiraUserPassword);

                return _jira;
            }
        }
        #endregion

        #region ctor
        public JiraIssueHelper(string url, string user, string password)
        {
            _jiraUrl = url;
            _jiraUserName = user;
            _jiraUserPassword = password;
        }
        #endregion

        #region public methods       
        /// <summary>
        /// Returns a Jira Issue for the given key.
        /// </summary>
        /// <param name="jiraKey">ex. ADVANTAGE-1234</param>
        public Issue GetJiraIssueByKey(string jiraIssuekey)
        {
            try
            {
                if (String.Empty.Equals(jiraIssuekey)) throw new ArgumentNullException("jiraIssuekey");
                
                return JiraService.GetIssue(jiraIssuekey);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }
        public string GetEpicName(string jiraIssuekey)
        {
            var issue = GetJiraIssueByKey(jiraIssuekey);
            if (issue.Type == "Epic")
                return issue.Description;
            else
                throw new InvalidOperationException("Issue Key Not For an Epic");
        }

        public void GetJiraProjects()
        {
            var projects = JiraService.GetProjects();

            foreach (var project in projects)
            {
                Console.WriteLine("Id:{0}; Key:{1}; Name:{2}; Lead:{3}", project.Id, project.Key, project.Name, project.Lead);
            }
        }


        public Project GetJiraProject(string key)
        {
            var project = JiraService.GetProjects().FirstOrDefault(projects => projects.Key == key);

            return project;
        }        

        public static System.Boolean IsNumeric(System.Object Expression)
        {
            if (Expression == null || Expression is DateTime)
                return false;

            if (Expression is Int16 || Expression is Int32 || Expression is Int64 || Expression is Decimal || Expression is Single || Expression is Double || Expression is Boolean)
                return true;

            try
            {
                if (Expression is string)
                    Double.Parse(Expression as string);
                else
                    Double.Parse(Expression.ToString());
                return true;
            }
            catch { } // just dismiss errors but return false
            return false;
        }
        #endregion

        #region IDisposable
        public void Dispose()
        {
            _jira = null;
        }
        #endregion
    }
}
