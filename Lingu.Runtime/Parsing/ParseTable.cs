using System.Collections;
using System.Collections.Generic;

namespace Lingu.Runtime.Parsing
{
    public abstract class ParseTable : IEnumerable<TableItem>
    {
        public ParseTable(int numberOfStates, int numberOfSymbols, int numberOfTerminals)
        {
            NumberOfStates = numberOfStates;
            NumberOfSymbols = numberOfSymbols;
            NumberOfTerminals = numberOfTerminals;
        }

        public int NumberOfStates { get; }
        public int NumberOfSymbols { get; }
        public int NumberOfTerminals { get; }

        public abstract TableItem this[int stateNo, int symNo] { get; }

        public IEnumerator<TableItem> GetEnumerator()
        {
            for (var row = 0; row < NumberOfStates; row += 1)
            {
                for (var col = 0; col < NumberOfSymbols; col += 1)
                {
                    yield return this[row, col];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
