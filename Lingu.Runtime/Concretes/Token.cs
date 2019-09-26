using System;

using Lingu.Runtime.Structures;

namespace Lingu.Runtime.Concretes
{
    public abstract class Token : IToken
    {
        protected Token(ISymbol symbol)
        {
            Symbol = symbol;
        }

        public ISymbol Symbol { get; }
        public ILocation Location => throw new NotImplementedException();

        public override string? ToString()
        {
            return $"{Symbol}"; 
        }
    }
}
