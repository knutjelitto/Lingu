using System;
using System.Collections.Generic;
using System.Text;

namespace Lingu.Runtime.LexDfa
{
    public struct DfaInterval
    {
        public readonly int Min;
        public readonly int Max;

        public DfaInterval(int min, int max)
        {
            Min = min;
            Max = max;
        }
    }
}
