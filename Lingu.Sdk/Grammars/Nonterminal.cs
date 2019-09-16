using System.Collections.Generic;
using System.Linq;
using Lingu.Errors;
using Lingu.Tree;
using Lingu.Writers;

namespace Lingu.Grammars
{
    public class Nonterminal : Symbol
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
                var symbols = SymbolList.From(syms.Select(p => p.Symbol));

                foreach (var production in productions)
                {
                    if (production.Symbols.Equals(symbols))
                    {
                        var ss = string.Join(" ", symbols.Select(sym => sym.ToString()));
                        throw new GrammarException($"nonterminal: `{Name}´ rule `{ss}´ already defined before");
                    }
                }

                productions.Add(new Production(this, symbols, new Drops(syms.Select(p => p.IsDrop))));
            }
        }

        public override void Dump(IndentWriter writer)
        {
        }
    }
}
