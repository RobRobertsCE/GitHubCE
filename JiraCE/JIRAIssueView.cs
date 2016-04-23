using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Atlassian.Jira;

namespace JiraCE
{
    public partial class JIRAIssueView : UserControl
    {
        public JIRAIssueView()
        {
            InitializeComponent();
        }

        public void UpdateDisplay(Issue jiraIssue)
        {
            this.lblProjectIssueNumber.Text = String.Format("{0} / {1}", jiraIssue.Project, jiraIssue.Key);
            this.lblSummary.Text = jiraIssue.Summary;
            this.lblPriority.Text = jiraIssue.Priority.Name;
            this.lblStatus.Text = jiraIssue.Status.Name;
            this.lblType.Text = jiraIssue.Type.Name;
            this.txtDescription.Text = jiraIssue.Description;
            foreach (var version in jiraIssue.AffectsVersions)
            {
                this.lblAffectedVersions.Text += version.Name + " ";
            }            
            if (null!=jiraIssue["Acceptance Criteria"])
                this.txtAcceptanceCriteria.Text = jiraIssue["Acceptance Criteria"].ToString();
            this.lblAssignee.Text = jiraIssue.Assignee;
            foreach (var comment in jiraIssue.GetComments())
            {
                txtComments.Text += String.Format("{0} [{1}] {2}\r\n\r\n", comment.CreatedDate.Value, comment.Author, comment.Body);
            }
        }
    }
}
