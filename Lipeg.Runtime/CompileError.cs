using System;
using System.Collections.Generic;
using System.Text;

namespace Lipeg.Runtime
{
    public class CompileError : ICompileError
    {
        public CompileError(ErrorCode code, string message)
        {
            Code = code;
            Message = message;
        }
        public ErrorCode Code { get; set; }
        public string Message { get; set; }
    }
}
