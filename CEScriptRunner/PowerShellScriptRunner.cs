using System;
using System.Collections.ObjectModel;
using System.Management.Automation;
using System.Text;
using System.Threading;


namespace CEScriptRunner
{
    public class PowerShellScriptRunner
    {
        static StringBuilder powershellStringBuilder;

        public ErrorRecord LastError { get; set; }

        public static string LastOutput { get; set; }

        /// <summary>
        /// Runs a PowerShell command
        /// </summary>
        /// <param name="command">The command to run</param>
        public static void ExecuteCommand(string command)
        {
            try
            {
                using (PowerShell PowerShellInstance = PowerShell.Create())
                {
                    // use "AddScript" to add the contents of a script file to the end of the execution pipeline.
                    // use "AddCommand" to add individual commands/cmdlets to the end of the execution pipeline.
                    //PowerShellInstance.AddScript("param($param1) $d = get-date; $s = 'test string value'; " +
                    //        "$d; $s; $param1; get-service");
                    
                    PowerShellInstance.AddCommand(command);

                    // invoke execution on the pipeline (collecting output)
                    Collection<PSObject> PSOutput = PowerShellInstance.Invoke();

                    powershellStringBuilder = new StringBuilder();
                    // loop through each output object item
                    foreach (PSObject outputItem in PSOutput)
                    {
                        // if null object was dumped to the pipeline during the script then a null
                        // object may be present here. check for null to prevent potential NRE.
                        if (outputItem != null)
                        {
                            //TODO: do something with the output item 
                            // outputItem.BaseOBject
                            powershellStringBuilder.AppendLine(outputItem.BaseObject.ToString());
                        }
                    }
                    var scriptOutput = powershellStringBuilder.ToString();

                    Console.WriteLine(scriptOutput);

                    LastOutput = scriptOutput;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(" ************** Exception Running PowerShell Script ************** ");
                Console.WriteLine(ex.ToString());
            }

            Console.WriteLine(" ------------------ Done ------------------ ");
        }

        /// <summary>
        /// Runs a PowerShell command Asyncronously
        /// </summary>
        /// <param name="command">The command to run</param>
        public void ExecuteCommandAsync(string command)
        {
            using (PowerShell PowerShellInstance = PowerShell.Create())
            {
                // this script has a sleep in it to simulate a long running script
                PowerShellInstance.AddScript("$s1 = 'test1'; $s2 = 'test2'; $s1; write-error 'some error';start-sleep -s 7; $s2");

                // prepare a new collection to store output stream objects
                PSDataCollection<PSObject> outputCollection = new PSDataCollection<PSObject>();
                outputCollection.DataAdded += outputCollection_DataAdded;

                // the streams (Error, Debug, Progress, etc) are available on the PowerShell instance.
                // we can review them during or after execution.
                // we can also be notified when a new item is written to the stream (like this):
                PowerShellInstance.Streams.Error.DataAdded += Error_DataAdded;

                // begin invoke execution on the pipeline
                // use this overload to specify an output stream buffer
                IAsyncResult result = PowerShellInstance.BeginInvoke<PSObject, PSObject>(null, outputCollection);

                // do something else until execution has completed.
                // this could be sleep/wait, or perhaps some other work
                while (result.IsCompleted == false)
                {
                    Console.WriteLine("Waiting for pipeline to finish...");
                    Thread.Sleep(1000);

                    // might want to place a timeout here...
                }

                Console.WriteLine("Execution has stopped. The pipeline state: " + PowerShellInstance.InvocationStateInfo.State);

                foreach (PSObject outputItem in outputCollection)
                {
                    //TODO: handle/process the output items if required
                    Console.WriteLine(outputItem.BaseObject.ToString());
                }
            }
        }

        /// <summary>
        /// Event handler for when data is added to the output stream.
        /// </summary>
        /// <param name="sender">Contains the complete PSDataCollection of all output items.</param>
        /// <param name="e">Contains the index ID of the added collection item and the ID of the PowerShell instance this event belongs to.</param>
        void outputCollection_DataAdded(object sender, DataAddedEventArgs e)
        {           
            PSDataCollection<PSObject> myp = (PSDataCollection<PSObject>)sender;
            Collection<PSObject> results = myp.ReadAll();
            foreach (PSObject result in results)
            {
                Console.WriteLine(result.ToString());
            }
        }

        
        /// <summary>
        /// Event handler for when Data is added to the Error stream.
        /// </summary>
        /// <param name="sender">Contains the complete PSDataCollection of all error output items.</param>
        /// <param name="e">Contains the index ID of the added collection item and the ID of the PowerShell instance this event belongs to.</param>
        void Error_DataAdded(object sender, DataAddedEventArgs e)
        {
            PSDataCollection<ErrorRecord> collection = sender as PSDataCollection<ErrorRecord>;
            this.LastError = collection[e.Index];
            Console.WriteLine(">>>" + LastError.Exception.Message);          
        }
    }
}


namespace Codeproject.PowerShell
{
    /****** USE ****/
    ///// <summary>
    ///// Powershell runspace
    ///// </summary>
    //private Runspace runSpace;

