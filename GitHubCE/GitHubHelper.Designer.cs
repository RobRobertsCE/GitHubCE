namespace GitHubCE
{
    partial class GitHubHelper
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GitHubHelper));
            this.lvPullRequests = new System.Windows.Forms.ListView();
            this.chId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chRepo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chUpdated = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chJiraNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chBranch = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDbUpgrade = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chState = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDeveloper = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chJiraStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ctxListView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openJIRAIssueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openPullRequestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.patchFileMoverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.cancelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.pnlAutoProcessSteps = new System.Windows.Forms.Panel();
            this.txtAutoProcess = new System.Windows.Forms.TextBox();
            this.ctxSystemMessages = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.copyAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.pnlMessages = new System.Windows.Forms.Panel();
            this.txtCommitMessage = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.tabFiles = new System.Windows.Forms.TabControl();
            this.tpAssemblies = new System.Windows.Forms.TabPage();
            this.lstAssemblies = new System.Windows.Forms.ListBox();
            this.tpFiles = new System.Windows.Forms.TabPage();
            this.lstFiles = new System.Windows.Forms.ListBox();
            this.lnkPullRequest = new System.Windows.Forms.LinkLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbTimer = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbOpen = new System.Windows.Forms.ToolStripButton();
            this.tsbClosed = new System.Windows.Forms.ToolStripButton();
            this.tsbAll = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.cboDaysBack = new System.Windows.Forms.ToolStripComboBox();
            this.btnClearGrid = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbOpenBinFolder = new System.Windows.Forms.ToolStripButton();
            this.btnDevReportsFolder = new System.Windows.Forms.ToolStripButton();
            this.tsbOpenPatchFolder = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbOptions = new System.Windows.Forms.ToolStripButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblLastUpdate = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblWarning = new System.Windows.Forms.ToolStripStatusLabel();
            this.notNewRequest = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmShow = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmClear = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmClose = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showOpenRequestsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showClosedRequestsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.patchHelperToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buildRepoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dllsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.executablesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dbVersionHelperToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.tsbAdvantage = new System.Windows.Forms.ToolStripButton();
            this.tsbBamboo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbJIRAIssue = new System.Windows.Forms.ToolStripButton();
            this.tsbGitHubIssue = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbPullRequests = new System.Windows.Forms.ToolStripButton();
            this.tlsSearchToolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.txtJiraSearchNumber = new System.Windows.Forms.ToolStripTextBox();
            this.tsbJiraSearch = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbBuildAssemblies = new System.Windows.Forms.ToolStripButton();
            this.tsbBuildExecutables = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbPull = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbRunCommand = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.cmbBranches = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.splitter3 = new System.Windows.Forms.Splitter();
            this.scriptOutputDisplay1 = new CEScriptRunner.Views.ScriptOutputDisplay();
            this.cboCommand = new System.Windows.Forms.ToolStripComboBox();
            this.ctxListView.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlAutoProcessSteps.SuspendLayout();
            this.ctxSystemMessages.SuspendLayout();
            this.pnlMessages.SuspendLayout();
            this.tabFiles.SuspendLayout();
            this.tpAssemblies.SuspendLayout();
            this.tpFiles.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.notifyContextMenu.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.tlsSearchToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvPullRequests
            // 
            this.lvPullRequests.BackColor = System.Drawing.SystemColors.Info;
            this.lvPullRequests.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chId,
            this.chRepo,
            this.chUpdated,
            this.chTitle,
            this.chJiraNumber,
            this.chBranch,
            this.chVersion,
            this.chDbUpgrade,
            this.chState,
            this.chDeveloper,
            this.chJiraStatus});
            this.lvPullRequests.ContextMenuStrip = this.ctxListView;
            this.lvPullRequests.Dock = System.Windows.Forms.DockStyle.Top;
            this.lvPullRequests.FullRowSelect = true;
            this.lvPullRequests.GridLines = true;
            this.lvPullRequests.HideSelection = false;
            this.lvPullRequests.Location = new System.Drawing.Point(0, 265);
            this.lvPullRequests.Name = "lvPullRequests";
            this.lvPullRequests.Size = new System.Drawing.Size(1305, 135);
            this.lvPullRequests.TabIndex = 2;
            this.lvPullRequests.UseCompatibleStateImageBehavior = false;
            this.lvPullRequests.View = System.Windows.Forms.View.Details;
            this.lvPullRequests.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvPullRequests_ColumnClick);
            this.lvPullRequests.SelectedIndexChanged += new System.EventHandler(this.lvPullRequests_SelectedIndexChanged);
            this.lvPullRequests.DoubleClick += new System.EventHandler(this.lvPullRequests_DoubleClick);
            // 
            // chId
            // 
            this.chId.Text = "Id";
            // 
            // chRepo
            // 
            this.chRepo.Text = "Repo";
            this.chRepo.Width = 150;
            // 
            // chUpdated
            // 
            this.chUpdated.Text = "Last Update";
            this.chUpdated.Width = 150;
            // 
            // chTitle
            // 
            this.chTitle.Text = "Title";
            this.chTitle.Width = 292;
            // 
            // chJiraNumber
            // 
            this.chJiraNumber.Text = "JIRA #";
            this.chJiraNumber.Width = 59;
            // 
            // chBranch
            // 
            this.chBranch.Text = "Branch";
            this.chBranch.Width = 100;
            // 
            // chVersion
            // 
            this.chVersion.Text = "Version";
            this.chVersion.Width = 75;
            // 
            // chDbUpgrade
            // 
            this.chDbUpgrade.Text = "DB #";
            // 
            // chState
            // 
            this.chState.Text = "State";
            // 
            // chDeveloper
            // 
            this.chDeveloper.Text = "Developer";
            this.chDeveloper.Width = 104;
            // 
            // chJiraStatus
            // 
            this.chJiraStatus.Text = "Jira Status";
            this.chJiraStatus.Width = 125;
            // 
            // ctxListView
            // 
            this.ctxListView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openJIRAIssueToolStripMenuItem,
            this.openPullRequestToolStripMenuItem,
            this.patchFileMoverToolStripMenuItem,
            this.toolStripMenuItem2,
            this.cancelToolStripMenuItem});
            this.ctxListView.Name = "ctxListView";
            this.ctxListView.Size = new System.Drawing.Size(172, 98);
            // 
            // openJIRAIssueToolStripMenuItem
            // 
            this.openJIRAIssueToolStripMenuItem.Name = "openJIRAIssueToolStripMenuItem";
            this.openJIRAIssueToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.openJIRAIssueToolStripMenuItem.Text = "Open JIRA Issue";
            this.openJIRAIssueToolStripMenuItem.Click += new System.EventHandler(this.openJIRAIssueToolStripMenuItem_Click);
            // 
            // openPullRequestToolStripMenuItem
            // 
            this.openPullRequestToolStripMenuItem.Name = "openPullRequestToolStripMenuItem";
            this.openPullRequestToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.openPullRequestToolStripMenuItem.Text = "Open Pull Request";
            this.openPullRequestToolStripMenuItem.Click += new System.EventHandler(this.openPullRequestToolStripMenuItem_Click);
            // 
            // patchFileMoverToolStripMenuItem
            // 
            this.patchFileMoverToolStripMenuItem.Name = "patchFileMoverToolStripMenuItem";
            this.patchFileMoverToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.patchFileMoverToolStripMenuItem.Text = "Patch File Mover";
            this.patchFileMoverToolStripMenuItem.Click += new System.EventHandler(this.patchFileMoverToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(168, 6);
            // 
            // cancelToolStripMenuItem
            // 
            this.cancelToolStripMenuItem.Name = "cancelToolStripMenuItem";
            this.cancelToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.cancelToolStripMenuItem.Text = "Cancel";
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.pnlAutoProcessSteps);
            this.pnlTop.Controls.Add(this.splitter1);
            this.pnlTop.Controls.Add(this.pnlMessages);
            this.pnlTop.Controls.Add(this.splitter2);
            this.pnlTop.Controls.Add(this.tabFiles);
            this.pnlTop.Controls.Add(this.lnkPullRequest);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1305, 166);
            this.pnlTop.TabIndex = 3;
            // 
            // pnlAutoProcessSteps
            // 
            this.pnlAutoProcessSteps.Controls.Add(this.txtAutoProcess);
            this.pnlAutoProcessSteps.Controls.Add(this.label2);
            this.pnlAutoProcessSteps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAutoProcessSteps.Location = new System.Drawing.Point(703, 18);
            this.pnlAutoProcessSteps.Name = "pnlAutoProcessSteps";
            this.pnlAutoProcessSteps.Size = new System.Drawing.Size(602, 148);
            this.pnlAutoProcessSteps.TabIndex = 14;
            // 
            // txtAutoProcess
            // 
            this.txtAutoProcess.ContextMenuStrip = this.ctxSystemMessages;
            this.txtAutoProcess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAutoProcess.Location = new System.Drawing.Point(0, 20);
            this.txtAutoProcess.Multiline = true;
            this.txtAutoProcess.Name = "txtAutoProcess";
            this.txtAutoProcess.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtAutoProcess.Size = new System.Drawing.Size(602, 128);
            this.txtAutoProcess.TabIndex = 5;
            // 
            // ctxSystemMessages
            // 
            this.ctxSystemMessages.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearToolStripMenuItem,
            this.toolStripMenuItem3,
            this.copyAllToolStripMenuItem});
            this.ctxSystemMessages.Name = "ctxSystemMessages";
            this.ctxSystemMessages.Size = new System.Drawing.Size(156, 54);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.clearToolStripMenuItem.Text = "Clear Messages";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(152, 6);
            // 
            // copyAllToolStripMenuItem
            // 
            this.copyAllToolStripMenuItem.Name = "copyAllToolStripMenuItem";
            this.copyAllToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.copyAllToolStripMenuItem.Text = "Copy All";
            this.copyAllToolStripMenuItem.Click += new System.EventHandler(this.copyAllToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.RoyalBlue;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(602, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "System Messages";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(700, 18);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 148);
            this.splitter1.TabIndex = 13;
            this.splitter1.TabStop = false;
            // 
            // pnlMessages
            // 
            this.pnlMessages.Controls.Add(this.txtCommitMessage);
            this.pnlMessages.Controls.Add(this.label1);
            this.pnlMessages.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMessages.Location = new System.Drawing.Point(370, 18);
            this.pnlMessages.Name = "pnlMessages";
            this.pnlMessages.Size = new System.Drawing.Size(330, 148);
            this.pnlMessages.TabIndex = 12;
            // 
            // txtCommitMessage
            // 
            this.txtCommitMessage.AcceptsReturn = true;
            this.txtCommitMessage.AcceptsTab = true;
            this.txtCommitMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCommitMessage.Location = new System.Drawing.Point(0, 20);
            this.txtCommitMessage.Multiline = true;
            this.txtCommitMessage.Name = "txtCommitMessage";
            this.txtCommitMessage.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtCommitMessage.Size = new System.Drawing.Size(330, 128);
            this.txtCommitMessage.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Gray;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(330, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Commit Message";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point(367, 18);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 148);
            this.splitter2.TabIndex = 11;
            this.splitter2.TabStop = false;
            // 
            // tabFiles
            // 
            this.tabFiles.Controls.Add(this.tpAssemblies);
            this.tabFiles.Controls.Add(this.tpFiles);
            this.tabFiles.Dock = System.Windows.Forms.DockStyle.Left;
            this.tabFiles.Location = new System.Drawing.Point(0, 18);
            this.tabFiles.Name = "tabFiles";
            this.tabFiles.SelectedIndex = 0;
            this.tabFiles.Size = new System.Drawing.Size(367, 148);
            this.tabFiles.TabIndex = 10;
            // 
            // tpAssemblies
            // 
            this.tpAssemblies.Controls.Add(this.lstAssemblies);
            this.tpAssemblies.Location = new System.Drawing.Point(4, 22);
            this.tpAssemblies.Name = "tpAssemblies";
            this.tpAssemblies.Padding = new System.Windows.Forms.Padding(3);
            this.tpAssemblies.Size = new System.Drawing.Size(359, 122);
            this.tpAssemblies.TabIndex = 1;
            this.tpAssemblies.Text = "Assemblies ";
            this.tpAssemblies.UseVisualStyleBackColor = true;
            // 
            // lstAssemblies
            // 
            this.lstAssemblies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstAssemblies.FormattingEnabled = true;
            this.lstAssemblies.Location = new System.Drawing.Point(3, 3);
            this.lstAssemblies.Name = "lstAssemblies";
            this.lstAssemblies.Size = new System.Drawing.Size(353, 116);
            this.lstAssemblies.TabIndex = 7;
            // 
            // tpFiles
            // 
            this.tpFiles.Controls.Add(this.lstFiles);
            this.tpFiles.Location = new System.Drawing.Point(4, 22);
            this.tpFiles.Name = "tpFiles";
            this.tpFiles.Padding = new System.Windows.Forms.Padding(3);
            this.tpFiles.Size = new System.Drawing.Size(359, 122);
            this.tpFiles.TabIndex = 2;
            this.tpFiles.Text = "Files";
            this.tpFiles.UseVisualStyleBackColor = true;
            // 
            // lstFiles
            // 
            this.lstFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstFiles.FormattingEnabled = true;
            this.lstFiles.Location = new System.Drawing.Point(3, 3);
            this.lstFiles.Name = "lstFiles";
            this.lstFiles.Size = new System.Drawing.Size(353, 116);
            this.lstFiles.TabIndex = 10;
            // 
            // lnkPullRequest
            // 
            this.lnkPullRequest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lnkPullRequest.Dock = System.Windows.Forms.DockStyle.Top;
            this.lnkPullRequest.Location = new System.Drawing.Point(0, 0);
            this.lnkPullRequest.Name = "lnkPullRequest";
            this.lnkPullRequest.Size = new System.Drawing.Size(1305, 18);
            this.lnkPullRequest.TabIndex = 7;
            this.lnkPullRequest.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkPullRequest_LinkClicked);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbTimer,
            this.toolStripSeparator1,
            this.tsbOpen,
            this.tsbClosed,
            this.tsbAll,
            this.toolStripSeparator2,
            this.toolStripLabel1,
            this.cboDaysBack,
            this.btnClearGrid,
            this.toolStripSeparator6,
            this.tsbOpenBinFolder,
            this.btnDevReportsFolder,
            this.tsbOpenPatchFolder,
            this.toolStripSeparator7,
            this.tsbOptions});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(781, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbTimer
            // 
            this.tsbTimer.Image = global::GitHubCE.Properties.Resources._112_RefreshArrow_Green_32x32_72;
            this.tsbTimer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbTimer.Name = "tsbTimer";
            this.tsbTimer.Size = new System.Drawing.Size(85, 22);
            this.tsbTimer.Text = "Start Timer";
            this.tsbTimer.Click += new System.EventHandler(this.tsbTimer_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbOpen
            // 
            this.tsbOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbOpen.Image = ((System.Drawing.Image)(resources.GetObject("tsbOpen.Image")));
            this.tsbOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOpen.Name = "tsbOpen";
            this.tsbOpen.Size = new System.Drawing.Size(40, 22);
            this.tsbOpen.Text = "Open";
            this.tsbOpen.Click += new System.EventHandler(this.tsbRefresh_Click);
            // 
            // tsbClosed
            // 
            this.tsbClosed.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbClosed.Image = ((System.Drawing.Image)(resources.GetObject("tsbClosed.Image")));
            this.tsbClosed.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClosed.Name = "tsbClosed";
            this.tsbClosed.Size = new System.Drawing.Size(47, 22);
            this.tsbClosed.Text = "Closed";
            this.tsbClosed.Click += new System.EventHandler(this.tsbAllToday_Click);
            // 
            // tsbAll
            // 
            this.tsbAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbAll.Image = ((System.Drawing.Image)(resources.GetObject("tsbAll.Image")));
            this.tsbAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAll.Name = "tsbAll";
            this.tsbAll.Size = new System.Drawing.Size(25, 22);
            this.tsbAll.Text = "All";
            this.tsbAll.Click += new System.EventHandler(this.tsbAll_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(63, 22);
            this.toolStripLabel1.Text = "Days Back:";
            // 
            // cboDaysBack
            // 
            this.cboDaysBack.AutoSize = false;
            this.cboDaysBack.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDaysBack.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "7",
            "14",
            "21",
            "31",
            "60",
            "90"});
            this.cboDaysBack.Name = "cboDaysBack";
            this.cboDaysBack.Size = new System.Drawing.Size(50, 23);
            this.cboDaysBack.SelectedIndexChanged += new System.EventHandler(this.cboDaysBack_SelectedIndexChanged);
            // 
            // btnClearGrid
            // 
            this.btnClearGrid.Image = global::GitHubCE.Properties.Resources.RefreshDocViewHS;
            this.btnClearGrid.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClearGrid.Name = "btnClearGrid";
            this.btnClearGrid.Size = new System.Drawing.Size(79, 22);
            this.btnClearGrid.Text = "Clear Grid";
            this.btnClearGrid.Click += new System.EventHandler(this.btnClearGrid_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbOpenBinFolder
            // 
            this.tsbOpenBinFolder.Image = global::GitHubCE.Properties.Resources.OpenSelectedItemHS;
            this.tsbOpenBinFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOpenBinFolder.Name = "tsbOpenBinFolder";
            this.tsbOpenBinFolder.Size = new System.Drawing.Size(80, 22);
            this.tsbOpenBinFolder.Text = "Bin Folder";
            this.tsbOpenBinFolder.ToolTipText = "Open bin folder";
            this.tsbOpenBinFolder.Click += new System.EventHandler(this.tsbOpenBinFolder_Click);
            // 
            // btnDevReportsFolder
            // 
            this.btnDevReportsFolder.Image = global::GitHubCE.Properties.Resources.ActivityReports;
            this.btnDevReportsFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDevReportsFolder.Name = "btnDevReportsFolder";
            this.btnDevReportsFolder.Size = new System.Drawing.Size(112, 22);
            this.btnDevReportsFolder.Text = "Custom Reports";
            this.btnDevReportsFolder.Click += new System.EventHandler(this.btnDevReportsFolder_Click);
            // 
            // tsbOpenPatchFolder
            // 
            this.tsbOpenPatchFolder.Image = global::GitHubCE.Properties.Resources.base_server;
            this.tsbOpenPatchFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOpenPatchFolder.Name = "tsbOpenPatchFolder";
            this.tsbOpenPatchFolder.Size = new System.Drawing.Size(93, 22);
            this.tsbOpenPatchFolder.Text = "Patch Folder";
            this.tsbOpenPatchFolder.ToolTipText = "Open patch folder";
            this.tsbOpenPatchFolder.Click += new System.EventHandler(this.tsbOpenPatchFolder_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbOptions
            // 
            this.tsbOptions.Image = global::GitHubCE.Properties.Resources.settings_32;
            this.tsbOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOptions.Name = "tsbOptions";
            this.tsbOptions.Size = new System.Drawing.Size(69, 22);
            this.tsbOptions.Text = "Options";
            this.tsbOptions.Click += new System.EventHandler(this.tsbOptions_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 30000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblLastUpdate,
            this.lblWarning});
            this.statusStrip1.Location = new System.Drawing.Point(0, 604);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1305, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblLastUpdate
            // 
            this.lblLastUpdate.AutoSize = false;
            this.lblLastUpdate.Name = "lblLastUpdate";
            this.lblLastUpdate.Size = new System.Drawing.Size(200, 17);
            this.lblLastUpdate.Text = "Last Update: -";
            this.lblLastUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblWarning
            // 
            this.lblWarning.AutoSize = false;
            this.lblWarning.BackColor = System.Drawing.SystemColors.Control;
            this.lblWarning.ForeColor = System.Drawing.Color.White;
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(1090, 17);
            this.lblWarning.Spring = true;
            // 
            // notNewRequest
            // 
            this.notNewRequest.BalloonTipText = "New Pull Request";
            this.notNewRequest.BalloonTipTitle = "Message from GitHub";
            this.notNewRequest.ContextMenuStrip = this.notifyContextMenu;
            this.notNewRequest.Icon = ((System.Drawing.Icon)(resources.GetObject("notNewRequest.Icon")));
            this.notNewRequest.Text = "New Pull Request!";
            this.notNewRequest.Visible = true;
            this.notNewRequest.DoubleClick += new System.EventHandler(this.notNewRequest_DoubleClick);
            this.notNewRequest.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notNewRequest_MouseDoubleClick);
            // 
            // notifyContextMenu
            // 
            this.notifyContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmShow,
            this.tsmClear,
            this.toolStripSeparator5,
            this.tsmClose});
            this.notifyContextMenu.Name = "notifyContextMenu";
            this.notifyContextMenu.Size = new System.Drawing.Size(118, 76);
            // 
            // tsmShow
            // 
            this.tsmShow.Name = "tsmShow";
            this.tsmShow.Size = new System.Drawing.Size(117, 22);
            this.tsmShow.Text = "Activate";
            this.tsmShow.Click += new System.EventHandler(this.tsmShow_Click);
            // 
            // tsmClear
            // 
            this.tsmClear.Name = "tsmClear";
            this.tsmClear.Size = new System.Drawing.Size(117, 22);
            this.tsmClear.Text = "Clear";
            this.tsmClear.Click += new System.EventHandler(this.tsmClear_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(114, 6);
            // 
            // tsmClose
            // 
            this.tsmClose.Name = "tsmClose";
            this.tsmClose.Size = new System.Drawing.Size(117, 22);
            this.tsmClose.Text = "Close";
            this.tsmClose.Click += new System.EventHandler(this.tsmClose_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.filterToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1305, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(89, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // filterToolStripMenuItem
            // 
            this.filterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showOpenRequestsToolStripMenuItem,
            this.showClosedRequestsToolStripMenuItem});
            this.filterToolStripMenuItem.Name = "filterToolStripMenuItem";
            this.filterToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.filterToolStripMenuItem.Text = "Filter";
            // 
            // showOpenRequestsToolStripMenuItem
            // 
            this.showOpenRequestsToolStripMenuItem.CheckOnClick = true;
            this.showOpenRequestsToolStripMenuItem.Name = "showOpenRequestsToolStripMenuItem";
            this.showOpenRequestsToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.showOpenRequestsToolStripMenuItem.Text = "Show Open Requests";
            this.showOpenRequestsToolStripMenuItem.CheckedChanged += new System.EventHandler(this.showOpenRequestsToolStripMenuItem_CheckedChanged);
            // 
            // showClosedRequestsToolStripMenuItem
            // 
            this.showClosedRequestsToolStripMenuItem.CheckOnClick = true;
            this.showClosedRequestsToolStripMenuItem.Name = "showClosedRequestsToolStripMenuItem";
            this.showClosedRequestsToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.showClosedRequestsToolStripMenuItem.Text = "Show Closed Requests";
            this.showClosedRequestsToolStripMenuItem.CheckedChanged += new System.EventHandler(this.showClosedRequestsToolStripMenuItem_CheckedChanged);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem,
            this.patchHelperToolStripMenuItem,
            this.buildRepoToolStripMenuItem,
            this.dbVersionHelperToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.optionsToolStripMenuItem.Text = "&Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // patchHelperToolStripMenuItem
            // 
            this.patchHelperToolStripMenuItem.Name = "patchHelperToolStripMenuItem";
            this.patchHelperToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.patchHelperToolStripMenuItem.Text = "Patch File Mover";
            this.patchHelperToolStripMenuItem.Click += new System.EventHandler(this.patchHelperToolStripMenuItem_Click);
            // 
            // buildRepoToolStripMenuItem
            // 
            this.buildRepoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dllsToolStripMenuItem,
            this.executablesToolStripMenuItem});
            this.buildRepoToolStripMenuItem.Name = "buildRepoToolStripMenuItem";
            this.buildRepoToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.buildRepoToolStripMenuItem.Text = "Build Repo";
            // 
            // dllsToolStripMenuItem
            // 
            this.dllsToolStripMenuItem.Name = "dllsToolStripMenuItem";
            this.dllsToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.dllsToolStripMenuItem.Text = "Dll\'s";
            this.dllsToolStripMenuItem.Click += new System.EventHandler(this.dllsToolStripMenuItem_Click);
            // 
            // executablesToolStripMenuItem
            // 
            this.executablesToolStripMenuItem.Name = "executablesToolStripMenuItem";
            this.executablesToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.executablesToolStripMenuItem.Text = "Executables";
            this.executablesToolStripMenuItem.Click += new System.EventHandler(this.executablesToolStripMenuItem_Click);
            // 
            // dbVersionHelperToolStripMenuItem
            // 
            this.dbVersionHelperToolStripMenuItem.Name = "dbVersionHelperToolStripMenuItem";
            this.dbVersionHelperToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.dbVersionHelperToolStripMenuItem.Text = "DbVersion Helper";
            this.dbVersionHelperToolStripMenuItem.Click += new System.EventHandler(this.dbVersionHelperToolStripMenuItem_Click);
            // 
            // toolStripContainer1
            // 
            this.toolStripContainer1.BottomToolStripPanelVisible = false;
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.pnlTop);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1305, 166);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolStripContainer1.LeftToolStripPanelVisible = false;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 24);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.RightToolStripPanelVisible = false;
            this.toolStripContainer1.Size = new System.Drawing.Size(1305, 241);
            this.toolStripContainer1.TabIndex = 8;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip2);
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.tlsSearchToolStrip);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAdvantage,
            this.tsbBamboo,
            this.toolStripSeparator9,
            this.tsbJIRAIssue,
            this.tsbGitHubIssue,
            this.toolStripSeparator10,
            this.tsbPullRequests});
            this.toolStrip2.Location = new System.Drawing.Point(3, 25);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(423, 25);
            this.toolStrip2.TabIndex = 6;
            // 
            // tsbAdvantage
            // 
            this.tsbAdvantage.Image = global::GitHubCE.Properties.Resources.default_space_logo_256;
            this.tsbAdvantage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAdvantage.Name = "tsbAdvantage";
            this.tsbAdvantage.Size = new System.Drawing.Size(84, 22);
            this.tsbAdvantage.Text = "Advantage";
            this.tsbAdvantage.Click += new System.EventHandler(this.tsbAdvantage_Click_1);
            // 
            // tsbBamboo
            // 
            this.tsbBamboo.Image = global::GitHubCE.Properties.Resources.logoBambooPNG;
            this.tsbBamboo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbBamboo.Name = "tsbBamboo";
            this.tsbBamboo.Size = new System.Drawing.Size(72, 22);
            this.tsbBamboo.Text = "Bamboo";
            this.tsbBamboo.Click += new System.EventHandler(this.tsbBamboo_Click_1);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbJIRAIssue
            // 
            this.tsbJIRAIssue.Image = global::GitHubCE.Properties.Resources.JIRA;
            this.tsbJIRAIssue.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbJIRAIssue.Name = "tsbJIRAIssue";
            this.tsbJIRAIssue.Size = new System.Drawing.Size(49, 22);
            this.tsbJIRAIssue.Text = "JIRA";
            this.tsbJIRAIssue.Click += new System.EventHandler(this.tsbJIRAIssue_Click_1);
            // 
            // tsbGitHubIssue
            // 
            this.tsbGitHubIssue.Image = global::GitHubCE.Properties.Resources.Git;
            this.tsbGitHubIssue.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbGitHubIssue.Name = "tsbGitHubIssue";
            this.tsbGitHubIssue.Size = new System.Drawing.Size(65, 22);
            this.tsbGitHubIssue.Text = "GitHub";
            this.tsbGitHubIssue.Click += new System.EventHandler(this.tsbGitHubIssue_Click_1);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbPullRequests
            // 
            this.tsbPullRequests.Image = global::GitHubCE.Properties.Resources.Git_Icon_Black;
            this.tsbPullRequests.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPullRequests.Name = "tsbPullRequests";
            this.tsbPullRequests.Size = new System.Drawing.Size(129, 22);
            this.tsbPullRequests.Text = "Open Pull Requests";
            this.tsbPullRequests.Click += new System.EventHandler(this.tsbPullRequests_Click_1);
            // 
            // tlsSearchToolStrip
            // 
            this.tlsSearchToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.tlsSearchToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.txtJiraSearchNumber,
            this.tsbJiraSearch,
            this.toolStripSeparator3,
            this.tsbBuildAssemblies,
            this.tsbBuildExecutables,
            this.toolStripSeparator4,
            this.tsbPull,
            this.toolStripSeparator8,
            this.cboCommand,
            this.tsbRunCommand,
            this.toolStripSeparator11,
            this.cmbBranches,
            this.toolStripButton1});
            this.tlsSearchToolStrip.Location = new System.Drawing.Point(3, 50);
            this.tlsSearchToolStrip.Name = "tlsSearchToolStrip";
            this.tlsSearchToolStrip.Size = new System.Drawing.Size(1261, 25);
            this.tlsSearchToolStrip.TabIndex = 7;
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(95, 22);
            this.toolStripLabel2.Text = "Search for JIRA #";
            // 
            // txtJiraSearchNumber
            // 
            this.txtJiraSearchNumber.Name = "txtJiraSearchNumber";
            this.txtJiraSearchNumber.Size = new System.Drawing.Size(100, 25);
            this.txtJiraSearchNumber.TextChanged += new System.EventHandler(this.txtJiraSearchNumber_TextChanged);
            // 
            // tsbJiraSearch
            // 
            this.tsbJiraSearch.Image = global::GitHubCE.Properties.Resources.SearchWebHS;
            this.tsbJiraSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbJiraSearch.Name = "tsbJiraSearch";
            this.tsbJiraSearch.Size = new System.Drawing.Size(62, 22);
            this.tsbJiraSearch.Text = "Search";
            this.tsbJiraSearch.Click += new System.EventHandler(this.tsbJiraSearch_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbBuildAssemblies
            // 
            this.tsbBuildAssemblies.Image = global::GitHubCE.Properties.Resources.BuildSolution_104_32;
            this.tsbBuildAssemblies.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbBuildAssemblies.Name = "tsbBuildAssemblies";
            this.tsbBuildAssemblies.Size = new System.Drawing.Size(116, 22);
            this.tsbBuildAssemblies.Text = "Build Assemblies";
            this.tsbBuildAssemblies.Click += new System.EventHandler(this.tsbBuildAssemblies_Click);
            // 
            // tsbBuildExecutables
            // 
            this.tsbBuildExecutables.Image = global::GitHubCE.Properties.Resources.BuildSolution_104_24;
            this.tsbBuildExecutables.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbBuildExecutables.Name = "tsbBuildExecutables";
            this.tsbBuildExecutables.Size = new System.Drawing.Size(118, 22);
            this.tsbBuildExecutables.Text = "Build Executables";
            this.tsbBuildExecutables.Click += new System.EventHandler(this.tsbBuildExecutables_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbPull
            // 
            this.tsbPull.Image = ((System.Drawing.Image)(resources.GetObject("tsbPull.Image")));
            this.tsbPull.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPull.Name = "tsbPull";
            this.tsbPull.Size = new System.Drawing.Size(47, 22);
            this.tsbPull.Text = "Pull";
            this.tsbPull.Click += new System.EventHandler(this.tsbPull_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbRunCommand
            // 
            this.tsbRunCommand.Image = global::GitHubCE.Properties.Resources.startwithoutdebugging_6556;
            this.tsbRunCommand.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRunCommand.Name = "tsbRunCommand";
            this.tsbRunCommand.Size = new System.Drawing.Size(108, 22);
            this.tsbRunCommand.Text = "Run Command";
            this.tsbRunCommand.Click += new System.EventHandler(this.tsbRunCommand_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(6, 25);
            // 
            // cmbBranches
            // 
            this.cmbBranches.Items.AddRange(new object[] {
            "develop",
            "master"});
            this.cmbBranches.Name = "cmbBranches";
            this.cmbBranches.Size = new System.Drawing.Size(121, 25);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::GitHubCE.Properties.Resources.BuildSolution_104;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(171, 22);
            this.toolStripButton1.Text = "Checkout and Build Branch";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // splitter3
            // 
            this.splitter3.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter3.Location = new System.Drawing.Point(0, 400);
            this.splitter3.Name = "splitter3";
            this.splitter3.Size = new System.Drawing.Size(1305, 3);
            this.splitter3.TabIndex = 9;
            this.splitter3.TabStop = false;
            // 
            // scriptOutputDisplay1
            // 
            this.scriptOutputDisplay1.DisplayFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scriptOutputDisplay1.DisplayForeColor = System.Drawing.Color.Gainsboro;
            this.scriptOutputDisplay1.DisplayPromptColor = System.Drawing.Color.WhiteSmoke;
            this.scriptOutputDisplay1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scriptOutputDisplay1.Location = new System.Drawing.Point(0, 403);
            this.scriptOutputDisplay1.Name = "scriptOutputDisplay1";
            this.scriptOutputDisplay1.Padding = new System.Windows.Forms.Padding(4);
            this.scriptOutputDisplay1.Prompt = null;
            this.scriptOutputDisplay1.PromptFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.scriptOutputDisplay1.Size = new System.Drawing.Size(1305, 201);
            this.scriptOutputDisplay1.TabIndex = 10;
            // 
            // cboCommand
            // 
            this.cboCommand.AutoSize = false;
            this.cboCommand.Name = "cboCommand";
            this.cboCommand.Size = new System.Drawing.Size(250, 25);
            this.cboCommand.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCommand_KeyUp);
            // 
            // GitHubHelper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1305, 626);
            this.Controls.Add(this.scriptOutputDisplay1);
            this.Controls.Add(this.splitter3);
            this.Controls.Add(this.lvPullRequests);
            this.Controls.Add(this.toolStripContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "GitHubHelper";
            this.Text = "GitHub Helper";
            this.Load += new System.EventHandler(this.GitHubHelper_Load);
            this.ctxListView.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlAutoProcessSteps.ResumeLayout(false);
            this.pnlAutoProcessSteps.PerformLayout();
            this.ctxSystemMessages.ResumeLayout(false);
            this.pnlMessages.ResumeLayout(false);
            this.pnlMessages.PerformLayout();
            this.tabFiles.ResumeLayout(false);
            this.tpAssemblies.ResumeLayout(false);
            this.tpFiles.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.notifyContextMenu.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.tlsSearchToolStrip.ResumeLayout(false);
            this.tlsSearchToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView lvPullRequests;
        private System.Windows.Forms.ColumnHeader chId;
        private System.Windows.Forms.ColumnHeader chTitle;
        private System.Windows.Forms.ColumnHeader chJiraNumber;
        private System.Windows.Forms.ColumnHeader chBranch;
        private System.Windows.Forms.ColumnHeader chState;
        private System.Windows.Forms.ColumnHeader chDeveloper;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.ColumnHeader chUpdated;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbOpen;
        private System.Windows.Forms.ToolStripButton tsbTimer;
        private System.Windows.Forms.LinkLabel lnkPullRequest;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblLastUpdate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbClosed;
        private System.Windows.Forms.ToolStripButton tsbAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ColumnHeader chDbUpgrade;
        private System.Windows.Forms.NotifyIcon notNewRequest;
        private System.Windows.Forms.ContextMenuStrip notifyContextMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmShow;
        private System.Windows.Forms.ToolStripMenuItem tsmClear;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem tsmClose;
        private System.Windows.Forms.ColumnHeader chJiraStatus;
        private System.Windows.Forms.ColumnHeader chVersion;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.TabControl tabFiles;
        private System.Windows.Forms.TabPage tpAssemblies;
        private System.Windows.Forms.ListBox lstAssemblies;
        private System.Windows.Forms.ToolStripButton tsbOpenBinFolder;
        private System.Windows.Forms.ToolStripButton tsbOpenPatchFolder;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ColumnHeader chRepo;
        private System.Windows.Forms.ToolStripButton tsbOptions;
        private System.Windows.Forms.ToolStripButton btnDevReportsFolder;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showOpenRequestsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showClosedRequestsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel lblWarning;
        private System.Windows.Forms.ContextMenuStrip ctxListView;
        private System.Windows.Forms.ToolStripMenuItem openJIRAIssueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openPullRequestToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem cancelToolStripMenuItem;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox cboDaysBack;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.Panel pnlMessages;
        private System.Windows.Forms.TextBox txtCommitMessage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton tsbAdvantage;
        private System.Windows.Forms.ToolStripButton tsbBamboo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripButton tsbJIRAIssue;
        private System.Windows.Forms.ToolStripButton tsbGitHubIssue;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripButton tsbPullRequests;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton btnClearGrid;
        private System.Windows.Forms.TabPage tpFiles;
        private System.Windows.Forms.ListBox lstFiles;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel pnlAutoProcessSteps;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAutoProcess;
        private System.Windows.Forms.Splitter splitter3;
        private System.Windows.Forms.ToolStripMenuItem patchHelperToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip ctxSystemMessages;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem copyAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buildRepoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dllsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem executablesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem patchFileMoverToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dbVersionHelperToolStripMenuItem;
        private System.Windows.Forms.ToolStrip tlsSearchToolStrip;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox txtJiraSearchNumber;
        private System.Windows.Forms.ToolStripButton tsbJiraSearch;
        private CEScriptRunner.Views.ScriptOutputDisplay scriptOutputDisplay1;
        private System.Windows.Forms.ToolStripButton tsbBuildAssemblies;
        private System.Windows.Forms.ToolStripButton tsbBuildExecutables;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tsbPull;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton tsbRunCommand;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripComboBox cmbBranches;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripComboBox cboCommand;
    }
}

