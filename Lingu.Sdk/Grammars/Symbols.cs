using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lingu.Grammars
{
    public class Symbols : IReadOnlyList<Symbol>
    {
        private List<Symbol> symbols;

        private Symbols(IEnumerable<Symbol> symbols)
        {
            this.symbols = new List<Symbol>(symbols);
        }

        public Symbol this[int index] => symbols[index];
        public int Count => symbols.Count;

        public static Symbols From(IEnumerable<Symbol> symbols)
        {
            return new Symbols(symbols);
        }

        public IEnumerator<Symbol> GetEnumerator() => symbols.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public override bool Equals(object obj)
        {
            return obj is Symbols other && this.SequenceEqual(other);
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
