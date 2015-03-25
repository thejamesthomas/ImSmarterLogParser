using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImSmarterLogParser;
using Machine.Specifications;

namespace IMSmarterLogParser.Test
{
    [Subject(typeof(LogParser), "Parsing Multiple Lines")]
    class When_parsing_multiple_lines
    {
        private Establish context = () =>
        {
            input = @"Tue Dec 7 2004 3:42:26pm thehost < theguest how long is your break?
Tue Dec 7 2004 3:42:54pm thehost > theguest not sure, probably until mid January
Tue Dec 7 2004 3:43:13pm thehost < theguest about a month then?
Tue Dec 7 2004 3:43:21pm thehost > theguest chep, I think so at least
Tue Dec 7 2004 3:58:20pm thehost < theguest what are you working on?
Tue Dec 7 2004 3:59:03pm thehost > theguest probably going to go study for my Digital Logic Design final, fun stuff
Tue Dec 7 2004 3:59:15pm thehost < theguest sounds delicious
Tue Dec 7 2004 3:59:26pm thehost > theguest indeed it is";
        };

        private Because of = () => log = LogParser.ParseLines(input);

        private It should_have_the_correct_number_of_messages = () => log.Messages.Count.ShouldEqual(8);
        private It should_have_a_correct_message = () => log.Messages.First().Text.ShouldEqual("how long is your break?");

        private static Log log;
        private static String input;
    }
}
