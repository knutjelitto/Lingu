using System;
using System.Collections.Generic;
using System.Text;

namespace Lingu.Runtime.Parsing
{
    public abstract class ParseTable
    {
        public ParseTable(int numberOfStates, int numberOfTerminals, int numberOfSymbols)
        {
            NumberOfStates = numberOfStates;
            NumberOfTerminals = numberOfTerminals;
            NumberOfSymbols = numberOfSymbols;
        }

        public int NumberOfStates { get; }
        public int NumberOfTerminals { get; }
        public int NumberOfSymbols { get; }

        public abstract TableItem this[int stateNo, int symNo] { get; }
    }
}
