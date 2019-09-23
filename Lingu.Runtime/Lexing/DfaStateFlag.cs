using System;
using System.Collections.Generic;
using System.Text;

namespace Lingu.Runtime.Lexing
{
    [Flags]
    public enum DfaStateFlag
    {
        None = 0,
        Final = 1,
    }
}
