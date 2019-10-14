using System;
using System.Collections.Generic;

using Lingu.Runtime.Concretes;
using Lingu.Runtime.Structures;

namespace Lingu.Runtime.Parsing
{
    public class U16ParseTable : ParseTable
    {
        private U16ParseTable(IReadOnlyList<SimpleState> table, int numberOfStates, int numberOfTerminals, int numberOfSymbols)
            : base(numberOfStates, numberOfTerminals, numberOfSymbols)
        {
            Table = table;
        }

        public static U16ParseTable From(ushort[] table, int numberOfStates, int numberOfTerminals, int numberOfSymbols)
        {
            var num = numberOfStates * numberOfSymbols;

            var states = new List<SimpleState>();

            for (var offset = 0; offset < table.Length; offset += numberOfSymbols)
            {
                var items = new ArraySegment<ushort>(table, offset, numberOfSymbols);
                var state = new SimpleState(items, numberOfTerminals);
                states.Add(state);

            }

            return new U16ParseTable(states, numberOfStates, numberOfTerminals, numberOfSymbols);
        }

        public override IState this[int stateNo] => Table[stateNo];

        public static U16ParseTable From(TableItem[,] table, int numberOfTerminals)
        {
            var ushorts = new ushort[table.GetLength(0) * table.GetLength(1)];
            var idx = 0;
            for (var row = 0; row < table.GetLength(0); row += 1)
            {
                for (var col = 0; col < table.GetLength(1); col += 1)
                {
                    ushorts[idx++] = (ushort)table[row, col];
                }
            }

            return From(ushorts, table.GetLength(0), numberOfTerminals, table.GetLength(1));
        }

        private IReadOnlyList<SimpleState> Table { get; }
    }
}
