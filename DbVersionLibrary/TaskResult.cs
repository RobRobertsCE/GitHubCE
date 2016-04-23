using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbVersionLibrary
{
    public class TaskResult<T>
    {
        private IList<string> _messages;
        public IList<string> Messages { get { return _messages; } }

        public string Message
        {
            get
            {
                if (null == _messages)
                    return String.Empty;
                else
                    return _messages.FirstOrDefault();
            }
        }

        private bool _isSuccessful = true;
        public bool IsSuccessful { get { return _isSuccessful; } }

        public T TaskObject { get; set; }

        public TaskResult()
        {
            _messages = new List<string>();
        }

        public void AddMessage(string message)
        {
            _messages.Add(message);
            _isSuccessful = false;
        }

        public void AddException(Exception ex)
        {
            _messages.Add(ex.ToString());
            _isSuccessful = false;
        }
    }
}
