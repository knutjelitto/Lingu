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
            Coded = (ushort) value;
        }

        public TableItem Action => (TableItem)(Coded & (ushort)TableItem.ActionBits);
        public int Number => Coded >> 2;
        public ushort Coded { get; set; }
    }
}
