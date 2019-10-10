using System;
using System.Diagnostics;

#nullable enable

namespace Lingu.Grammars
{
    public class ProdSymbol
    {
        public ProdSymbol(Symbol symbol, bool isDrop, bool isPromote)
        {
            Debug.Assert(!(isDrop && isPromote));

            Symbol = symbol;
            IsDrop = isDrop;
            IsPromote = isPromote;
        }

        public ProdSymbol(Symbol symbol)
            : this(symbol, false, false)
        {
        }

        public Symbol Symbol { get; }
        public bool IsDrop { get; }
        public bool IsPromote { get; }

        public override string ToString()
        {
            if (IsDrop)
            {
                return $",{Symbol}";
            }
            if (IsPromote)
            {
                return $"^{Symbol}";
            }

            return Symbol.ToString();
        }
    }
}
