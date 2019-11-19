using System.IO;

namespace Lipeg.Runtime
{
    public interface ICompileError
    {
        ErrorSeverity Severity { get; }
        ErrorCode Code { get; }
        string Message { get; }

        void Report(TextWriter writer);
    }
}
