﻿namespace Lingu.Runtime.Parsing
{
    public class SimpleParseTable : ParseTable<TableItem>
    {
        private readonly TableItem[,] table;

        public SimpleParseTable(TableItem[,] table, int numberOfTerminals)
            : base(table.GetLength(0), numberOfTerminals, table.GetLength(1))
        {
            this.table = table;
        }

        public override TableItem this[int stateNo, int symNo] => table[stateNo, symNo];
    }
}