    ///// <summary>
    ///// The active PipelineExecutor instance
    ///// </summary>
    //private PipelineExecutor pipelineExecutor;

    //public FormPowerShellSample()
    //{
    //    InitializeComponent();
    //    InitializeComboBox();
    //    // create Powershell runspace
    //    runSpace = RunspaceFactory.CreateRunspace();
    //    // open it
    //    runSpace.Open();
    //}

    //private void FormPowerShellSample_FormClosing(object sender, FormClosingEventArgs e)
    //{
    //    // stop any running scripts
    //    StopScript();
    //    // close the powershell runspace
    //    runSpace.Close();
    //}

    //private void buttonStartScript_Click(object sender, EventArgs e)
    //{
    //    StopScript();
    //    listBoxOutput.Items.Clear();
    //    AppendLine("Starting script...");
    //    pipelineExecutor = new PipelineExecutor(runSpace, this, textBoxScript.Text);
    //    pipelineExecutor.OnDataReady += new PipelineExecutor.DataReadyDelegate(pipelineExecutor_OnDataReady);
    //    pipelineExecutor.OnDataEnd += new PipelineExecutor.DataEndDelegate(pipelineExecutor_OnDataEnd);
    //    pipelineExecutor.OnErrorReady += new PipelineExecutor.ErrorReadyDelegate(pipelineExecutor_OnErrorReady);
    //    pipelineExecutor.Start();
    //}

    //private void buttonStopScript_Click(object sender, EventArgs e)
    //{
    //    StopScript();
    //}

    //private void StopScript()
    //{
    //    if (pipelineExecutor != null)
    //    {
    //        pipelineExecutor.OnDataReady -= new PipelineExecutor.DataReadyDelegate(pipelineExecutor_OnDataReady);
    //        pipelineExecutor.OnDataEnd -= new PipelineExecutor.DataEndDelegate(pipelineExecutor_OnDataEnd);
    //        pipelineExecutor.Stop();
    //        pipelineExecutor = null;
    //    }
    //}

    //private void pipelineExecutor_OnDataEnd(PipelineExecutor sender)
    //{
    //    if (sender.Pipeline.PipelineStateInfo.State == PipelineState.Failed)
    //    {
    //        AppendLine(string.Format("Error in script: {0}", sender.Pipeline.PipelineStateInfo.Reason));
    //    }
    //    else
    //    {
    //        AppendLine("Ready.");
    //    }
    //}

    //private void pipelineExecutor_OnDataReady(PipelineExecutor sender, ICollection<PSObject> data)
    //{
    //    foreach (PSObject obj in data)
    //    {
    //        AppendLine(obj.ToString());
    //    }
    //}

    //void pipelineExecutor_OnErrorReady(PipelineExecutor sender, ICollection<object> data)
    //{
    //    foreach (object e in data)
    //    {
    //        AppendLine("Error : " + e.ToString());
    //    }
    //}

    //using System;
    //using System.Collections.Generic;
    //using System.Collections.ObjectModel;
    //using System.ComponentModel;
    //using System.Management.Automation;
    //using System.Management.Automation.Runspaces;
    //using System.Threading;

    ///// <summary>
    ///// Class that assists in asynchronously executing and retrieving the results of a powershell script pipeline.
    ///// </summary>
    //public class PipelineExecutor
    //{
    //    #region public types, members
    //    /// <summary>
    //    /// Gets the powershell Pipeline associated with this PipelineExecutor
    //    /// </summary>
    //    public Pipeline Pipeline
    //    {
    //        get
    //        {
    //            return pipeline;
    //        }
    //    }

