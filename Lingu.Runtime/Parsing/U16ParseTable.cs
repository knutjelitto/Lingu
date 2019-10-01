using System;

namespace Lingu.Runtime.Parsing
{
    public class U16ParseTable : ParseTable
    {
        public U16ParseTable(ushort[] table, int numberOfStates, int numberOfTerminals, int numberOfSymbols)
            : base(numberOfStates, numberOfSymbols, numberOfTerminals)
        {
            Table = table;
        }

        public override TableItem this[int stateNo, int symNo]
        {
            get
            {
                var index = (stateNo * NumberOfSymbols) + symNo;
                return (TableItem)Table[index];
            }
        }

        public static U16ParseTable From(TableItem[,] table, int numberOfTerminals)
        {
            var shorts = new UInt16[table.Length];
            var i = 0;

            for (var row = 0; row < table.GetLength(0); row += 1)
            {
                for (var col = 0; col < table.GetLength(1); col += 1)
                {
                    shorts[i] = (ushort)table[row, col];
                    i += 1;
                }
            }

            return new U16ParseTable(shorts, table.GetLength(0), numberOfTerminals, table.GetLength(1));
        }

        private ushort[] Table { get; }
    }
}
