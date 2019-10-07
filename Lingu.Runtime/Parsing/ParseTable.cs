using System.Collections.Generic;

using Lingu.Runtime.Structures;

namespace Lingu.Runtime.Parsing
{
    public abstract class ParseTable : ITable
    {
        public ParseTable(int numberOfStates, int numberOfSymbols, int numberOfTerminals)
        {
            NumberOfStates = numberOfStates;
            NumberOfSymbols = numberOfSymbols;
            NumberOfTerminals = numberOfTerminals;
        }

        public abstract IState this[int stateNo] { get; }

        public int NumberOfStates { get; }
        public int NumberOfSymbols { get; }
        public int NumberOfTerminals { get; }

        public abstract IEnumerable<IStateItem> ReallyAll { get; }
    }
}
