using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Lingu.LR;
using Lingu.Runtime.Structures;

#nullable enable

namespace Lingu.Grammars
{
    public class Production : IReadOnlyList<Symbol>, IProduction
    {
        public Production(Nonterminal nonterminal, SymbolList symbols, Drops drops)
        {
            Nonterminal = nonterminal;
            Symbols = symbols;
            Drops = drops;
            Id = -1;
        }

        public Nonterminal Nonterminal { get; }
        INonterminal IProduction.Nonterminal => Nonterminal;

        public SymbolList Symbols { get; }
        public Drops Drops { get; }
        public int Id { get; set; }
        public CoreFactory? ItemFactory { get; set; }

        public Core? Initial => ItemFactory?.Get(this, 0);

        public Symbol this[int index] => Symbols[index];
        public int Count => Symbols.Count;
        public int Length => Symbols.Count;
        public int DropLength => Drops.Count(b => !b);
        public bool IsEpsilon => Count == 0;

        public IEnumerable<IToken> DropFilter(IEnumerable<IToken> tokens)
        {
            return Drops.Zip(tokens).Where(x => !x.First).Select(x => x.Second);
        }

        public IEnumerator<Symbol> GetEnumerator() => Symbols.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public override bool Equals(object? obj) => obj is Production other && Id == other.Id;
        public override int GetHashCode() => Id;

        public string ToStringSymbols()
        {
            return string.Join(" ", Symbols);
        }

        public string ToStringArrow()
        {
            return $"{Nonterminal} -> {ToStringSymbols()}";
        }

        public override string ToString()
        {
            return $"/*{Id}*/ {string.Join(" ", Symbols.Zip(Drops, (s, d) => new ProdSymbol(s, d)))}";
        }
    }
}
