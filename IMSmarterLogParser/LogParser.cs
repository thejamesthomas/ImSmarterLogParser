using System;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using IMSmarterLogParser;
using NodaTime.Text;

namespace ImSmarterLogParser
{
    public class LogParser
    {
        public static Message ParseLine(string input)
        {
            const string pattern = @"^(?<TimeStamp>([\w\s:]+)(a|pm)) (?<Host>\w+) (?<Direction>.) (?<Guest>\w+) (?<Text>.+)$";
            var match = Regex.Match(input, pattern);

            var message = new Message
            {
                TimeStamp = GetTimeStamp(match),
                Sender = GetSender(match),
                Receiver = GetReceiver(match),
                Text = GetText(match)
            };
            return message;
        }

        public static Log ParseLines(string inputLines)
        {
            var log = new Log();
            using (var reader = new StringReader(inputLines))
            {
                String line;
                while ((line = reader.ReadLine()) != null)
                {
                    var message = ParseLine(line);
                    log.AddMessage(message);
                }
            }
            return log;
        }

        private static string GetText(Match match)
        {
            return match.Groups["Text"].Value;
        }

        private static string GetReceiver(Match match)
        {
            return GuestIsSender(match) ? match.Groups["Host"].Value : match.Groups["Guest"].Value;
        }

        private static string GetSender(Match match)
        {
            return GuestIsSender(match) ? match.Groups["Guest"].Value : match.Groups["Host"].Value;
        }

        private static bool GuestIsSender(Match match)
        {
            return match.Groups["Direction"].Value == "<";
        }

        private static DateTime GetTimeStamp(Match match)
        {
            var dateTimePattern = LocalDateTimePattern.Create("ddd MMM d yyyy h:mm:sstt", new CultureInfo("en-US"));
            var parseResult = dateTimePattern.Parse(match.Groups["TimeStamp"].Value);
            var timeStamp = parseResult.GetValueOrThrow().ToDateTimeUnspecified();
            return timeStamp;
        }
    }
}
