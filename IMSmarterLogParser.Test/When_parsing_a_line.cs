using System;
using Machine.Specifications;

namespace ImSmarterLogParser.Test
{
    [Subject(typeof(LogParser), "Parsing a Single Line")]
    public class When_parsing_a_line
    {
        private Establish context = () =>
        {
            input = "Tue Dec 7 2004 3:37:03pm thehost < theguest sup buddy";
        };

        private Because of = () => message = LogParser.ParseLine(input);

        private It should_have_the_timestamp = () => message.TimeStamp.ShouldEqual(new DateTime(2004, 12, 7, 15, 37, 03));
        private It should_have_the_sender = () => message.Sender.ShouldEqual("theguest");
        private It should_have_the_receiver = () => message.Receiver.ShouldEqual("thehost");
        private It should_have_the_text = () => message.Text.ShouldEqual("sup buddy");

        private static String input;
        private static Message message;
    }
}