using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
