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
                var thisDrops = new Drops(symbols.Select(p => p.IsDrop));

                foreach (var production in productions)
                {
                    if (production.Symbols.Equals(symbols))
                    {
                        var ss = string.Join(" ", symbols.Select(sym => sym.ToString()));
                        throw new GrammarException($"nonterminal: `{Name}´ rule `{ss}´ already defined before");
                    }
                }

                productions.Add(new Production(this, thisSymbols, thisDrops));
            }
        }
    }
}
