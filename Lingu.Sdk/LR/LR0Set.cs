using Lingu.Grammars;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

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

        public override void Add(Dotted dotted)
        {
            if (!dotted.IsComplete && dotted.PostDot is Terminal)
            {
                Add(new LR0(dotted, new Shift(-1)));
            }
            else
            {
                Add(new LR0(dotted, new Error()));
            }
        }
    }
}
