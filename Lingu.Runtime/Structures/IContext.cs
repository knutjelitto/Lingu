using System.Collections.Generic;
using Lingu.Runtime.Lexing;
using Lingu.Runtime.Parsing;

namespace Lingu.Runtime.Structures
{
    public interface IContext
    {
        IReadOnlyList<ISymbol> Symbols { get; }
        ITerminal Eof { get; }
        IReadOnlyList<IProduction> Productions { get; }
        ParseTable Table { get; }
        Dfa Whitespace { get; }
        Dfa Common { get; }

        IErrorHandler Errors { get; }
    }
}