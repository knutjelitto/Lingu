using System;
using System.Collections.Generic;
using System.Text;

namespace Lingu.Runtime.Lexing
{
    public struct DfaTrans
    {
        public readonly DfaState Target;
        public readonly Set Set;

        public DfaTrans(DfaState target, Set set)
        {
            Target = target;
            Set = set;
        }
    }
}
