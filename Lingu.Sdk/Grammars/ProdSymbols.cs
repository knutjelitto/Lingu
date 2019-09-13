using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lingu.Grammars
{
    public class ProdSymbols : IReadOnlyList<ProdSymbol>
    {
        private List<ProdSymbol> symbols;

        private ProdSymbols(IEnumerable<ProdSymbol> symbols)
        {
            this.symbols = new List<ProdSymbol>(symbols);
        }

        public ProdSymbol this[int index] => symbols[index];
        public int Count => symbols.Count;

        public static ProdSymbols From(IEnumerable<ProdSymbol> symbols)
        {
            return new ProdSymbols(symbols);
        }

        public IEnumerator<ProdSymbol> GetEnumerator() => symbols.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public override bool Equals(object obj)
        {
            return obj is ProdSymbols other && this.SequenceEqual(other);
        }

        public override int GetHashCode()
        {
            var hash = new HashCode();
            foreach (var symbol in symbols)
            {
                hash.Add(symbol);
            }

            return hash.ToHashCode(); ;
        }
    }
}
