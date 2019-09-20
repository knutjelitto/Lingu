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
        public LR1Set(From<LR1, LR1Set, LR1SetSet> from, params LR1[] items)
            : base(from, items)
        {
        }

        public override LR1Set Close()
        {
            throw new NotImplementedException();
        }

        public override LR1Set WithFrom(Symbol symbol)
        {
            throw new NotImplementedException();
        }
    }
}
