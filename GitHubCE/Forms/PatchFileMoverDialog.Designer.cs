namespace GitHubCE.Forms
{
    partial class PatchFileMoverDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PatchFileMoverDialog));
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.lblError = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlMessages = new System.Windows.Forms.Panel();
            this.txtMessages = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbValidate = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbMoveFiles = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbBackups = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbPatchFolder = new System.Windows.Forms.ToolStripButton();
            this.tsbBinFolder = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbPatchNotes = new System.Windows.Forms.ToolStripButton();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.lvDestination = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ilPatchFileMover = new System.Windows.Forms.ImageList(this.components);
            this.lvSource = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlBottom.SuspendLayout();
            this.pnlMessages.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.lblError);
            this.pnlBottom.Controls.Add(this.btnClose);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 429);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(982, 53);
            this.pnlBottom.TabIndex = 0;
            // 
            // lblError
            // 
            this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.DarkRed;
            this.lblError.Location = new System.Drawing.Point(12, 6);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(878, 33);
            this.lblError.TabIndex = 1;
            this.lblError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnClose.Location = new System.Drawing.Point(896, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(74, 33);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlMessages
            // 
            this.pnlMessages.Controls.Add(this.txtMessages);
            this.pnlMessages.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlMessages.Location = new System.Drawing.Point(0, 322);
            this.pnlMessages.Name = "pnlMessages";
            this.pnlMessages.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.pnlMessages.Size = new System.Drawing.Size(982, 107);
            this.pnlMessages.TabIndex = 1;
            // 
            // txtMessages
            // 
            this.txtMessages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMessages.Location = new System.Drawing.Point(0, 2);
            this.txtMessages.Multiline = true;
            this.txtMessages.Name = "txtMessages";
            this.txtMessages.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtMessages.Size = new System.Drawing.Size(982, 105);
            this.txtMessages.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbRefresh,
            this.toolStripSeparator2,
            this.tsbValidate,
            this.toolStripSeparator1,
            this.tsbMoveFiles,
            this.toolStripSeparator3,
            this.tsbBackups,
            this.toolStripSeparator4,
            this.tsbPatchFolder,
            this.tsbBinFolder,
            this.toolStripSeparator5,
            this.tsbPatchNotes});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(982, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbRefresh
            // 
            this.tsbRefresh.Image = global::GitHubCE.Properties.Resources._112_RefreshArrow_Blue_32x42_72;
            this.tsbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRefresh.Name = "tsbRefresh";
            this.tsbRefresh.Size = new System.Drawing.Size(66, 22);
            this.tsbRefresh.Text = "Refresh";
            this.tsbRefresh.Click += new System.EventHandler(this.tsbRefresh_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbValidate
            // 
            this.tsbValidate.Image = global::GitHubCE.Properties.Resources._005_Task_32x42_72;
            this.tsbValidate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbValidate.Name = "tsbValidate";
            this.tsbValidate.Size = new System.Drawing.Size(69, 22);
            this.tsbValidate.Text = "Validate";
            this.tsbValidate.Click += new System.EventHandler(this.tsbValidate_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbMoveFiles
            // 
            this.tsbMoveFiles.Image = global::GitHubCE.Properties.Resources.Move;
            this.tsbMoveFiles.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMoveFiles.Name = "tsbMoveFiles";
            this.tsbMoveFiles.Size = new System.Drawing.Size(83, 22);
            this.tsbMoveFiles.Text = "Move Files";
            this.tsbMoveFiles.Click += new System.EventHandler(this.tsbMoveFiles_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbBackups
            // 
            this.tsbBackups.Image = global::GitHubCE.Properties.Resources.Import;
            this.tsbBackups.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbBackups.Name = "tsbBackups";
            this.tsbBackups.Size = new System.Drawing.Size(71, 22);
            this.tsbBackups.Text = "Backups";
            this.tsbBackups.Click += new System.EventHandler(this.tsbBackups_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbPatchFolder
            // 
            this.tsbPatchFolder.Image = global::GitHubCE.Properties.Resources.Network_Folder;
            this.tsbPatchFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPatchFolder.Name = "tsbPatchFolder";
            this.tsbPatchFolder.Size = new System.Drawing.Size(93, 22);
            this.tsbPatchFolder.Text = "Patch Folder";
            this.tsbPatchFolder.Click += new System.EventHandler(this.tsbPatchFolder_Click);
            // 
            // tsbBinFolder
            // 
            this.tsbBinFolder.Image = global::GitHubCE.Properties.Resources.FolderOpen_32x32_72;
            this.tsbBinFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbBinFolder.Name = "tsbBinFolder";
            this.tsbBinFolder.Size = new System.Drawing.Size(80, 22);
            this.tsbBinFolder.Text = "Bin Folder";
            this.tsbBinFolder.Click += new System.EventHandler(this.tsbBinFolder_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbPatchNotes
            // 
            this.tsbPatchNotes.Image = global::GitHubCE.Properties.Resources.Generic_Document;
            this.tsbPatchNotes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPatchNotes.Name = "tsbPatchNotes";
            this.tsbPatchNotes.Size = new System.Drawing.Size(91, 22);
            this.tsbPatchNotes.Text = "Patch Notes";
            this.tsbPatchNotes.Click += new System.EventHandler(this.tsbPatchNotes_Click);
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 319);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(982, 3);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.SteelBlue;
            this.pnlTop.Controls.Add(this.splitter2);
            this.pnlTop.Controls.Add(this.lvDestination);
            this.pnlTop.Controls.Add(this.lvSource);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTop.Location = new System.Drawing.Point(0, 25);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(4);
            this.pnlTop.Size = new System.Drawing.Size(982, 294);
            this.pnlTop.TabIndex = 5;
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point(484, 4);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 286);
            this.splitter2.TabIndex = 2;
            this.splitter2.TabStop = false;
            // 
            // lvDestination
            // 
            this.lvDestination.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.lvDestination.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvDestination.Location = new System.Drawing.Point(484, 4);
            this.lvDestination.Name = "lvDestination";
            this.lvDestination.Size = new System.Drawing.Size(494, 286);
            this.lvDestination.SmallImageList = this.ilPatchFileMover;
            this.lvDestination.TabIndex = 1;
            this.lvDestination.UseCompatibleStateImageBehavior = false;
            this.lvDestination.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "File Name";
            this.columnHeader4.Width = 200;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Version";
            this.columnHeader5.Width = 100;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Last Write";
            this.columnHeader6.Width = 175;
            // 
            // ilPatchFileMover
            // 
            this.ilPatchFileMover.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilPatchFileMover.ImageStream")));
            this.ilPatchFileMover.TransparentColor = System.Drawing.Color.Transparent;
            this.ilPatchFileMover.Images.SetKeyName(0, "112_Plus_Green_16x16_72.png");
            this.ilPatchFileMover.Images.SetKeyName(1, "112_Plus_Orange_16x16_72.png");
            this.ilPatchFileMover.Images.SetKeyName(2, "Generic_Application.png");
            this.ilPatchFileMover.Images.SetKeyName(3, "Generic_Document.png");
            this.ilPatchFileMover.Images.SetKeyName(4, "107259_NewContentPage_32x32.png");
            this.ilPatchFileMover.Images.SetKeyName(5, "bulleted_list_options.png");
            this.ilPatchFileMover.Images.SetKeyName(6, "Import.png");
            this.ilPatchFileMover.Images.SetKeyName(7, "NewDocument_32x32.png");
            this.ilPatchFileMover.Images.SetKeyName(8, "Page.png");
            // 
            // lvSource
            // 
            this.lvSource.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvSource.Dock = System.Windows.Forms.DockStyle.Left;
            this.lvSource.Location = new System.Drawing.Point(4, 4);
            this.lvSource.Name = "lvSource";
            this.lvSource.Size = new System.Drawing.Size(480, 286);
            this.lvSource.SmallImageList = this.ilPatchFileMover;
            this.lvSource.TabIndex = 0;
            this.lvSource.UseCompatibleStateImageBehavior = false;
            this.lvSource.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "File Name";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Version";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Last Write";
            this.columnHeader3.Width = 175;
            // 
            // PatchFileMoverDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 482);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.pnlMessages);
            this.Controls.Add(this.pnlBottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "PatchFileMoverDialog";
            this.Text = "Patch File Mover";
            this.Load += new System.EventHandler(this.PatchFileMoverDialog_Load);
            this.pnlBottom.ResumeLayout(false);
            this.pnlMessages.ResumeLayout(false);
            this.pnlMessages.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel pnlMessages;
        private System.Windows.Forms.TextBox txtMessages;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbValidate;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbMoveFiles;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbRefresh;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.ListView lvDestination;
        private System.Windows.Forms.ListView lvSource;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ImageList ilPatchFileMover;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbBackups;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tsbPatchFolder;
        private System.Windows.Forms.ToolStripButton tsbBinFolder;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton tsbPatchNotes;
    }
}