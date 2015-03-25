using System;
using System.Text;

namespace ImSmarterLogParser
{
    public class Message
    {
        public DateTime TimeStamp { get; set; }
        public String Sender { get; set; }
        public String Receiver { get; set; }
        public String Text { get; set; }

        public override string ToString()
        {
            return String.Format("({0}) {1}: {2}", TimeStamp.ToString("h:mm:ss tt"), Sender, Text);
        }
    }
}