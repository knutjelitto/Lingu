using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using Lingu.Grammars;

#nullable enable

namespace Lingu.LR
{
    public class LR0Set : ItemSet<LR0, LR0Set>
    {
        public LR0Set()
        {
        }

        public LR0Set(params LR0[] items)
            : base(items)
        {
        }

        public override Item.Patch Add(Core dotted)
        {
            if (!dotted.IsComplete && dotted.PostDot is Terminal)
            {
                var shift = new Shift(-1);
                var item = new LR0(dotted, shift);
                var patch = new Item.Patch(item, state => shift.Patch(state));

                Add(item);
                return patch;
            }
            else
            {
                var item = new LR0(dotted);
                Add(item);
                return new Item.Patch(item, x => { });
            }
        }
    }
}
