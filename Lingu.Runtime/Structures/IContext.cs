using System.Collections.Generic;
using Lingu.Runtime.Lexing;
using Lingu.Runtime.Parsing;

namespace Lingu.Runtime.Structures
{
    public interface IContext
    {
        IReadOnlyList<ISymbol> Symbols { get; }
        ParseTable Table { get; }
        Dfa Whitespace { get; }
    }
}