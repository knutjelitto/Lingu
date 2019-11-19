using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lipeg.Runtime
{
    public class CompileError : ICompileError
    {
        public CompileError(ErrorSeverity severity, ErrorCode code, string message)
        {
            Severity = severity;
            Code = code;
            Message = message;
        }

        public ErrorSeverity Severity { get; }
        public ErrorCode Code { get; set; }
        public string Message { get; set; }

        public void Report(TextWriter writer)
        {
            writer.WriteLine($"error {Code}/{Message}");
        }
    }
}
