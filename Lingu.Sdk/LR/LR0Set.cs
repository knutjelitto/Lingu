using Lingu.Grammars;
using System.Diagnostics;

#nullable enable

namespace Lingu.LR
{
    public class LR0Set : ItemSet<LR0, LR0Set, LR0SetSet>
    {
        public LR0Set()
            : base()
        {
        }

        public LR0Set(params LR0[] items)
            : base(items)
        {
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
                        Debug.Assert(production.Initial != null);
                        Add(new LR0(production.Initial, false));
                    }
                }
            }

            Freeze();

            return this;
        }
    }
}
