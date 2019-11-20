using System.IO;

namespace Lipeg.Runtime
{
    public class Message : IMessage
    {
        protected Message(MessageSeverity severity, MessageCode code, ILocated located)
        {
            Severity = severity;
            Code = code;
            Location = located.Location;
            Msg = Subject(Location);
        }

        protected Message(MessageSeverity severity, MessageCode code, string message)
        {
            Severity = severity;
            Code = code;
            Location = Runtime.Location.NoLocation;
            Msg = message;
        }

        public MessageSeverity Severity { get; }
        public MessageCode Code { get; set; }
        public ILocation Location { get; }
        public string Msg { get; set; }

        private static string Subject(ILocation location)
        {
            return location.Source.GetText(location.Start, location.Length);
        }

        public void Report(TextWriter writer)
        {
            var (line, col) = Location.Source.GetLineCol(Location.Start);
            writer.WriteLine($"{Location.Source.Name}({line},{col}): {Severity} - {Code}/{Msg}");
        }
    }
}
