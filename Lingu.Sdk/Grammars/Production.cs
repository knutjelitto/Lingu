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
        public Production(Nonterminal nonterminal, SymbolList symbols, Bools drops, bool isPromote)
        {
            Id = -1;

            Nonterminal = nonterminal;
            Symbols = symbols;
            Drops = drops;
            IsPromote = isPromote;

            //Debug.Assert(!IsPromote);
        }

        public int Id { get; set; }

        public Nonterminal Nonterminal { get; }
        public bool IsPromote { get; }
        INonterminal IProduction.Nonterminal => Nonterminal;

        public SymbolList Symbols { get; }
        public Bools Drops { get; }

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
            return $"{Nonterminal} -> {string.Join(" ", Enumerate(this))}";

            IEnumerable<ProdSymbol> Enumerate(Production p)
            {
                var promotes = new Bools(p.Drops.Select(d => !d));
                if (p.IsPromote)
                {
                    Debug.Assert(p.Symbols.Count == 1 || promotes.Count(b => b) == 1);
                }

                for (var i = 0; i < p.Symbols.Count; ++i)
                {
                    yield return new ProdSymbol(p.Symbols[i], p.Drops[i], promotes[i]);
                }
            }
        }
    }
}
