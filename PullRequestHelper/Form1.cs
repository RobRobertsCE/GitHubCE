using GitHubCE;
using Octokit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PullRequestHelper
{
    public partial class Form1 : Form
    {
        private delegate void UpdateDisplayCallback(IList<CEGitHubPullRequest> pullRequests);

        CEPullRequestManager _manager;

        public Form1()
        {
            InitializeComponent();
            _manager = new CEPullRequestManager();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void closedPullRequestsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _manager.UpdatePullRequests(ItemState.Closed);

            SafeDisplayPullRequests(_manager.PullRequests);
        }
        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _manager.UpdatePullRequests(ItemState.Open);

            SafeDisplayPullRequests(_manager.PullRequests);
        }

        void SafeDisplayPullRequests(IList<CEGitHubPullRequest> requests)
        {
            UpdateDisplayCallback cb = new UpdateDisplayCallback(DisplayPullRequests);
            this.Invoke(cb, new object[] { requests });
        }
        void DisplayPullRequests(IList<CEGitHubPullRequest> requests)
        {
            var sb = new StringBuilder();

            foreach (var item in _manager.PullRequests)
            {
                sb.AppendLine(item.GitHubId + ": " + item.Title + ": " + item.Status);
            }

            output.Text += sb.ToString() + "\r\n";
            Console.WriteLine(sb.ToString() + "\r\n");
        }

        void GetBuilds()
        {
            try
            {
                var tc = new TeamCityService.TeamCity();
                var builds = tc.GetBuilds();

                var sb = new StringBuilder();

                sb.AppendLine("--- Builds ---");
                foreach (var item in builds.OrderBy(b=>b.number))
                {
                    sb.AppendLine(item.number + " " + item.id + " " +  item.branchName + " " + item.state + " " + item.status);
                }

                output.Text += sb.ToString() + "\r\n";
                Console.WriteLine(sb.ToString() + "\r\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void buildsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetBuilds();
        }


        void GetBranches()
        {
            try
            {
                var tc = new TeamCityService.TeamCity();
                var branches = tc.GetBranches();

                var sb = new StringBuilder();

                if (null != branches)
                {
                    sb.AppendLine("--- Branches ---");
                    foreach (var item in branches)
                    {
                        //sb.AppendLine(item.number + " " + item.branchName + " " + item.state + " " + item.status);
                        sb.AppendLine(item.ToString());
                    }
                }
                else
                {
                    sb.AppendLine("No Branches");
                }
                output.Text += sb.ToString() + "\r\n";
                Console.WriteLine(sb.ToString() + "\r\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void branchesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetBranches();
        }

        private void getRunningBuildsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetRunningBuilds();
        }
        void GetRunningBuilds()
        {
            try
            {
                var tc = new TeamCityService.TeamCity();
                var builds = tc.GetRunningBuilds();

                var sb = new StringBuilder();

                sb.AppendLine("--- Running Builds ---");
                foreach (var item in builds.OrderBy(b => b.number))
                {
                    sb.AppendLine(item.number + " " + item.id + " " + item.branchName + " " + item.state + " " + item.status + " " + item.percentageComplete);
                }

                output.Text += sb.ToString() + "\r\n";
                Console.WriteLine(sb.ToString() + "\r\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

    }
}
