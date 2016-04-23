namespace GitHubCE
{
    partial class SettingsDialog
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtGitHubOwner = new System.Windows.Forms.TextBox();
            this.txtGitHubUser = new System.Windows.Forms.TextBox();
            this.txtGitHubToken = new System.Windows.Forms.TextBox();
            this.txtJiraPassword = new System.Windows.Forms.TextBox();
            this.txtJiraUser = new System.Windows.Forms.TextBox();
            this.txtJiraURL = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lstRepos = new System.Windows.Forms.CheckedListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnRemoveRepo = new System.Windows.Forms.Button();
            this.btnAddRepo = new System.Windows.Forms.Button();
            this.txtAddRepo = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 421);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(510, 43);
            this.panel1.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(432, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 37);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(4, 4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 37);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(43, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "GitHub Owner:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "GitHub User Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(42, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "GitHub Token:";
            // 
            // txtGitHubOwner
            // 
            this.txtGitHubOwner.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGitHubOwner.Location = new System.Drawing.Point(142, 9);
            this.txtGitHubOwner.Name = "txtGitHubOwner";
            this.txtGitHubOwner.Size = new System.Drawing.Size(224, 22);
            this.txtGitHubOwner.TabIndex = 4;
            // 
            // txtGitHubUser
            // 
            this.txtGitHubUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGitHubUser.Location = new System.Drawing.Point(142, 37);
            this.txtGitHubUser.Name = "txtGitHubUser";
            this.txtGitHubUser.Size = new System.Drawing.Size(224, 22);
            this.txtGitHubUser.TabIndex = 5;
            // 
            // txtGitHubToken
            // 
            this.txtGitHubToken.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGitHubToken.Location = new System.Drawing.Point(142, 65);
            this.txtGitHubToken.Name = "txtGitHubToken";
            this.txtGitHubToken.Size = new System.Drawing.Size(356, 22);
            this.txtGitHubToken.TabIndex = 6;
            // 
            // txtJiraPassword
            // 
            this.txtJiraPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJiraPassword.Location = new System.Drawing.Point(142, 149);
            this.txtJiraPassword.Name = "txtJiraPassword";
            this.txtJiraPassword.Size = new System.Drawing.Size(224, 22);
            this.txtJiraPassword.TabIndex = 12;
            // 
            // txtJiraUser
            // 
            this.txtJiraUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJiraUser.Location = new System.Drawing.Point(142, 121);
            this.txtJiraUser.Name = "txtJiraUser";
            this.txtJiraUser.Size = new System.Drawing.Size(224, 22);
            this.txtJiraUser.TabIndex = 11;
            // 
            // txtJiraURL
            // 
            this.txtJiraURL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJiraURL.Location = new System.Drawing.Point(142, 93);
            this.txtJiraURL.Name = "txtJiraURL";
            this.txtJiraURL.Size = new System.Drawing.Size(356, 22);
            this.txtJiraURL.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(33, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "JIRA Password:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(24, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "JIRA User Name:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(66, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 16);
            this.label6.TabIndex = 7;
            this.label6.Text = "JIRA URL:";
            // 
            // lstRepos
            // 
            this.lstRepos.FormattingEnabled = true;
            this.lstRepos.Location = new System.Drawing.Point(142, 177);
            this.lstRepos.Name = "lstRepos";
            this.lstRepos.Size = new System.Drawing.Size(355, 199);
            this.lstRepos.TabIndex = 13;
            this.lstRepos.SelectedIndexChanged += new System.EventHandler(this.lstRepos_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(68, 177);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 16);
            this.label7.TabIndex = 14;
            this.label7.Text = "Repo List:";
            // 
            // btnRemoveRepo
            // 
            this.btnRemoveRepo.Enabled = false;
            this.btnRemoveRepo.Location = new System.Drawing.Point(427, 383);
            this.btnRemoveRepo.Name = "btnRemoveRepo";
            this.btnRemoveRepo.Size = new System.Drawing.Size(70, 27);
            this.btnRemoveRepo.TabIndex = 15;
            this.btnRemoveRepo.Text = "Remove";
            this.btnRemoveRepo.UseVisualStyleBackColor = true;
            this.btnRemoveRepo.Click += new System.EventHandler(this.btnRemoveRepo_Click);
            // 
            // btnAddRepo
            // 
            this.btnAddRepo.Enabled = false;
            this.btnAddRepo.Location = new System.Drawing.Point(351, 383);
            this.btnAddRepo.Name = "btnAddRepo";
            this.btnAddRepo.Size = new System.Drawing.Size(70, 27);
            this.btnAddRepo.TabIndex = 16;
            this.btnAddRepo.Text = "Add";
            this.btnAddRepo.UseVisualStyleBackColor = true;
            this.btnAddRepo.Click += new System.EventHandler(this.btnAddRepo_Click);
            // 
            // txtAddRepo
            // 
            this.txtAddRepo.Location = new System.Drawing.Point(142, 386);
            this.txtAddRepo.Name = "txtAddRepo";
            this.txtAddRepo.Size = new System.Drawing.Size(199, 20);
            this.txtAddRepo.TabIndex = 17;
            this.txtAddRepo.TextChanged += new System.EventHandler(this.txtAddRepo_TextChanged);
            // 
            // SettingsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(510, 464);
            this.Controls.Add(this.txtAddRepo);
            this.Controls.Add(this.btnAddRepo);
            this.Controls.Add(this.btnRemoveRepo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lstRepos);
            this.Controls.Add(this.txtJiraPassword);
            this.Controls.Add(this.txtJiraUser);
            this.Controls.Add(this.txtJiraURL);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtGitHubToken);
            this.Controls.Add(this.txtGitHubUser);
            this.Controls.Add(this.txtGitHubOwner);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SettingsDialog";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsDialog_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtGitHubOwner;
        private System.Windows.Forms.TextBox txtGitHubUser;
        private System.Windows.Forms.TextBox txtGitHubToken;
        private System.Windows.Forms.TextBox txtJiraPassword;
        private System.Windows.Forms.TextBox txtJiraUser;
        private System.Windows.Forms.TextBox txtJiraURL;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckedListBox lstRepos;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnRemoveRepo;
        private System.Windows.Forms.Button btnAddRepo;
        private System.Windows.Forms.TextBox txtAddRepo;
    }
}