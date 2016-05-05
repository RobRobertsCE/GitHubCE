using GitHubCE.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GitHubCE.Forms
{
    public partial class DbVersionDialog : Form
    {
        public DbVersionHelper VersionHelper { get; set; }

        public DbVersionDialog()
        {
            InitializeComponent();

            VersionHelper = new DbVersionHelper("Advantage", "rroberts");

            PopulateControls();
        }

        void PopulateControls()
        {
            try
            {
                var root = tvPending.Nodes.Add(Path.GetFileName(VersionHelper.PendingVersionBuildFolder));
                foreach (var buildFile in VersionHelper.PendingBuildFiles)
                {
                    root.Nodes.Add(Path.GetFileName(buildFile));
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var result = VersionHelper.UpdateProject();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
