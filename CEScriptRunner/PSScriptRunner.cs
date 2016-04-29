using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Codeproject.PowerShell;
using System.Drawing;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Windows.Forms;
using CEScriptRunner.Views;
using System.IO;

namespace CEScriptRunner
{
    public class PSScriptRunner
    {
        public delegate void ScriptCompleteHandler(object sender, bool isSuccessful);
        public event ScriptCompleteHandler ScriptComplete;
        public virtual void OnScriptComplete(bool isSuccessful)
        {
            var handler = this.ScriptComplete;
            if (null != handler)
                handler.Invoke(this, isSuccessful);
        }

        #region fields
        /// <summary>
        /// Powershell runspace
        /// </summary>
        private Runspace _runSpace;

        /// <summary>
        /// The active PipelineExecutor instance
        /// </summary>
        private PipelineExecutor _pipelineExecutor;

        /// <summary>
        /// The output display control
        /// </summary>
        private ScriptOutputDisplay _display;
        #endregion

        #region properties
        public ScriptOutputDisplay Display
        {
            get
            {
                return _display;
            }
            set
            {
                _display = value;
            }
        }
        #endregion

        #region ctor
        public PSScriptRunner()
        {
            // create Powershell runspace
            _runSpace = RunspaceFactory.CreateRunspace();
            // open it
            _runSpace.Open();
        }
        public PSScriptRunner(ScriptOutputDisplay display, string prompt, string startupDirectory):this()
        {
            this.Display = display;
            this.Display.Prompt = prompt;
            Directory.SetCurrentDirectory(startupDirectory);
        }
        #endregion

        #region public
        public void SetWorkingDirectory(string directoryPath)
        {
            Directory.SetCurrentDirectory(directoryPath);
            AddBlankLine();
        }
        public void SetPrompt(string prompt)
        {
            _display.Prompt = prompt;
            AddBlankLine();
        }
        public void AddBlankLine()
        {
            _display.AppendLine("");
        }
        public void StartScript(string command)
        {
            StopScript();
            if (command.StartsWith (@".\"))
            {
                command = command.Replace(@".\", Directory.GetCurrentDirectory() + "\\");
            }
            _pipelineExecutor = new PipelineExecutor(_runSpace, _display, command);
            _pipelineExecutor.OnDataReady += new PipelineExecutor.DataReadyDelegate(pipelineExecutor_OnDataReady);
            _pipelineExecutor.OnDataEnd += new PipelineExecutor.DataEndDelegate(pipelineExecutor_OnDataEnd);
            _pipelineExecutor.OnErrorReady += new PipelineExecutor.ErrorReadyDelegate(pipelineExecutor_OnErrorReady);
            _pipelineExecutor.Start();
            _display.AppendCommand(command);
        }
        #endregion

        #region private
        private void StopScript()
        {
            if (_pipelineExecutor != null)
            {
                _pipelineExecutor.OnDataReady -= new PipelineExecutor.DataReadyDelegate(pipelineExecutor_OnDataReady);
                _pipelineExecutor.OnDataEnd -= new PipelineExecutor.DataEndDelegate(pipelineExecutor_OnDataEnd);
                _pipelineExecutor.Stop();
                _pipelineExecutor = null;
            }
        }

        private void pipelineExecutor_OnDataEnd(PipelineExecutor sender)
        {
            if (sender.Pipeline.PipelineStateInfo.State == PipelineState.Failed)
            {
                _display.AppendError(string.Format("Error in script: {0}", sender.Pipeline.PipelineStateInfo.Reason));
                OnScriptComplete(false);
            }
            else
            {
                OnScriptComplete(true);
            }
            _display.AppendLine("Ready");
        }

        private void pipelineExecutor_OnDataReady(PipelineExecutor sender, ICollection<PSObject> data)
        {
            foreach (PSObject obj in data)
            {
                var line = obj.ToString();
                if (line.Contains(@" warning "))
                    _display.AppendWarning(line);
                else
                    _display.AppendLine(line);
            }
            _display.AppendLine("");
        }

        void pipelineExecutor_OnErrorReady(PipelineExecutor sender, ICollection<object> data)
        {
            foreach (object e in data)
            {
                _display.AppendError("Error : " + e.ToString());
            }
            _display.AppendLine("");
        }
        #endregion
    }
}
