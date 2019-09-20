using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using Lingu.Grammars;

#nullable enable

namespace Lingu.LR
{
    public class LR0Set : ItemSet<LR0, LR0Set, LR0SetSet>
    {
        public LR0Set(From<LR0, LR0Set, LR0SetSet>? from, params LR0[] items)
            : base(from, items)
        {
        }

        public override LR0Set WithFrom(Symbol symbol)
        {
            return new LR0Set(new From<LR0, LR0Set, LR0SetSet>(this, symbol));
        }

        public override LR0Set Close()
        {
            for (int i = 0; i < Count; ++i)
            {
                var from = this[i];

                if (!from.IsComplete && from.PostDot is Nonterminal nonterminal)
                {
                    foreach (var production in nonterminal.Productions)
                    {
                        Add(new LR0(production.Initial, false));
                    }
                }
            }

            Freeze();

            return this;
        }
    }
}
