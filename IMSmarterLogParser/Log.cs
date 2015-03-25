using System.Collections.Generic;
using ImSmarterLogParser;

namespace IMSmarterLogParser
{
    public class Log
    {
        private List<Message> _messages = new List<Message>();

        public List<Message> Messages
        {
            get { return _messages; }
            set { _messages = value; }
        }

        public void AddMessage(Message message)
        {
            Messages.Add(message);
        }
    }
}
