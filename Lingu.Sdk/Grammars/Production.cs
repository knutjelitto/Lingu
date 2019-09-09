using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Lingu.Grammars
{
    public class Production : IReadOnlyList<Symbol>
    {
        public Production(Nonterminal nonterminal, IEnumerable<Symbol> symbols)
        {
            Symbols = symbols.ToArray();
            Nonterminal = nonterminal;
        }

        public Nonterminal Nonterminal { get; }
        public IReadOnlyList<Symbol> Symbols { get; }

        public Symbol this[int index] => Symbols[index];
        public int Count => Symbols.Count;

        public IEnumerator<Symbol> GetEnumerator()
        {
            return Symbols.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
