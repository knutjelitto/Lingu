using System.IO;

namespace Lipeg.Runtime
{
    public class CheckError : ICompileError
    {
        public CheckError(ErrorSeverity severity, ErrorCode code, ILocated located)
        {
            Severity = severity;
            Code = code;
            Location = located.Location;
            Message = Subject(Location);
        }

        public ErrorSeverity Severity { get; }
        public ErrorCode Code { get; set; }
        public ILocation Location { get; }
        public string Message { get; set; }

        private static string Subject(ILocation location)
        {
            return location.Source.GetText(location.Start, location.Length);
        }

        public void Report(TextWriter writer)
        {
            var (line, col) = Location.Source.GetLineCol(Location.Start);
            writer.WriteLine($"{Location.Source.Name}({line},{col}): {Code}/{Message}");
        }
    }
}
