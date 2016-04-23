using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Atlassian.Jira;

namespace JiraCE
{
    public partial class CommitMessageHelper : Form
    {
        private Issue _jiraIssue = null;

        public CommitMessageHelper()
        {
            InitializeComponent();
        }

        private void btnGetIssue_Click(object sender, EventArgs e)
        {
            GetIssue();
        }

        void GetIssue()
        {
            try
            {
                if (String.Empty.Equals(txtIssueNumber.Text)) return;

                ClearDisplay();

                var jira = Jira.CreateRestClient("https://centeredge.atlassian.net", "rroberts", "hel-j205");

                var issueNumber = txtIssueNumber.Text.Trim();
                try
                {
                    _jiraIssue = jira.GetIssue($"ADVANTAGE-{issueNumber}");

                    jiraIssueView1.UpdateDisplay(_jiraIssue);

                    txtTitle.Text = _jiraIssue.Summary;
                }
                catch (Exception ex)
                {
                    // DisplayErrorMessage($"Issue {issueNumber} Not Found!");
                    DisplayErrorMessage(ex.Message);
                    Console.WriteLine(ex.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                DisplayErrorMessage(ex.ToString());
            }
        }

        void DisplayErrorMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        void ClearDisplay()
        {
            txtCommitMessage.Clear();
            txtTitle.Clear();
            txtMotivation.Clear();
            txtModifications.Clear();
            txtResults.Clear();
        }

        void BuildMessage()
        {
            try
            {
                var template = JiraCE.Properties.Resources.CommitTemplate;
                txtCommitMessage.Text = String.Format(template, txtTitle.Text, txtIssueNumber.Text, txtMotivation.Text, txtModifications.Text, txtResults.Text);
                Clipboard.SetText(txtCommitMessage.Text);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                DisplayErrorMessage(ex.ToString());
            }
        }

        private void btnBuild_Click(object sender, EventArgs e)
        {
            BuildMessage();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            GetIssue();
        }

        private void txtIssueNumber_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GetIssue();
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtCommitMessage.Text);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearDisplay();
        }
    }
}