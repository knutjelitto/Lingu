using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Lingu.Grammars
{
    public class Production : IReadOnlyList<ProdSymbol>
    {
        public Production(Nonterminal nonterminal, ProdSymbols symbols)
        {
            Symbols = symbols;
            Nonterminal = nonterminal;
        }

        public Nonterminal Nonterminal { get; }
        public ProdSymbols Symbols { get; }

        public ProdSymbol this[int index] => Symbols[index];
        public int Count => Symbols.Count;

        public IEnumerator<ProdSymbol> GetEnumerator() => Symbols.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
