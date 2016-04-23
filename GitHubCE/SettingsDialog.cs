using GitHubCE.Properties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GitHubCE
{
    public partial class SettingsDialog : Form
    {
        IList<string> _repoNames;
        IList<string> _activeRepoNames;

        public SettingsDialog()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (SettingsAreValid())
                {
                    SaveSettings();
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(ex.ToString());
            }
        }

        bool SettingsAreValid()
        {
            var result = true;
            try
            {
                if (String.IsNullOrEmpty(txtGitHubOwner.Text))
                {
                    MessageBox.Show(this, "GitHub Repo Owner can not be blank", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    result = false;
                }
                if (String.IsNullOrEmpty(txtGitHubUser.Text))
                {
                    MessageBox.Show(this, "GitHub User Name can not be blank", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    result = false;
                }
                if (String.IsNullOrEmpty(txtGitHubToken.Text))
                {
                    MessageBox.Show(this, "GitHub Token can not be blank", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    result = false;
                }
                if (String.IsNullOrEmpty(txtJiraURL.Text))
                {
                    MessageBox.Show(this, "JIRA URL can not be blank", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    result = false;
                }
                if (String.IsNullOrEmpty(txtJiraUser.Text))
                {
                    MessageBox.Show(this, "JIRA User Name can not be blank", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    result = false;
                }
                if (String.IsNullOrEmpty(txtJiraPassword.Text))
                {
                    MessageBox.Show(this, "JIRA Password can not be blank", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    result = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(ex.ToString());
                result = false;
            }
            return result;
        }

        void SaveSettings()
        {
            Settings.Default.GitHubRepoOwner = txtGitHubOwner.Text;
            Settings.Default.GitHubUserName = txtGitHubUser.Text;
            Settings.Default.GitHubToken = txtGitHubToken.Text;
            Settings.Default.JiraUrl = txtJiraURL.Text;
            Settings.Default.JiraUserName = txtJiraUser.Text;
            Settings.Default.JiraUserPassword = txtJiraPassword.Text;

            _activeRepoNames.Clear();

            foreach (var item in lstRepos.CheckedItems )
            {
                _activeRepoNames.Add(item.ToString());
            }
            Settings.Default.ActiveRepoList = JsonConvert.SerializeObject(_activeRepoNames);


            Properties.Settings.Default.Save();
        }

        void LoadSettings()
        {
            txtGitHubOwner.Text = Settings.Default.GitHubRepoOwner;
            txtGitHubUser.Text = Settings.Default.GitHubUserName;
            txtGitHubToken.Text = Settings.Default.GitHubToken;
            txtJiraURL.Text = Settings.Default.JiraUrl;
            txtJiraUser.Text = Settings.Default.JiraUserName;
            txtJiraPassword.Text = Settings.Default.JiraUserPassword;

            _repoNames = JsonConvert.DeserializeObject<List<string>>(Settings.Default.RepoList);
            _activeRepoNames = JsonConvert.DeserializeObject<List<string>>(Settings.Default.ActiveRepoList);

            foreach (var repoName in _repoNames)
            {
                var idx = lstRepos.Items.Add(repoName);
                if (_activeRepoNames.Contains(repoName))
                {
                    lstRepos.SetItemChecked(idx, true);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void SettingsDialog_Load(object sender, EventArgs e)
        {
            try
            {
                LoadSettings();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
