using Lingu.Runtime.Parsing;
using Lingu.Runtime.Structures;
using System.Globalization;

namespace Lingu.Runtime.Concretes
{
    public struct StateItem : IStateItem
    {
        public StateItem(TableItem action, int actionNumber)
            : this((ushort)((actionNumber << 2) | (int)action))
        {
        }

        public StateItem(ushort coded)
        {
            Coded = coded;
        }

        public TableItem Action => (TableItem)(Coded & (ushort)TableItem.ActionBits);
        public int Number => Coded >> 2;
        public ushort Coded { get; }

        public override string ToString()
        {
            return Coded.ToString(CultureInfo.InvariantCulture);
        }
    }
}
