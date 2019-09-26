using System;
using System.Collections.Generic;
using System.Text;

namespace Lingu.Runtime.Lexing
{
    public struct Set
    {
        public readonly Interval[] Intervals;

        public Set(Interval[] intervals)
        {
            Intervals = intervals;
        }

        public bool Match(int value)
        {
            for (var i = 0; i < Intervals.Length; ++i)
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
