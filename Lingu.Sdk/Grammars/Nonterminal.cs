using System;
using System.Collections.Generic;
using System.Linq;
using Lingu.Errors;
using Lingu.Writers;

namespace Lingu.Grammars
{
    public class Nonterminal : Rule
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
        public bool IsLift => Lift != LiftKind.None;
        public LiftKind Lift { get; set; }

        public IReadOnlyList<Production> Productions => productions;

        public void AddProductions(params IEnumerable<ProdSymbol>[] symss)
        {
            foreach (var syms in symss)
            {
                var symbols = ProdSymbols.From(syms);

                foreach (var production in productions)
                {
                    if (production.Symbols.Equals(symbols))
                    {
                        var ss = string.Join(" ", symbols.Select(sym => sym.ToString()));
                        throw new GrammarException($"nonterminal: `{Name}´ rule `{ss}´ already defined before");
                    }
                }

                productions.Add(new Production(this, symbols));
            }
        }

        public override void Dump(IndentWriter writer)
        {
            var p = IsPrivate ? "private " : "";
            var l = Li();

            writer.Indend($"{Name} // {p}{l}({Id})", () =>
            {
                bool more = false;
                foreach (var production in Productions)
                {
                    if (more)
                    {
                        writer.Write("| ");
                    }
                    else
                    {
                        writer.Write(": ");
                    }
                    more = true;

                    writer.WriteLine(string.Join(" ", production));
                }
                writer.WriteLine(";");
            });

            string Li()
            {
                switch (Lift)
                {
                    case LiftKind.User:
                        return "(^^) ";
                    case LiftKind.Optional:
                        return "(^?) ";
                    case LiftKind.Star:
                        return "(^*) ";
                    case LiftKind.Plus:
                        return "(^+) ";
                    case LiftKind.Alternate:
                        return "(^|) ";
                    default:
                        return string.Empty;
                }
            }
        }
    }
}
