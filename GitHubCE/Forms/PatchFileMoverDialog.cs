using GitHubCE.Advantage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GitHubCE.Forms
{
    public partial class PatchFileMoverDialog : Form
    {
        #region fields
        bool _passedValidation = false;
        #endregion

        #region properties
        PatchHelper PatchHelper { get; set; }
        #endregion

        #region ctor / load
        public PatchFileMoverDialog()
        {
            InitializeComponent();
        }
        public PatchFileMoverDialog(PatchHelper patchHelper)
        {
            InitializeComponent();

            this.PatchHelper = patchHelper;
        }
        private void PatchFileMoverDialog_Load(object sender, EventArgs e)
        {
            ValidatePatch();
            RefreshLists();
        }
        #endregion

        #region refresh lists
        void RefreshLists()
        {
            PopulateSource();
            PopulateTarget();
        }
        void PopulateSource()
        {
            lvSource.Groups.Clear();
            var groupName = String.Format("{0} {1}", PatchHelper.RepoName, PatchHelper.RepoVersion);
            lvSource.Groups.Add(new ListViewGroup(groupName, HorizontalAlignment.Left));
            foreach (var sourceFile in PatchHelper.SourceAssemblies)
            {
                if (!sourceFile.Name.Contains("TestApp") && (sourceFile.Name.Trim() != "QueryMetadataEditor.exe"))
                {
                    var versionInfo = FileVersionInfo.GetVersionInfo(sourceFile.FullName);
                    var sourceFileInfo = new FileInfo(sourceFile.FullName);
                    var lvi =
                        new ListViewItem(new[]
                        {sourceFile.Name, versionInfo.FileVersion, sourceFileInfo.LastWriteTime.ToString()});
                    lvi.Group = lvSource.Groups[0];
                    lvi.ImageIndex = 7;
                    lvSource.Items.Add(lvi);
                }
            }
        }
        void PopulateTarget()
        {
            var filesBeingPatched = PatchHelper.SourceAssemblies.Where(f=>!f.Name.Contains("TestApp") && (f.Name.Trim() != "QueryMetadataEditor.exe")).Select(s => s.Name).ToList();

            lvDestination.Groups.Clear();

            lvDestination.Groups.Add(new ListViewGroup(Path.GetDirectoryName(PatchHelper.PatchFolder), HorizontalAlignment.Left));
            foreach (var patchFolderFile in Directory.GetFiles(PatchHelper.PatchFolder))
            {
                var versionInfo = FileVersionInfo.GetVersionInfo(patchFolderFile);
                var sourceFileInfo = new FileInfo(patchFolderFile);
                var lvi = new ListViewItem(new[] { Path.GetFileName(patchFolderFile), versionInfo.FileVersion, sourceFileInfo.LastWriteTime.ToString() });
                lvi.Group = lvDestination.Groups[0];
                if (patchFolderFile.EndsWith(".dll"))
                {
                    lvi.ImageIndex = 3;
                }
                else if (patchFolderFile.EndsWith(".exe"))
                {
                    lvi.ImageIndex = 2;
                }
                else if (patchFolderFile.EndsWith(".txt"))
                {
                    lvi.ImageIndex = 8;
                }
                else
                {
                    lvi.ImageIndex = 8;
                }

                // highlight files being patched.
                if (filesBeingPatched.Contains(Path.GetFileName(patchFolderFile)))
                {
                    lvi.BackColor = Color.Silver;
                    lvi.UseItemStyleForSubItems = true;
                }

                lvDestination.Items.Add(lvi);
            }
        }
        #endregion

        #region validate patch
        void ValidatePatch()
        {
            ClearError();
            tsbMoveFiles.Enabled = false;
            _passedValidation = false;

            var validationResults = PatchHelper.ValidatePatchProcess();

            StringBuilder sb = new StringBuilder();
            if (validationResults.IsValid)
            {
                sb.AppendLine("Validation Passed");
                tsbMoveFiles.Enabled = true;
                _passedValidation = true;
            }
            else
            {
                tsbMoveFiles.Enabled = false;
                _passedValidation = false;

                DisplayError("***** Validation Failed *****");
                foreach (var message in validationResults.Errors)
                    sb.AppendLine(message);
            }

            if (validationResults.HasDebugMessages)
            {
                sb.AppendLine("***** DEBUG *****");
                foreach (var message in validationResults.DebugMessages)
                {
                    sb.AppendLine(message);
                }
            }
            var validationReport = sb.ToString();
            Console.WriteLine(validationReport);
            DisplayMessage(validationReport);
        }
        #endregion

        #region update patch
        void UpdatePatchFiles()
        {
            try
            {
                if (!_passedValidation)
                {
                    DisplayMessage("Validate Before Running");
                    return;
                }

                // backup files.
                foreach (var patchFolderFile in Directory.GetFiles(PatchHelper.PatchFolder))
                {
                    var backupFileName = Path.Combine(PatchHelper.AssemblyBackupFolder, Path.GetFileName(patchFolderFile));
                    File.Copy(patchFolderFile, backupFileName);
                }

                // copy files
                foreach (var sourceFile in PatchHelper.SourceAssemblies)
                {
                    var patchFileName = Path.Combine(PatchHelper.PatchFolder, sourceFile.Name);
                    DisplayMessage(String.Format("***** COPYING {0} TO {1} *********", sourceFile.FullName, patchFileName));
                    File.Copy(sourceFile.FullName, patchFileName, true);
                }

                // refresh patch folder file list.
                PopulateTarget();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        void ShowBackups()
        {
            Process.Start(PatchHelper.AssemblyBackupFolder);
        }
        void ShowPatchFolder()
        {
            Process.Start(PatchHelper.PatchFolder);
        }
        void ShowBinFolder()
        {
            Process.Start(PatchHelper.BinFolder);
        }
        void OpenPatchNotes()
        {
            Process.Start(Path.Combine(PatchHelper.PatchFolder, "Patch Notes.txt"));
        }
        #endregion

        #region common
        void DisplayMessage(string message)
        {
            txtMessages.Text += message + "\r\n";
            txtMessages.SelectionStart = txtMessages.TextLength;
            txtMessages.ScrollToCaret();
        }
        void DisplayError(string errorMessage)
        {
            lblError.Text = errorMessage;
        }
        void ClearError()
        {
            lblError.Text = "";
        }
        void ExceptionHandler(Exception ex)
        {
            DisplayMessage(ex.Message);
            Console.WriteLine(ex.ToString());
        }
        #endregion

        #region button events
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbValidate_Click(object sender, EventArgs e)
        {
            ValidatePatch();
        }

        private void tsbMoveFiles_Click(object sender, EventArgs e)
        {
            UpdatePatchFiles();
        }

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            RefreshLists();
        }

        private void tsbBackups_Click(object sender, EventArgs e)
        {
            ShowBackups();
        }

        private void tsbPatchFolder_Click(object sender, EventArgs e)
        {
            ShowPatchFolder();
        }

        private void tsbBinFolder_Click(object sender, EventArgs e)
        {
            ShowBinFolder();
        }

        private void tsbPatchNotes_Click(object sender, EventArgs e)
        {
            OpenPatchNotes();
        }
        #endregion
    }
}
