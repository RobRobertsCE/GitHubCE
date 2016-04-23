using Atlassian.Jira;
using System;
namespace JiraCE
{
    public class JiraIssueHelper : IDisposable
    {
        #region consts
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
        public Issue GetJiraIssue(string jiraIssueNumber)
        {
            try
            {
                if (String.Empty.Equals(jiraIssueNumber)) throw new ArgumentNullException("jiraIssueNumber");

                if (!IsNumeric(jiraIssueNumber))
                {
                    Console.WriteLine(jiraIssueNumber + " Is Invalid JIRA Issue Number!");
                    return null;
                }

                return JiraService.GetIssue($"ADVANTAGE-{jiraIssueNumber}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }
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
