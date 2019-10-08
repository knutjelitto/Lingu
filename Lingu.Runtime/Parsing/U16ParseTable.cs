using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading;
using Lingu.Runtime.Commons;
using Lingu.Runtime.Concretes;
using Lingu.Runtime.Lexing;
using Lingu.Runtime.Structures;

namespace Lingu.Runtime.Parsing
{
    public class U16ParseTable : ParseTable
    {
        private U16ParseTable(IReadOnlyList<IState> table, int numberOfStates, int numberOfTerminals, int numberOfSymbols)
            : base(numberOfStates, numberOfTerminals, numberOfSymbols)
        {
            Table = table;
        }

        public static U16ParseTable From(ushort[] table, int numberOfStates, int numberOfTerminals, int numberOfSymbols)
        {
            var num = numberOfStates * numberOfSymbols;

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

        public static U16ParseTable FromCompressed(byte[] bytes, int uncompressed, int numberOfStates, int numberOfTerminals, int numberOfSymbols)
        {
            var memory = new MemoryStream(bytes);
            var deflate = new DeflateStream(memory, CompressionMode.Decompress);
            var buffer = new byte[uncompressed];
            deflate.Read(buffer, 0, uncompressed);
            deflate.Close();
            memory.Close();
            var binReader = new BinReader(buffer);
            var n = numberOfStates * numberOfSymbols;
            var ushorts = new ushort[n];
            for (var i = 0; i < n; ++i)
            {
                ushorts[i] = (ushort) binReader.ReadInt32();
            }

            return From(ushorts, numberOfStates, numberOfTerminals, numberOfSymbols);
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
