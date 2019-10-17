using Lingu.Runtime.Parsing;
using Lingu.Runtime.Structures;
using System.Globalization;

namespace Lingu.Runtime.Concretes
{
    public struct StateItem : IStateItem
    {
        public StateItem(int coded)
        {
            Coded = coded;
        }

        public ParseAction Action => (ParseAction)(Coded & (int)ParseAction.Reduce);
        public int Number => Coded >> 2;
        public int Coded { get; }

        public override string ToString()
        {
            return Coded.ToString(CultureInfo.InvariantCulture);
        }
    }
}
