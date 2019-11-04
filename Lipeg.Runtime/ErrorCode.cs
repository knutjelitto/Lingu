using System;
using System.Collections.Generic;
using System.Text;

namespace Lipeg.Runtime
{
    public enum ErrorCode
    {
        SourceFileNotFound = 1,
        AlreadyDefinedHere = 201,
        RedefinedHere = 202,
    }
}
