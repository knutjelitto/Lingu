using System;
using System.Collections.Generic;
using System.Text;

namespace Lingu.Runtime.Parsing
{
    public class StringParseTable : ParseTable
    {
        public StringParseTable(string table, int numberOfStates, int numberOfTerminals, int numberOfSymbols)
            : base(numberOfStates, numberOfTerminals, numberOfSymbols)
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

        public static StringParseTable From(TableItem[,] table, int numberOfTerminals)
        {
            var builder = new StringBuilder();

            for (var row = 0; row < table.GetLength(0); row += 1)
            {
                for (var col = 0; col < table.GetLength(1); col += 1)
                {
                    builder.Append((char)table[row, col]);
                }
            }

            return new StringParseTable(builder.ToString(), table.GetLength(0), numberOfTerminals, table.GetLength(1));
        }

        private string Table { get; }
    }
}
