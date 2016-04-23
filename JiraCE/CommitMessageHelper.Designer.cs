namespace JiraCE
{
    partial class CommitMessageHelper
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CommitMessageHelper));
            this.txtCommitMessage = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMotivation = new System.Windows.Forms.TextBox();
            this.txtModifications = new System.Windows.Forms.TextBox();
            this.txtResults = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.jiraTab = new System.Windows.Forms.TabPage();
            this.commitTab = new System.Windows.Forms.TabPage();
            this.previewTab = new System.Windows.Forms.TabPage();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.txtIssueNumber = new System.Windows.Forms.ToolStripTextBox();
            this.btnGet = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnBuild = new System.Windows.Forms.ToolStripButton();
            this.btnExit = new System.Windows.Forms.ToolStripButton();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.jiraIssueView1 = new JiraCE.JIRAIssueView();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCopy = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClear = new System.Windows.Forms.ToolStripButton();
            this.tabControl1.SuspendLayout();
            this.jiraTab.SuspendLayout();
            this.commitTab.SuspendLayout();
            this.previewTab.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCommitMessage
            // 
            this.txtCommitMessage.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtCommitMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCommitMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCommitMessage.Location = new System.Drawing.Point(0, 0);
            this.txtCommitMessage.Multiline = true;
            this.txtCommitMessage.Name = "txtCommitMessage";
            this.txtCommitMessage.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtCommitMessage.Size = new System.Drawing.Size(1006, 564);
            this.txtCommitMessage.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(5, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Motivation";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(5, 183);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Modifications";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(5, 291);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Results";
            // 
            // txtMotivation
            // 
            this.txtMotivation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMotivation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMotivation.Location = new System.Drawing.Point(5, 92);
            this.txtMotivation.Multiline = true;
            this.txtMotivation.Name = "txtMotivation";
            this.txtMotivation.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtMotivation.Size = new System.Drawing.Size(990, 82);
            this.txtMotivation.TabIndex = 7;
            // 
            // txtModifications
            // 
            this.txtModifications.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtModifications.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtModifications.Location = new System.Drawing.Point(5, 205);
            this.txtModifications.Multiline = true;
            this.txtModifications.Name = "txtModifications";
            this.txtModifications.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtModifications.Size = new System.Drawing.Size(990, 77);
            this.txtModifications.TabIndex = 8;
            // 
            // txtResults
            // 
            this.txtResults.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResults.Location = new System.Drawing.Point(5, 313);
            this.txtResults.Multiline = true;
            this.txtResults.Name = "txtResults";
            this.txtResults.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtResults.Size = new System.Drawing.Size(990, 77);
            this.txtResults.TabIndex = 9;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.jiraTab);
            this.tabControl1.Controls.Add(this.commitTab);
            this.tabControl1.Controls.Add(this.previewTab);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 25);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1014, 590);
            this.tabControl1.TabIndex = 17;
            // 
            // jiraTab
            // 
            this.jiraTab.Controls.Add(this.jiraIssueView1);
            this.jiraTab.Location = new System.Drawing.Point(4, 22);
            this.jiraTab.Name = "jiraTab";
            this.jiraTab.Padding = new System.Windows.Forms.Padding(3);
            this.jiraTab.Size = new System.Drawing.Size(1006, 564);
            this.jiraTab.TabIndex = 0;
            this.jiraTab.Text = "JIRA Issue";
            this.jiraTab.UseVisualStyleBackColor = true;
            // 
            // commitTab
            // 
            this.commitTab.BackColor = System.Drawing.Color.LightSteelBlue;
            this.commitTab.Controls.Add(this.label4);
            this.commitTab.Controls.Add(this.txtTitle);
            this.commitTab.Controls.Add(this.txtResults);
            this.commitTab.Controls.Add(this.txtModifications);
            this.commitTab.Controls.Add(this.label1);
            this.commitTab.Controls.Add(this.txtMotivation);
            this.commitTab.Controls.Add(this.label2);
            this.commitTab.Controls.Add(this.label3);
            this.commitTab.Location = new System.Drawing.Point(4, 22);
            this.commitTab.Name = "commitTab";
            this.commitTab.Padding = new System.Windows.Forms.Padding(3);
            this.commitTab.Size = new System.Drawing.Size(1006, 564);
            this.commitTab.TabIndex = 1;
            this.commitTab.Text = "Commit Notes";
            // 
            // previewTab
            // 
            this.previewTab.Controls.Add(this.txtCommitMessage);
            this.previewTab.Location = new System.Drawing.Point(4, 22);
            this.previewTab.Name = "previewTab";
            this.previewTab.Size = new System.Drawing.Size(1006, 564);
            this.previewTab.TabIndex = 2;
            this.previewTab.Text = "Preview";
            this.previewTab.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txtIssueNumber,
            this.btnGet,
            this.toolStripSeparator1,
            this.btnBuild,
            this.btnExit,
            this.toolStripSeparator2,
            this.btnCopy,
            this.toolStripSeparator3,
            this.btnClear});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1014, 25);
            this.toolStrip1.TabIndex = 18;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // txtIssueNumber
            // 
            this.txtIssueNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIssueNumber.Name = "txtIssueNumber";
            this.txtIssueNumber.Size = new System.Drawing.Size(100, 25);
            this.txtIssueNumber.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtIssueNumber_KeyUp);
            // 
            // btnGet
            // 
            this.btnGet.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnGet.Image = ((System.Drawing.Image)(resources.GetObject("btnGet.Image")));
            this.btnGet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(58, 22);
            this.btnGet.Text = "Get Issue";
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnBuild
            // 
            this.btnBuild.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnBuild.Image = ((System.Drawing.Image)(resources.GetObject("btnBuild.Image")));
            this.btnBuild.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBuild.Name = "btnBuild";
            this.btnBuild.Size = new System.Drawing.Size(134, 22);
            this.btnBuild.Text = "Build Commit Message";
            this.btnBuild.Click += new System.EventHandler(this.btnBuild_Click);
            // 
            // btnExit
            // 
            this.btnExit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(29, 22);
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(5, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Title";
            // 
            // txtTitle
            // 
            this.txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitle.Location = new System.Drawing.Point(5, 31);
            this.txtTitle.Multiline = true;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtTitle.Size = new System.Drawing.Size(990, 30);
            this.txtTitle.TabIndex = 11;
            // 
            // jiraIssueView1
            // 
            this.jiraIssueView1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.jiraIssueView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jiraIssueView1.Location = new System.Drawing.Point(3, 3);
            this.jiraIssueView1.Name = "jiraIssueView1";
            this.jiraIssueView1.Size = new System.Drawing.Size(1000, 558);
            this.jiraIssueView1.TabIndex = 16;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnCopy
            // 
            this.btnCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnCopy.Image = ((System.Drawing.Image)(resources.GetObject("btnCopy.Image")));
            this.btnCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(83, 22);
            this.btnCopy.Text = "Copy Preview";
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnClear
            // 
            this.btnClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(38, 22);
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // CommitMessageHelper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(1014, 615);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CommitMessageHelper";
            this.Text = "GitHub Commit Helper";
            this.tabControl1.ResumeLayout(false);
            this.jiraTab.ResumeLayout(false);
            this.commitTab.ResumeLayout(false);
            this.commitTab.PerformLayout();
            this.previewTab.ResumeLayout(false);
            this.previewTab.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtCommitMessage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMotivation;
        private System.Windows.Forms.TextBox txtModifications;
        private System.Windows.Forms.TextBox txtResults;
        private JIRAIssueView jiraIssueView1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage commitTab;
        private System.Windows.Forms.TabPage jiraTab;
        private System.Windows.Forms.TabPage previewTab;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripTextBox txtIssueNumber;
        private System.Windows.Forms.ToolStripButton btnGet;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnBuild;
        private System.Windows.Forms.ToolStripButton btnExit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnCopy;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnClear;
    }
}

