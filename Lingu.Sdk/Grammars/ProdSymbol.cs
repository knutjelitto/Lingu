using System;
using System.Collections.Generic;
using System.Text;
using Lingu.Writers;

namespace Lingu.Grammars
{
    public struct ProdSymbol
    {
        public ProdSymbol(Symbol symbol, bool isDrop)
        {
            Symbol = symbol;
            IsDrop = isDrop;
        }

        public Symbol Symbol { get; }
        public bool IsDrop { get; }

        public override string ToString()
        {
            if (IsDrop)
            {
                return $",{Symbol}";
            }
            return Symbol.ToString();
        }
    }
}
