using System;
using System.Collections.Generic;
using System.Text;

namespace Lingu.Runtime.LexDfa
{
    public struct DfaSet
    {
        public readonly DfaInterval[] Intervals;

        public DfaSet(DfaInterval[] intervals)
        {
            Intervals = intervals;
        }

        public bool Match(int value)
        {
            for (var i = 0; i <= Intervals.Length; ++i)
            {
                if (value <= Intervals[i].Max)
                {
                    return value >= Intervals[i].Min;
                }
            }

            return false;
        }
    }
}
