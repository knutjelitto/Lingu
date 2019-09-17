using System;
using System.Collections.Generic;
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
            Add(new LR0(dotted, new Error()));
        }

        public override LR0Set NewEmpty()
        {
            return new LR0Set();
        }
    }
}
