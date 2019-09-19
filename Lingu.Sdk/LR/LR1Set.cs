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
        public LR1Set()
        {
        }

        public LR1Set(params LR1[] items)
            : base(items)
        {
        }

        public override LR1Set Close()
        {
            throw new NotImplementedException();
        }
    }
}
