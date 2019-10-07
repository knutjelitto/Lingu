using System;
using System.Collections.Generic;
using System.Linq;

namespace Lingu.Runtime.Lexing
{
    public struct Set
    {
        public readonly Interval[] Intervals;

        public Set(params Interval[] intervals)
        {
            Intervals = intervals;
        }

        public Set(params (int min, int max)[] intervals)
        {
            Intervals = intervals.Select(minmax => new Interval(minmax.min, minmax.max)).ToArray();
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

        public override string ToString()
        {
            return string.Join(", ", Intervals);
        }
    }
}
