using System;
using System.Collections.Generic;
using System.Text;

namespace Lingu.Runtime.Structures
{
    public interface INonterminal : ISymbol
    {
        RepeatKind Repeat { get; }
    }
}
