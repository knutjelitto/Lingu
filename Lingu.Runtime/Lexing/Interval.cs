using System;
using System.Collections.Generic;
using System.Text;

namespace Lingu.Runtime.Lexing
{
    public struct Interval
    {
        public readonly int Min;
        public readonly int Max;

        public Interval(int min, int max)
        {
            Min = min;
            Max = max;
        }
    }
}
