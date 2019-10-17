using System;
using System.Collections.Generic;
using System.Text;
using Lingu.Runtime.Parsing;
using Lingu.Runtime.Structures;

namespace Lingu.Runtime.Commons
{
    public class CompactItem : IStateItem
    {
        public CompactItem(int value)
        {
            Coded = value;
        }

        public ParseAction Action => (ParseAction)(Coded & (int)ParseAction.Reduce);
        public int Number => Coded >> 2;
        public int Coded { get; }

        public override string ToString()
        {
            return $"[{Action} {Number}]";
        }
    }
}
