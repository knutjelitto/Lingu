using System;
using System.Collections.Generic;
using System.Text;

namespace Lingu.Runtime.LexDfa
{
    public struct DfaTrans
    {
        public readonly DfaState Target;
        public readonly DfaSet Set;

        public DfaTrans(DfaState target, DfaSet set)
        {
            Target = target;
            Set = set;
        }
    }
}
