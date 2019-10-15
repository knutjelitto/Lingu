using System;
using System.Collections.Generic;

using Lingu.Runtime.Concretes;
using Lingu.Runtime.Parsing;
using Lingu.Runtime.Structures;

namespace Lingu.Build
{
    public class ParseTable : IParseTable
    {
        private ParseTable(IReadOnlyList<SimpleState> table, int numberOfStates, int numberOfTerminals, int numberOfSymbols)
        {
            Table = table;
            NumberOfStates = numberOfStates;
            NumberOfTerminals = numberOfTerminals;
            NumberOfSymbols = numberOfSymbols;
        }

        public IState this[int stateNo] => Table[stateNo];
        public IStateItem this[int stateNo, int symNo] => this[stateNo][symNo];

        public int NumberOfStates { get; }
        public int NumberOfTerminals { get; }
        public int NumberOfSymbols { get; }

        private IReadOnlyList<SimpleState> Table { get; }

        public static ParseTable From(ParseAction[,] table, int numberOfTerminals)
        {
            var intse = new int[table.GetLength(0) * table.GetLength(1)];
            var idx = 0;
            for (var row = 0; row < table.GetLength(0); row += 1)
            {
                for (var col = 0; col < table.GetLength(1); col += 1)
                {
                    intse[idx++] = (int)table[row, col];
                }
            }

            return From(intse, table.GetLength(0), numberOfTerminals, table.GetLength(1));
        }

        private static ParseTable From(int[] table, int numberOfStates, int numberOfTerminals, int numberOfSymbols)
        {
            var num = numberOfStates * numberOfSymbols;

            var states = new List<SimpleState>();

            for (var offset = 0; offset < table.Length; offset += numberOfSymbols)
            {
                var items = new ArraySegment<int>(table, offset, numberOfSymbols);
                var state = new SimpleState(items, numberOfTerminals);
                states.Add(state);

            }

            return new ParseTable(states, numberOfStates, numberOfTerminals, numberOfSymbols);
        }


    }
}
