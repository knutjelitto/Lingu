using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Lingu.Grammars
{
    public class Production : IReadOnlyList<Symbol>
    {
        public Production(Nonterminal nonterminal, Symbols symbols)
        {
            Symbols = symbols;
            Nonterminal = nonterminal;
        }

        public Nonterminal Nonterminal { get; }
        public Symbols Symbols { get; }

        public Symbol this[int index] => Symbols[index];
        public int Count => Symbols.Count;

        public IEnumerator<Symbol> GetEnumerator() => Symbols.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
