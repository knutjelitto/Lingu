using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using Lingu.Runtime.Concretes;
using Lingu.Runtime.Structures;

namespace Lingu.Runtime.Parsing
{
    public class U16ParseTable : ParseTable
    {
        private U16ParseTable(IReadOnlyList<IState> table, int numberOfStates, int numberOfSymbols, int numberOfTerminals)
            : base(numberOfStates, numberOfSymbols, numberOfTerminals)
        {
            Table = table;
        }

        public static U16ParseTable From(ushort[] table, int numberOfStates, int numberOfTerminals, int numberOfSymbols)
        {
            Debug.Assert(numberOfStates * numberOfSymbols == table.Length);

            var states = new List<IState>();

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
            IEnumerable<ushort> EnumStateItems()
            {
                for (var row = 0; row < table.GetLength(0); row += 1)
                {
                    for (var col = 0; col < table.GetLength(1); col += 1)
                    {
                        yield return (ushort)table[row, col];
                    }
                }
            }

            return From(EnumStateItems().ToArray(), table.GetLength(0), numberOfTerminals, table.GetLength(1));
        }

        private IReadOnlyList<IState> Table { get; }

        public override IEnumerable<IStateItem> ReallyAll
        {
            get
            {
                foreach (var state in Table)
                {
                    foreach (var item in state.All)
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
