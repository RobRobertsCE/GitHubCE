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
            this.button1 = new System.Windows.Forms.Button();
            this.tvPending = new System.Windows.Forms.TreeView();
            this.tvNew = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 36);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tvPending
            // 
            this.tvPending.Location = new System.Drawing.Point(11, 71);
            this.tvPending.Name = "tvPending";
            this.tvPending.Size = new System.Drawing.Size(204, 242);
            this.tvPending.TabIndex = 1;
            // 
            // tvNew
            // 
            this.tvNew.Location = new System.Drawing.Point(417, 71);
            this.tvNew.Name = "tvNew";
            this.tvNew.Size = new System.Drawing.Size(204, 242);
            this.tvNew.TabIndex = 2;
            // 
            // DbVersionDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 337);
            this.Controls.Add(this.tvNew);
            this.Controls.Add(this.tvPending);
            this.Controls.Add(this.button1);
            this.Name = "DbVersionDialog";
            this.Text = "Database Version Helper";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TreeView tvPending;
        private System.Windows.Forms.TreeView tvNew;
    }
}