using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Lingu.Grammars
{
    public class SymbolList : IReadOnlyList<Symbol>
    {
        private SymbolList(IEnumerable<Symbol> symbols)
        {
            this.symbols = new List<Symbol>(symbols);
        }

        public Symbol this[int index] => symbols[index];
        public int Count => symbols.Count;

        public static SymbolList From(IEnumerable<Symbol> symbols)
        {
            return new SymbolList(symbols);
        }

        public IEnumerator<Symbol> GetEnumerator() => symbols.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public override bool Equals(object obj)
        {
            return obj is SymbolList other && Count == other.Count && !this.Zip(other, (t, o) => t.Name.Equals(o.Name, StringComparison.Ordinal)).Any(c => c);
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

        private readonly List<Symbol> symbols;
    }
}
