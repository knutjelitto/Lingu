using Lingu.Runtime.Lexing;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lingu.Runtime.Structures
{
    public interface ITerminal : ISymbol
    {
        Dfa Dfa { get; }
    }
}
