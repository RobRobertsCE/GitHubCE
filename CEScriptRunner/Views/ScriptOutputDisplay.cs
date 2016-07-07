using Codeproject.PowerShell;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Windows.Forms;

namespace CEScriptRunner.Views
{
    public partial class ScriptOutputDisplay : UserControl
    {
        #region properties
        public bool SuppressBlankLines { get; set; }
        public Color DisplayForeColor
        {
            get
            {
                return txtOutput.SelectionColor;
            }
            set
            {
                txtOutput.SelectionColor = value;
            }
        }

        public Color DisplayPromptColor { get; set; }

        public Font DisplayFont
        {
            get
            {
                return txtOutput.SelectionFont;
            }
            set
            {
                txtOutput.SelectionFont = value;
            }
        }

        public Font PromptFont { get; set; }

        public string Prompt { get; set; }

        public bool HasPrompt
        {
            get
            {
                return (!string.IsNullOrEmpty(Prompt));
            }
        }
        #endregion

        #region ctor
        public ScriptOutputDisplay()
        {
            InitializeComponent();
            DisplayPromptColor = Color.WhiteSmoke;
            PromptFont = new Font(txtOutput.SelectionFont.Name, txtOutput.SelectionFont.Size, txtOutput.SelectionFont.Style);
        }
        #endregion

        #region public
        public void AppendTextBold(string line, Color? foreColor)
        {
            if (SuppressBlankLines && String.IsNullOrEmpty(line))
                return;
            txtOutput.DeselectAll();
            Font originalFont = (Font)txtOutput.SelectionFont.Clone();
            txtOutput.SelectionFont = new Font(txtOutput.SelectionFont, FontStyle.Bold);
            if (foreColor.HasValue)
                txtOutput.SelectionColor = foreColor.Value;
            txtOutput.AppendText(line);
            if (foreColor.HasValue)
                txtOutput.SelectionColor = DisplayForeColor;
            txtOutput.SelectionFont = new Font(originalFont.Name, originalFont.Size, originalFont.Style);
            txtOutput.ScrollToCaret();
        }

        public void AppendText(string line, Color? foreColor)
        {
            if (SuppressBlankLines && String.IsNullOrEmpty(line))
                return;
            txtOutput.DeselectAll();
            if (foreColor.HasValue)
                txtOutput.SelectionColor = foreColor.Value;
            txtOutput.AppendText(line);
            if (foreColor.HasValue)
                txtOutput.SelectionColor = DisplayForeColor;
            txtOutput.ScrollToCaret();
        }

        public void AppendText(string line)
        {
            if (SuppressBlankLines && String.IsNullOrEmpty(line))
                return;
            AppendText(line, null);
        }

        public void AppendLineBold(string line, Color? foreColor)
        {
            if (SuppressBlankLines && String.IsNullOrEmpty(line))
                return;
            AppendTextBold(line + "\r\n", foreColor);
        }

        public void AppendLine(string line, Color? foreColor)
        {
            AppendText(line + "\r\n", foreColor);
        }

        public void AppendLine(string line)
        {
            if (SuppressBlankLines && String.IsNullOrEmpty(line))
                return;
            AppendText(line + "\r\n", null);
        }

        public void AppendWarning(string line)
        {
            if (SuppressBlankLines && String.IsNullOrEmpty(line))
                return;
            AppendLineBold(line + "\r\n", Color.Yellow);
        }
        public void AppendCommand(string line)
        {
            if (SuppressBlankLines && String.IsNullOrEmpty(line))
                return;
            AppendLineBold(line + "\r\n", Color.Teal);
        }
        public void AppendError(string line)
        {
            AppendLineBold(line, Color.Red);
#if (DEBUG)
            Console.WriteLine(line);
#endif
        }
        public void AppendInfo(string line)
        {
            AppendLineBold(line, Color.Gray);
#if (DEBUG)
            Console.WriteLine(line);
#endif
        }

        public void ClearOutput()
        {
            txtOutput.Clear();
        }

        public void SelectAllAndCopy()
        {
            txtOutput.SelectAll();
            txtOutput.Copy();
        }

        public void DisplayPrompt()
        {
            DisplayLinePrompt();
        }
        #endregion

        #region protected
        protected virtual void DisplayLinePrompt()
        {
            Font originalFont = (Font)txtOutput.SelectionFont.Clone();
            Color originalColor = DisplayForeColor;
            txtOutput.SelectionFont = PromptFont;
            txtOutput.SelectionColor = DisplayPromptColor;
            string promptText = Prompt;
            if (HasPrompt)
            {
                if (promptText.Contains("{line#}"))
                {
                    var lineCount = (txtOutput.Lines.Length == 0) ? 1 : txtOutput.Lines.Length;
                    promptText = promptText.Replace("{line#}", lineCount.ToString());
                }

                if (promptText.Contains("{timestamp}"))
                    promptText = promptText.Replace("{timestamp}", DateTime.Now.ToString());

                if (promptText.Contains("{dir}"))
                    promptText = promptText.Replace("{dir}", Environment.CurrentDirectory);

                if (promptText.Contains("{fol}"))
                    promptText = promptText.Replace("{fol}", System.IO.Path.GetFileName(Environment.CurrentDirectory.TrimEnd('\\')));
            }
            else
            {
                promptText = ">";
            }
            txtOutput.AppendText(string.Format("{0} ", promptText));
            txtOutput.SelectionColor = originalColor;
            txtOutput.SelectionFont = originalFont;
        }
        #endregion

        #region private
        private void clearToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            txtOutput.Clear();
        }
        #endregion
    }
}
