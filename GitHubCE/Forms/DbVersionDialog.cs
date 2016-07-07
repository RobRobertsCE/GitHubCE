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
                var projectPath = Path.GetFileName(VersionHelper.UpgradeProjectFolder.TrimEnd('\\'));
                var projectNode = tvPending.Nodes.Add(projectPath);

                FileInfo projectFileInfo = new FileInfo(VersionHelper.UpgradeProjectVbProjectFile);
                var projectFileNode = projectNode.Nodes.Add(projectFileInfo.Name);
                projectFileNode.Tag = projectFileInfo;

                var minorVersionFolderPath = Path.GetFileName(VersionHelper.MinorVersionFolder.TrimEnd('\\'));
                var minorVersionNode = projectNode.Nodes.Add(minorVersionFolderPath);

                foreach (var minorFolderItem in Directory.GetFileSystemEntries(VersionHelper.MinorVersionFolder, "*.*"))
                {
                    if (Directory.Exists(minorFolderItem))
                    {
                        DirectoryInfo di = new DirectoryInfo(minorFolderItem);
                        var node = minorVersionNode.Nodes.Add(di.Name);
                        node.Tag = di;
                        if (di.Name.EndsWith("100"))
                        {
                            node.ForeColor = Color.Black;
                        }
                        else
                        {
                            node.ForeColor = Color.Gray;
                        }
                        foreach (var directoryFile in di.GetFiles())
                        {
                            var fileNode = node.Nodes.Add(directoryFile.Name);
                            fileNode.Tag = directoryFile;
                            if (di.Name.Contains("100"))
                            {
                                fileNode.ForeColor = Color.Black;
                            }
                            else
                            {
                                fileNode.ForeColor = Color.Gray;
                            }
                        }
                    }
                }

                foreach (var item in Directory.GetFileSystemEntries(VersionHelper.MinorVersionFolder, "*.vb"))
                {
                    if (File.Exists(item))
                    {
                        FileInfo fi = new FileInfo(item);
                        var node = minorVersionNode.Nodes.Add(fi.Name);
                        node.Tag = fi;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void tsbRunProcess_Click(object sender, EventArgs e)
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

        private void tvPending_DoubleClick(object sender, EventArgs e)
        {

        }
    }
}