    //    public delegate void DataReadyDelegate(PipelineExecutor sender, ICollection<PSObject> data);
    //    public delegate void DataEndDelegate(PipelineExecutor sender);
    //    public delegate void ErrorReadyDelegate(PipelineExecutor sender, ICollection<object> data);

    //    /// <summary>
    //    /// Occurs when there is new data available from the powershell script.
    //    /// </summary>
    //    public event DataReadyDelegate OnDataReady;

    //    /// <summary>
    //    /// Occurs when powershell script completed its execution.
    //    /// </summary>
    //    public event DataEndDelegate OnDataEnd;

    //    /// <summary>
    //    /// Occurs when there is new errordata available from the powershell script.
    //    /// </summary>
    //    public event ErrorReadyDelegate OnErrorReady;

    //    #endregion

    //    #region private types, members

    //    /// <summary>
    //    /// The object that is used to invoke the events on.
    //    /// </summary>
    //    private ISynchronizeInvoke invoker;

    //    /// <summary>
    //    /// The powershell script pipeline that will be executed asynchronously.
    //    /// </summary>
    //    private Pipeline pipeline;

    //    /// <summary>
    //    /// Local delegate to a private method
    //    /// </summary>
    //    private DataReadyDelegate synchDataReady;

    //    /// <summary>
    //    /// Local delegate to a private method
    //    /// </summary>
    //    private DataEndDelegate synchDataEnd;

    //    /// <summary>
    //    /// Local delegate to a private method
    //    /// </summary>
    //    private ErrorReadyDelegate synchErrorReady;

    //    /// <summary>
    //    /// Event set when the user wants to stop script execution.
    //    /// </summary>
    //    private ManualResetEvent stopEvent;

    //    /// <summary>
    //    /// Array of waithandles, used in the StoppableInvoke() method.
    //    /// </summary>
    //    private WaitHandle[] waitHandles;
    //    #endregion

    //    #region public methods
    //    /// <summary>
    //    /// Constructor, creates a new PipelineExecutor for the given powershell script.
    //    /// </summary>
    //    /// <param name="runSpace">Powershell runspace to use for creating and executing the script.</param>
    //    /// <param name="invoker">The object to synchronize the DataReady and DataEnd events with. 
    //    /// Normally you'd pass the form or component here.</param>
    //    /// <param name="command">The script to run</param>
    //    public PipelineExecutor(Runspace runSpace, ISynchronizeInvoke invoker, string command)
    //    {
    //        this.invoker = invoker;

    //        // initialize delegates
    //        synchDataReady = new DataReadyDelegate(SynchDataReady);
    //        synchDataEnd = new DataEndDelegate(SynchDataEnd);
    //        synchErrorReady = new ErrorReadyDelegate(SynchErrorReady);

    //        // initialize event members
    //        stopEvent = new ManualResetEvent(false);
    //        waitHandles = new WaitHandle[] { null, stopEvent };
    //        // create a pipeline and feed it the script text
    //        pipeline = runSpace.CreatePipeline(command);

    //        // we'll listen for script output data by way of the DataReady event
    //        pipeline.Output.DataReady += new EventHandler(Output_DataReady);
    //        pipeline.Error.DataReady += new EventHandler(Error_DataReady);
    //    }

    //    void Error_DataReady(object sender, EventArgs e)
    //    {
    //        // fetch all available objects
    //        Collection<object> data = pipeline.Error.NonBlockingRead();

    //        // if there were any, invoke the ErrorReady event
    //        if (data.Count > 0)
    //        {
    //            StoppableInvoke(synchErrorReady, new object[] { this, data });
    //        }
    //    }

    //    /// <summary>
    //    /// Start executing the script in the background.
    //    /// </summary>
    //    public void Start()
    //    {
    //        if (pipeline.PipelineStateInfo.State == PipelineState.NotStarted)
    //        {
    //            // close the pipeline input. If you forget to do 
    //            // this it won't start processing the script.
    //            pipeline.Input.Close();
    //            // invoke the pipeline. This will cause it to process the script in the background.
    //            pipeline.InvokeAsync();
    //        }
    //    }

