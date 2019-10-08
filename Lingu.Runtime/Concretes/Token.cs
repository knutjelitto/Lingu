using System;
using System.Diagnostics;
using Lingu.Runtime.Structures;

namespace Lingu.Runtime.Concretes
{
    [DebuggerDisplay("{ToString()}")]
    public abstract class Token : IToken
    {
        protected Token(ISymbol symbol)
        {
            Symbol = symbol;
        }

        public ISymbol Symbol { get; }

        public override string? ToString()
        {
            return $"{Symbol}"; 
        }
    }
}
