using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using Lingu.LR;
using Lingu.Runtime.Structures;

#nullable enable

namespace Lingu.Grammars
{
    public class Production : IReadOnlyList<Symbol>, IProduction
    {
        public Production(Nonterminal nonterminal, SymbolList symbols, Bools drops, Bools promotes)
        {
            Id = -1;

            Nonterminal = nonterminal;
            Symbols = symbols;
            Drops = drops;
            Promotes = promotes;

            //Debug.Assert(!IsPromote);
        }

        public int Id { get; set; }

        public Nonterminal Nonterminal { get; }
        INonterminal IProduction.Nonterminal => Nonterminal;

        public SymbolList Symbols { get; }
        public Bools Drops { get; }
        public Bools Promotes { get; }
        public bool IsPromote => Promotes.Any(p => p);

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

        public string ToStringArrow()
        {
            return $"{Nonterminal} -> {ToString()}";
        }

        public override string ToString()
        {
            return string.Join(" ", Enumerate(this));

            IEnumerable<ProdSymbol> Enumerate(Production p)
            {
                for (var i = 0; i < p.Symbols.Count; ++i)
                {
                    yield return new ProdSymbol(p.Symbols[i], p.Drops[i], p.Promotes[i]);
                }
            }
        }
    }
}
