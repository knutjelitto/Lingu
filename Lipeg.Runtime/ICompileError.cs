using System.IO;

namespace Lipeg.Runtime
{
    public interface ICompileError
    {
        ErrorCode Code { get; }
        string Message { get; }

        void Report(TextWriter writer);
    }
}
