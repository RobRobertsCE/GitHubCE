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
            this.pnlTop = new System.Windows.Forms.Panel();
            this.pnlMessagesAndComments = new System.Windows.Forms.Panel();
            this.pnlComments = new System.Windows.Forms.Panel();
            this.txtComments = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.pnlMessages = new System.Windows.Forms.Panel();
            this.txtCommitMessage = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.tabFiles = new System.Windows.Forms.TabControl();
            this.tpAssemblies = new System.Windows.Forms.TabPage();
            this.lstFiles = new System.Windows.Forms.ListBox();
            this.splitter3 = new System.Windows.Forms.Splitter();
            this.lstAssemblies = new System.Windows.Forms.ListBox();
            this.lnkPullRequest = new System.Windows.Forms.LinkLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbTimer = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbRefresh = new System.Windows.Forms.ToolStripButton();
            this.tsbClosed = new System.Windows.Forms.ToolStripButton();
            this.tsbAll = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbJIRAIssue = new System.Windows.Forms.ToolStripButton();
            this.tsbGitHubIssue = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbAdvantage = new System.Windows.Forms.ToolStripButton();
            this.tsbBamboo = new System.Windows.Forms.ToolStripButton();
            this.tsbPullRequests = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbOpenBinFolder = new System.Windows.Forms.ToolStripButton();
            this.btnDevReportsFolder = new System.Windows.Forms.ToolStripButton();
            this.tsbOpenPatchFolder = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClearGrid = new System.Windows.Forms.ToolStripButton();
            this.tsbOptions = new System.Windows.Forms.ToolStripButton();
            this.tsbExit = new System.Windows.Forms.ToolStripButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblLastUpdate = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblAppStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.notNewRequest = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmShow = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmClear = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmClose = new System.Windows.Forms.ToolStripMenuItem();
            this.splitter4 = new System.Windows.Forms.Splitter();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showOpenRequestsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showClosedRequestsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblWarning = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlTop.SuspendLayout();
            this.pnlMessagesAndComments.SuspendLayout();
            this.pnlComments.SuspendLayout();
            this.pnlMessages.SuspendLayout();
            this.tabFiles.SuspendLayout();
            this.tpAssemblies.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.notifyContextMenu.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvPullRequests
            // 
            this.lvPullRequests.BackColor = System.Drawing.Color.Linen;
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
            this.lvPullRequests.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lvPullRequests.FullRowSelect = true;
            this.lvPullRequests.GridLines = true;
            this.lvPullRequests.HideSelection = false;
            this.lvPullRequests.Location = new System.Drawing.Point(0, 296);
            this.lvPullRequests.Name = "lvPullRequests";
            this.lvPullRequests.Size = new System.Drawing.Size(1305, 210);
            this.lvPullRequests.TabIndex = 2;
            this.lvPullRequests.UseCompatibleStateImageBehavior = false;
            this.lvPullRequests.View = System.Windows.Forms.View.Details;
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
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.pnlMessagesAndComments);
            this.pnlTop.Controls.Add(this.splitter2);
            this.pnlTop.Controls.Add(this.tabFiles);
            this.pnlTop.Controls.Add(this.lnkPullRequest);
            this.pnlTop.Controls.Add(this.toolStrip1);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTop.Location = new System.Drawing.Point(0, 24);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1305, 269);
            this.pnlTop.TabIndex = 3;
            // 
            // pnlMessagesAndComments
            // 
            this.pnlMessagesAndComments.Controls.Add(this.pnlComments);
            this.pnlMessagesAndComments.Controls.Add(this.splitter1);
            this.pnlMessagesAndComments.Controls.Add(this.pnlMessages);
            this.pnlMessagesAndComments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMessagesAndComments.Location = new System.Drawing.Point(0, 43);
            this.pnlMessagesAndComments.Name = "pnlMessagesAndComments";
            this.pnlMessagesAndComments.Size = new System.Drawing.Size(935, 226);
            this.pnlMessagesAndComments.TabIndex = 9;
            // 
            // pnlComments
            // 
            this.pnlComments.Controls.Add(this.txtComments);
            this.pnlComments.Controls.Add(this.label2);
            this.pnlComments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlComments.Location = new System.Drawing.Point(333, 0);
            this.pnlComments.Name = "pnlComments";
            this.pnlComments.Size = new System.Drawing.Size(602, 226);
            this.pnlComments.TabIndex = 11;
            // 
            // txtComments
            // 
            this.txtComments.AcceptsReturn = true;
            this.txtComments.AcceptsTab = true;
            this.txtComments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtComments.Location = new System.Drawing.Point(0, 20);
            this.txtComments.Multiline = true;
            this.txtComments.Name = "txtComments";
            this.txtComments.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtComments.Size = new System.Drawing.Size(602, 206);
            this.txtComments.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Gray;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(602, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Comments";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(330, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 226);
            this.splitter1.TabIndex = 9;
            this.splitter1.TabStop = false;
            // 
            // pnlMessages
            // 
            this.pnlMessages.Controls.Add(this.txtCommitMessage);
            this.pnlMessages.Controls.Add(this.label1);
            this.pnlMessages.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMessages.Location = new System.Drawing.Point(0, 0);
            this.pnlMessages.Name = "pnlMessages";
            this.pnlMessages.Size = new System.Drawing.Size(330, 226);
            this.pnlMessages.TabIndex = 10;
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
            this.txtCommitMessage.Size = new System.Drawing.Size(330, 206);
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
            this.label1.Text = "Message";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter2.Location = new System.Drawing.Point(935, 43);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 226);
            this.splitter2.TabIndex = 11;
            this.splitter2.TabStop = false;
            // 
            // tabFiles
            // 
            this.tabFiles.Controls.Add(this.tpAssemblies);
            this.tabFiles.Dock = System.Windows.Forms.DockStyle.Right;
            this.tabFiles.Location = new System.Drawing.Point(938, 43);
            this.tabFiles.Name = "tabFiles";
            this.tabFiles.SelectedIndex = 0;
            this.tabFiles.Size = new System.Drawing.Size(367, 226);
            this.tabFiles.TabIndex = 10;
            // 
            // tpAssemblies
            // 
            this.tpAssemblies.Controls.Add(this.lstFiles);
            this.tpAssemblies.Controls.Add(this.splitter3);
            this.tpAssemblies.Controls.Add(this.lstAssemblies);
            this.tpAssemblies.Location = new System.Drawing.Point(4, 22);
            this.tpAssemblies.Name = "tpAssemblies";
            this.tpAssemblies.Padding = new System.Windows.Forms.Padding(3);
            this.tpAssemblies.Size = new System.Drawing.Size(359, 200);
            this.tpAssemblies.TabIndex = 1;
            this.tpAssemblies.Text = "Files & Assemblies ";
            this.tpAssemblies.UseVisualStyleBackColor = true;
            // 
            // lstFiles
            // 
            this.lstFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstFiles.FormattingEnabled = true;
            this.lstFiles.Location = new System.Drawing.Point(3, 88);
            this.lstFiles.Name = "lstFiles";
            this.lstFiles.Size = new System.Drawing.Size(353, 109);
            this.lstFiles.TabIndex = 9;
            // 
            // splitter3
            // 
            this.splitter3.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter3.Location = new System.Drawing.Point(3, 85);
            this.splitter3.Name = "splitter3";
            this.splitter3.Size = new System.Drawing.Size(353, 3);
            this.splitter3.TabIndex = 8;
            this.splitter3.TabStop = false;
            // 
            // lstAssemblies
            // 
            this.lstAssemblies.Dock = System.Windows.Forms.DockStyle.Top;
            this.lstAssemblies.FormattingEnabled = true;
            this.lstAssemblies.Location = new System.Drawing.Point(3, 3);
            this.lstAssemblies.Name = "lstAssemblies";
            this.lstAssemblies.Size = new System.Drawing.Size(353, 82);
            this.lstAssemblies.TabIndex = 7;
            // 
            // lnkPullRequest
            // 
            this.lnkPullRequest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lnkPullRequest.Dock = System.Windows.Forms.DockStyle.Top;
            this.lnkPullRequest.Location = new System.Drawing.Point(0, 25);
            this.lnkPullRequest.Name = "lnkPullRequest";
            this.lnkPullRequest.Size = new System.Drawing.Size(1305, 18);
            this.lnkPullRequest.TabIndex = 7;
            this.lnkPullRequest.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkPullRequest_LinkClicked);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbTimer,
            this.toolStripSeparator1,
            this.tsbRefresh,
            this.tsbClosed,
            this.tsbAll,
            this.toolStripSeparator2,
            this.tsbJIRAIssue,
            this.tsbGitHubIssue,
            this.toolStripSeparator3,
            this.tsbAdvantage,
            this.tsbBamboo,
            this.tsbPullRequests,
            this.toolStripSeparator4,
            this.tsbOpenBinFolder,
            this.btnDevReportsFolder,
            this.tsbOpenPatchFolder,
            this.toolStripSeparator7,
            this.btnClearGrid,
            this.tsbOptions,
            this.tsbExit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1305, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbTimer
            // 
            this.tsbTimer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbTimer.Image = ((System.Drawing.Image)(resources.GetObject("tsbTimer.Image")));
            this.tsbTimer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbTimer.Name = "tsbTimer";
            this.tsbTimer.Size = new System.Drawing.Size(69, 22);
            this.tsbTimer.Text = "Start Timer";
            this.tsbTimer.Click += new System.EventHandler(this.tsbTimer_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbRefresh
            // 
            this.tsbRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbRefresh.Image = ((System.Drawing.Image)(resources.GetObject("tsbRefresh.Image")));
            this.tsbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRefresh.Name = "tsbRefresh";
            this.tsbRefresh.Size = new System.Drawing.Size(40, 22);
            this.tsbRefresh.Text = "Open";
            this.tsbRefresh.Click += new System.EventHandler(this.tsbRefresh_Click);
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
            // tsbJIRAIssue
            // 
            this.tsbJIRAIssue.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbJIRAIssue.Image = ((System.Drawing.Image)(resources.GetObject("tsbJIRAIssue.Image")));
            this.tsbJIRAIssue.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbJIRAIssue.Name = "tsbJIRAIssue";
            this.tsbJIRAIssue.Size = new System.Drawing.Size(33, 22);
            this.tsbJIRAIssue.Text = "JIRA";
            this.tsbJIRAIssue.Click += new System.EventHandler(this.tsbJIRAIssue_Click);
            // 
            // tsbGitHubIssue
            // 
            this.tsbGitHubIssue.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbGitHubIssue.Image = ((System.Drawing.Image)(resources.GetObject("tsbGitHubIssue.Image")));
            this.tsbGitHubIssue.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbGitHubIssue.Name = "tsbGitHubIssue";
            this.tsbGitHubIssue.Size = new System.Drawing.Size(49, 22);
            this.tsbGitHubIssue.Text = "GitHub";
            this.tsbGitHubIssue.Click += new System.EventHandler(this.tsbGitHubIssue_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbAdvantage
            // 
            this.tsbAdvantage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbAdvantage.Image = ((System.Drawing.Image)(resources.GetObject("tsbAdvantage.Image")));
            this.tsbAdvantage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAdvantage.Name = "tsbAdvantage";
            this.tsbAdvantage.Size = new System.Drawing.Size(68, 22);
            this.tsbAdvantage.Text = "Advantage";
            this.tsbAdvantage.Click += new System.EventHandler(this.tsbAdvantage_Click);
            // 
            // tsbBamboo
            // 
            this.tsbBamboo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbBamboo.Image = ((System.Drawing.Image)(resources.GetObject("tsbBamboo.Image")));
            this.tsbBamboo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbBamboo.Name = "tsbBamboo";
            this.tsbBamboo.Size = new System.Drawing.Size(56, 22);
            this.tsbBamboo.Text = "Bamboo";
            this.tsbBamboo.Click += new System.EventHandler(this.tsbBamboo_Click);
            // 
            // tsbPullRequests
            // 
            this.tsbPullRequests.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbPullRequests.Image = ((System.Drawing.Image)(resources.GetObject("tsbPullRequests.Image")));
            this.tsbPullRequests.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPullRequests.Name = "tsbPullRequests";
            this.tsbPullRequests.Size = new System.Drawing.Size(113, 22);
            this.tsbPullRequests.Text = "Open Pull Requests";
            this.tsbPullRequests.Click += new System.EventHandler(this.tsbPullRequests_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
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
            // btnClearGrid
            // 
            this.btnClearGrid.Image = global::GitHubCE.Properties.Resources.RefreshDocViewHS;
            this.btnClearGrid.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClearGrid.Name = "btnClearGrid";
            this.btnClearGrid.Size = new System.Drawing.Size(79, 22);
            this.btnClearGrid.Text = "Clear Grid";
            this.btnClearGrid.Click += new System.EventHandler(this.btnClearGrid_Click);
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
            // tsbExit
            // 
            this.tsbExit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbExit.Image = global::GitHubCE.Properties.Resources.delete;
            this.tsbExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExit.Name = "tsbExit";
            this.tsbExit.Size = new System.Drawing.Size(45, 22);
            this.tsbExit.Text = "Exit";
            this.tsbExit.Click += new System.EventHandler(this.tsbExit_Click);
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
            this.lblAppStatus,
            this.lblWarning});
            this.statusStrip1.Location = new System.Drawing.Point(0, 506);
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
            // lblAppStatus
            // 
            this.lblAppStatus.Name = "lblAppStatus";
            this.lblAppStatus.Size = new System.Drawing.Size(12, 17);
            this.lblAppStatus.Text = "-";
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
            // splitter4
            // 
            this.splitter4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter4.Location = new System.Drawing.Point(0, 293);
            this.splitter4.Name = "splitter4";
            this.splitter4.Size = new System.Drawing.Size(1305, 3);
            this.splitter4.TabIndex = 5;
            this.splitter4.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.filterToolStripMenuItem});
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
            // lblWarning
            // 
            this.lblWarning.AutoSize = false;
            this.lblWarning.BackColor = System.Drawing.SystemColors.Control;
            this.lblWarning.ForeColor = System.Drawing.Color.White;
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(1047, 17);
            this.lblWarning.Spring = true;
            // 
            // GitHubHelper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1305, 528);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.splitter4);
            this.Controls.Add(this.lvPullRequests);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "GitHubHelper";
            this.Text = "GitHub Helper";
            this.Load += new System.EventHandler(this.GitHubHelper_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlMessagesAndComments.ResumeLayout(false);
            this.pnlComments.ResumeLayout(false);
            this.pnlComments.PerformLayout();
            this.pnlMessages.ResumeLayout(false);
            this.pnlMessages.PerformLayout();
            this.tabFiles.ResumeLayout(false);
            this.tpAssemblies.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.notifyContextMenu.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
        private System.Windows.Forms.TextBox txtCommitMessage;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbRefresh;
        private System.Windows.Forms.ToolStripButton tsbTimer;
        private System.Windows.Forms.LinkLabel lnkPullRequest;
        private System.Windows.Forms.TextBox txtComments;
        private System.Windows.Forms.Panel pnlMessagesAndComments;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel pnlComments;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlMessages;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblLastUpdate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbClosed;
        private System.Windows.Forms.ToolStripButton tsbAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ColumnHeader chDbUpgrade;
        private System.Windows.Forms.ToolStripButton tsbJIRAIssue;
        private System.Windows.Forms.ToolStripButton tsbGitHubIssue;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbAdvantage;
        private System.Windows.Forms.ToolStripButton tsbBamboo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tsbPullRequests;
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
        private System.Windows.Forms.ListBox lstFiles;
        private System.Windows.Forms.Splitter splitter3;
        private System.Windows.Forms.Splitter splitter4;
        private System.Windows.Forms.ToolStripButton btnClearGrid;
        private System.Windows.Forms.ToolStripButton tsbOptions;
        private System.Windows.Forms.ToolStripButton tsbExit;
        private System.Windows.Forms.ToolStripStatusLabel lblAppStatus;
        private System.Windows.Forms.ToolStripButton btnDevReportsFolder;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showOpenRequestsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showClosedRequestsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel lblWarning;
    }
}