    //    /// <summary>
    //    /// Stop executing the script.
    //    /// </summary>
    //    public void Stop()
    //    {
    //        // first make sure StoppableInvoke() stops blocking
    //        stopEvent.Set();
    //        // then tell the pipeline to stop the script
    //        pipeline.Stop();
    //    }
    //    #endregion

    //    #region private methods

    //    /// <summary>
    //    /// Special Invoke method that operates similarly to <see cref="ISynchronizeInvoke.Invoke"/> but in addition to that, it can be 
    //    /// aborted by setting the stopEvent. This avoids potential deadlocks that are possible when using the regular 
    //    /// <see cref="ISynchronizeInvoke.Invoke"/> method.
    //    /// </summary>
    //    /// <param name="method">A <see cref="System.Delegate"/> to a method that takes parameters of the same number and type that are 
    //    /// contained in <paramref name="args"/></param>
    //    /// <param name="args">An array of type <see cref="System.Object"/> to pass as arguments to the given method. This can be null if 
    //    /// no arguments are needed </param>
    //    /// <returns>The <see cref="Object"/> returned by the asynchronous operation</returns>
    //    private object StoppableInvoke(Delegate method, object[] args)
    //    {
    //        IAsyncResult asyncResult = invoker.BeginInvoke(method, args);
    //        waitHandles[0] = asyncResult.AsyncWaitHandle;
    //        return (WaitHandle.WaitAny(waitHandles) == 0) ? invoker.EndInvoke(asyncResult) : null;
    //    }

    //    /// <summary>
    //    /// Event handler for the DataReady event of the powershell script pipeline.
    //    /// </summary>
    //    /// <param name="sender"></param>
    //    /// <param name="e"></param>
    //    private void Output_DataReady(object sender, EventArgs e)
    //    {
    //        // fetch all available objects
    //        Collection<PSObject> data = pipeline.Output.NonBlockingRead();

    //        // if there were any, invoke the DataReady event
    //        if (data.Count > 0)
    //        {
    //            StoppableInvoke(synchDataReady, new object[] { this, data });
    //        }

    //        if (pipeline.Output.EndOfPipeline)
    //        {
    //            // we're done! invoke the DataEnd event
    //            StoppableInvoke(synchDataEnd, new object[] { this });
    //        }
    //    }

    //    /// <summary>
    //    /// private DataReady handling method that will pass the call on to any event handlers that are
    //    /// attached to the OnDataReady event of this <see cref="PipelineExecutor"/> instance.
    //    /// </summary>
    //    /// <param name="sender"></param>
    //    /// <param name="data"></param>
    //    private void SynchDataReady(PipelineExecutor sender, ICollection<PSObject> data)
    //    {
    //        DataReadyDelegate delegateDataReadyCopy = OnDataReady;
    //        if (delegateDataReadyCopy != null)
    //        {
    //            delegateDataReadyCopy(sender, data);
    //        }
    //    }

    //    /// <summary>
    //    /// private DataEnd handling method that will pass the call on to any handlers that are
    //    /// attached to the OnDataEnd event of this <see cref="PipelineExecutor"/> instance.
    //    /// </summary>
    //    /// <param name="sender"></param>
    //    /// <param name="data"></param>
    //    private void SynchDataEnd(PipelineExecutor sender)
    //    {
    //        DataEndDelegate delegateDataEndCopy = OnDataEnd;
    //        if (delegateDataEndCopy != null)
    //        {
    //            delegateDataEndCopy(sender);
    //        }
    //    }

    //    /// <summary>
    //    /// private ErrorReady handling method that will pass the call on to any event handlers that are
    //    /// attached to the OnErrorReady event of this <see cref="PipelineExecutor"/> instance.
    //    /// </summary>
    //    /// <param name="sender"></param>
    //    /// <param name="data"></param>
    //    private void SynchErrorReady(PipelineExecutor sender, ICollection<object> data)
    //    {
    //        ErrorReadyDelegate delegateErrorReadyCopy = OnErrorReady;
    //        if (delegateErrorReadyCopy != null)
    //        {
    //            delegateErrorReadyCopy(sender, data);
    //        }
    //    }

    //    #endregion
    //}
}
