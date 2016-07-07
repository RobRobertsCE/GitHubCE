namespace GitHubCE.Forms
{
    partial class DbVersionDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DbVersionDialog));
            this.tvPending = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.tsbRunProcess = new System.Windows.Forms.ToolStripButton();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvPending
            // 
            this.tvPending.Dock = System.Windows.Forms.DockStyle.Left;
            this.tvPending.Location = new System.Drawing.Point(0, 0);
            this.tvPending.Name = "tvPending";
            this.tvPending.Size = new System.Drawing.Size(232, 452);
            this.tvPending.TabIndex = 1;
            this.tvPending.DoubleClick += new System.EventHandler(this.tvPending_DoubleClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtFile);
            this.panel1.Controls.Add(this.splitter1);
            this.panel1.Controls.Add(this.tvPending);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 49);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(633, 452);
            this.panel1.TabIndex = 3;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(633, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbRunProcess});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(633, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(232, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 452);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // tsbRunProcess
            // 
            this.tsbRunProcess.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRunProcess.Image = ((System.Drawing.Image)(resources.GetObject("tsbRunProcess.Image")));
            this.tsbRunProcess.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRunProcess.Name = "tsbRunProcess";
            this.tsbRunProcess.Size = new System.Drawing.Size(23, 22);
            this.tsbRunProcess.Text = "toolStripButton1";
            this.tsbRunProcess.Click += new System.EventHandler(this.tsbRunProcess_Click);
            // 
            // txtFile
            // 
            this.txtFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFile.Location = new System.Drawing.Point(235, 0);
            this.txtFile.Multiline = true;
            this.txtFile.Name = "txtFile";
            this.txtFile.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtFile.Size = new System.Drawing.Size(398, 452);
            this.txtFile.TabIndex = 4;
            // 
            // DbVersionDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 501);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "DbVersionDialog";
            this.Text = "Database Version Helper";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TreeView tvPending;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbRunProcess;
        private System.Windows.Forms.TextBox txtFile;
    }
}