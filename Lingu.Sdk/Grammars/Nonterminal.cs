using System.Collections.Generic;
using System.Linq;

using Lingu.Errors;
using Lingu.Runtime.Structures;

#nullable enable

namespace Lingu.Grammars
{
    public class Nonterminal : Symbol, INonterminal
    {
        private readonly List<Production> productions;

        public Nonterminal(string name)
            : base(name)
        {
            productions = new List<Production>();
            Repeat = RepeatKind.None;
            Lift = LiftKind.None;
        }

        public RepeatKind Repeat { get; set; }
        public LiftKind Lift { get; set; }
        public bool IsLift => Lift != LiftKind.None;

        public IReadOnlyList<Production> Productions => productions;

        public void AddProductions(params IEnumerable<ProdSymbol>[] symss)
        {
            foreach (var syms in symss)
            {
                var symbols = syms.ToList();
                var thisSymbols = SymbolList.From(symbols.Select(p => p.Symbol));
                var thisDrops = new Bools(symbols.Select(p => p.IsDrop));
                var thisPromotes = new Bools(symbols.Select(p => p.IsPromote));

                var promotesCount = thisPromotes.Count(p => p);
                var dropsCount = thisDrops.Count(d => d);
                if (promotesCount > 1)
                {
                    throw new GrammarException($"nonterminal: rule `{Name}´ defines more than on promote");
                }
                if (promotesCount == 1)
                {
                    if (dropsCount != symbols.Count - 1)
                    {
                        throw new GrammarException($"nonterminal: rule `{Name}´ can only promote a single symbol");
                    }
                }
                if (symbols.Count > 0 && dropsCount == symbols.Count)
                {
                    throw new GrammarException($"nonterminal: rule `{Name}´ didn't want to drop anything in a row'");
                }

                foreach (var production in productions)
                {
                    if (production.Symbols.Equals(symbols))
                    {
                        var ss = string.Join(" ", symbols.Select(sym => sym.ToString()));
                        throw new GrammarException($"nonterminal: `{Name}´ rule `{ss}´ already defined before");
                    }
                }

                var isPromote = promotesCount == 1;

                productions.Add(new Production(this, thisSymbols, thisDrops, isPromote));
            }
        }
    }
}
