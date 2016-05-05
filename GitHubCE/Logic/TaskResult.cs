using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubCE.Logic
{   
    public class TaskResult
    {
        public bool IsValid { get; set; }
        public IList<string> Errors { get; set; }
        public IList<string> DebugMessages { get; set; }
        public bool HasDebugMessages
        {
            get
            {
                return DebugMessages.Count > 0;
            }
        }
        public TaskResult()
        {
            Errors = new List<string>();
            DebugMessages = new List<string>();
        }

        public void AddException(Exception ex)
        {
            Errors.Add(ex.Message);
            IsValid = false;
        }
        public void AddError(string message)
        {
            Errors.Add(message);
            IsValid = false;
        }
        public void AddErrors(IList<string> errors)
        {
            if (null == errors || errors.Count == 0) return;

            foreach (var errorMessage in errors)
            {
                AddError(errorMessage);
            }
        }
        public void AddDebug(string message)
        {
            DebugMessages.Add(message);
        }
    }
}
