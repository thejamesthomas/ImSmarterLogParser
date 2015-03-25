using System;

namespace ImSmarterLogParser
{
    public class Message
    {
        public DateTime TimeStamp { get; set; }
        public String Sender { get; set; }
        public String Receiver { get; set; }
        public String Text { get; set; }
    }
}