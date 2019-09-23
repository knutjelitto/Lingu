using System;

namespace Lingu.Runtime.Lexing
{
    [Flags]
    public enum DfaStateFlag
    {
        None = 0,
        Final = 1,
    }
}
