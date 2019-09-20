using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using Lingu.Grammars;

#nullable enable

namespace Lingu.LR
{
    public class LR1Set : ItemSet<LR1, LR1Set, LR1SetSet>
    {
        public LR1Set(From<LR1, LR1Set, LR1SetSet>? from, params LR1[] items)
            : base(from, items)
        {
        }

        public override LR1Set WithFrom(Symbol symbol)
        {
            return new LR1Set(new From<LR1, LR1Set, LR1SetSet>(this, symbol));
        }

        public override LR1Set Close()
        {
            for (var i = 0; i < Count; ++i)
            {
                var from = this[i];

                if (!from.IsComplete && from.PostDot is Nonterminal nonterminal)
                {
                    var lookahead = new TerminalSet(from.Core.Next.First);
                    if (lookahead.WithEpsilon)
                    {
                        lookahead.UnionWith(from.Lookahead);
                        lookahead.WithEpsilon = false;
                    }

                    foreach (var production in nonterminal.Productions)
                    {
                        var add = true;
                        foreach (var old in this)
                        {
                            if (old.Core.Equals(production.Initial))
                            {
                                old.Lookahead.UnionWith(lookahead);
                                add = false;
                                break;
                            }
                        }
                        if (add)
                        {
                            Add(new LR1(production.Initial, false, lookahead));
                        }
                    }
                }
            }

            Freeze();

            return this;
        }
    }
}
