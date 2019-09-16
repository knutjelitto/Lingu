using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Lingu.Grammars
{
    public class Production : IReadOnlyList<Symbol>
    {
        public Production(Nonterminal nonterminal, SymbolList symbols, Drops drops)
        {
            Nonterminal = nonterminal;
            Symbols = symbols;
            Drops = drops;
            Id = -1;
        }

        public Nonterminal Nonterminal { get; }
        public SymbolList Symbols { get; }
        public Drops Drops { get; }
        public int Id { get; set; }

        public Symbol this[int index] => Symbols[index];
        public int Count => Symbols.Count;
        public IEnumerator<Symbol> GetEnumerator() => Symbols.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public override bool Equals(object obj) => obj is Production other && Id == other.Id;
        public override int GetHashCode() => Id;

        public override string ToString()
        {
            return $"/*{Id}*/ {string.Join(" ", Symbols.Zip(Drops, (s, d) => new ProdSymbol(s, d)))}";
        }
    }
}
