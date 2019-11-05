using System;
using System.Collections.Generic;
using System.Text;

namespace Lipeg.Runtime
{
    public enum ErrorCode
    {
        SourceFileNotFound = 1,
        AlreadyDefinedRule = 201,
        RedefinedRule = 202,
        UndefinedRule = 203,
        UnusedRule = 204,
    }
}
