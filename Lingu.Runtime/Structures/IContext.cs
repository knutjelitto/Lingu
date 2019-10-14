using System.Collections.Generic;

namespace Lingu.Runtime.Structures
{
    public interface IContext
    {
        IReadOnlyList<ISymbol> Symbols { get; }
        IReadOnlyList<IProduction> Productions { get; }
        IParseTable Table { get; }
        IDfaSet Dfas { get; }
        IErrorHandler Errors { get; }
    }
}