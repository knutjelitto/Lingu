using System.Collections.Generic;

using Lingu.Runtime.Structures;

namespace Lingu.Runtime.Parsing
{
    public abstract class ParseTable : ITable
    {
        public ParseTable(int numberOfStates, int numberOfTerminals, int numberOfSymbols)
        {
            NumberOfStates = numberOfStates;
            NumberOfTerminals = numberOfTerminals;
            NumberOfSymbols = numberOfSymbols;
        }

        public abstract IState this[int stateNo] { get; }

        public int NumberOfStates { get; }
        public int NumberOfTerminals { get; }
        public int NumberOfSymbols { get; }

        public abstract IEnumerable<IStateItem> ReallyAll { get; }
    }
}
