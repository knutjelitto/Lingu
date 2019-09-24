using System;
using System.Collections.Generic;
using System.Text;

namespace Lingu.Runtime.Structures
{
    public interface IToken
    {
        ISymbol Symbol { get; }
        ILocation Location { get; }
    }
}
