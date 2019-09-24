using Lingu.Runtime.Structures;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
