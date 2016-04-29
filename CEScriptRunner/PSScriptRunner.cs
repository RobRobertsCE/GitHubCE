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
        #region events
        public delegate void ScriptCompleteHandler(object sender, bool isSuccessful);
        public event ScriptCompleteHandler ScriptComplete;
        public virtual void OnScriptComplete(bool isSuccessful)
        {
            var handler = this.ScriptComplete;
            if (null != handler)
                handler.Invoke(this, isSuccessful);
        }
        public delegate void InternalRequestCompleteHandler(object sender, string data);
        public event InternalRequestCompleteHandler RequestComplete;
        public virtual void OnRequestComplete(string data)
        {
            var handler = this.RequestComplete;
            if (null != handler)
                handler.Invoke(this, data);
        }
        #endregion

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

        /// <summary>
        /// The repo working directory to run the script in
        /// </summary>
        private string _workingDirectory = Directory.GetCurrentDirectory();

        private bool _internalResponseHandling = false;
        private bool _sendResponse = true;
        private string _internalData;
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
        public PSScriptRunner(ScriptOutputDisplay display, string prompt, string startupDirectory) : this()
        {
            this.Display = display;
            this.Display.Prompt = prompt;
            SetWorkingDirectory(startupDirectory);
        }
        #endregion

        #region public
        public void SetWorkingDirectory(string directoryPath)
        {
            _workingDirectory = directoryPath;
            Directory.SetCurrentDirectory(_workingDirectory);
            _sendResponse = false;
            _internalResponseHandling = true;
            StartScript(String.Format("cd {0}", _workingDirectory));

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
            VerifyDirectory();
            string fullPathCommand = String.Empty;
            if (command.StartsWith(@".\"))
            {
                fullPathCommand = command.Replace(@".\", _workingDirectory + "\\");
            }
            else
            {
                fullPathCommand = command;
            }
            _pipelineExecutor = new PipelineExecutor(_runSpace, _display, fullPathCommand);
            _pipelineExecutor.OnDataReady += new PipelineExecutor.DataReadyDelegate(pipelineExecutor_OnDataReady);
            _pipelineExecutor.OnDataEnd += new PipelineExecutor.DataEndDelegate(pipelineExecutor_OnDataEnd);
            _pipelineExecutor.OnErrorReady += new PipelineExecutor.ErrorReadyDelegate(pipelineExecutor_OnErrorReady);
            _pipelineExecutor.Start();
            if (!_internalResponseHandling)
                _display.AppendCommand(command);
        }

        #region public-no output
        public void GetCurrentBranch()
        {
            _sendResponse = true;
            _internalResponseHandling = true;
            StartScript(@"git rev-parse --abbrev-ref HEAD");
        }
        #endregion
        #endregion

        #region private
        private void VerifyDirectory()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            if (_workingDirectory != currentDirectory)
                SetWorkingDirectory(_workingDirectory);
        }

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
                if (_internalResponseHandling)
                {
                    _internalData = line;
                    if (_sendResponse)
                        OnRequestComplete(_internalData);
                    _internalResponseHandling = false;
                    _sendResponse = true;
                }
                else
                {
                    if (line.Contains(@" warning "))
                        _display.AppendWarning(line);
                    else
                        _display.AppendLine(line);

                    _display.AppendLine("");
                }
            }
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
