using Lingu.Runtime.Structures;

#nullable enable

namespace Lingu.Runtime.Parsing
{
    public abstract class ParseTable : IParseTable
    {
        public ParseTable(int numberOfStates, int numberOfTerminals, int numberOfSymbols)
        {
            NumberOfStates = numberOfStates;
            NumberOfTerminals = numberOfTerminals;
            NumberOfSymbols = numberOfSymbols;
        }

        public abstract IState this[int stateNo] { get; }
        public abstract IStateItem this[int stateNo, int symNo] { get; }

        public int NumberOfStates { get; }
        public int NumberOfTerminals { get; }
        public int NumberOfSymbols { get; }
    }
}
