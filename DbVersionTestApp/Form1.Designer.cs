namespace DbVersionTestApp
{
    partial class Form1
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
            this.btnDbVersion = new System.Windows.Forms.Button();
            this.btnVersionCalculator = new System.Windows.Forms.Button();
            this.dtVersionDate = new System.Windows.Forms.DateTimePicker();
            this.txtVersion = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnDbVersion
            // 
            this.btnDbVersion.Location = new System.Drawing.Point(21, 14);
            this.btnDbVersion.Name = "btnDbVersion";
            this.btnDbVersion.Size = new System.Drawing.Size(138, 27);
            this.btnDbVersion.TabIndex = 0;
            this.btnDbVersion.Text = "DB Version";
            this.btnDbVersion.UseVisualStyleBackColor = true;
            this.btnDbVersion.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnVersionCalculator
            // 
            this.btnVersionCalculator.Location = new System.Drawing.Point(21, 47);
            this.btnVersionCalculator.Name = "btnVersionCalculator";
            this.btnVersionCalculator.Size = new System.Drawing.Size(138, 27);
            this.btnVersionCalculator.TabIndex = 1;
            this.btnVersionCalculator.Text = "Get Version On Date";
            this.btnVersionCalculator.UseVisualStyleBackColor = true;
            this.btnVersionCalculator.Click += new System.EventHandler(this.btnVersionCalculator_Click);
            // 
            // dtVersionDate
            // 
            this.dtVersionDate.Location = new System.Drawing.Point(165, 54);
            this.dtVersionDate.Name = "dtVersionDate";
            this.dtVersionDate.Size = new System.Drawing.Size(200, 20);
            this.dtVersionDate.TabIndex = 2;
            // 
            // txtVersion
            // 
            this.txtVersion.Location = new System.Drawing.Point(371, 54);
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.Size = new System.Drawing.Size(134, 20);
            this.txtVersion.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 81);
            this.Controls.Add(this.txtVersion);
            this.Controls.Add(this.dtVersionDate);
            this.Controls.Add(this.btnVersionCalculator);
            this.Controls.Add(this.btnDbVersion);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDbVersion;
        private System.Windows.Forms.Button btnVersionCalculator;
        private System.Windows.Forms.DateTimePicker dtVersionDate;
        private System.Windows.Forms.TextBox txtVersion;
    }
}

