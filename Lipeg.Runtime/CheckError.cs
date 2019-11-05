using System.IO;

namespace Lipeg.Runtime
{
    public class CheckError : ICompileError
    {
        public CheckError(ErrorCode code, ILocation location, string message)
        {
            Code = code;
            Location = location;
            Message = message;
        }

        public ErrorCode Code { get; set; }
        public ILocation Location { get; }
        public string Message { get; set; }

        public void Report(TextWriter writer)
        {
            var (line, col) = Location.Source.GetLineCol(Location.Start);
            writer.WriteLine($"{Location.Source.Name}({line},{col}): {Code}/{Message}");
        }
    }
}
