using System;
using System.Collections.Generic;
using System.Text;

namespace Lingu.Runtime.Structures
{
    public interface IToken
    {
        ILocation Location { get; }
        ISymbol Symbol { get; }
    }
}
