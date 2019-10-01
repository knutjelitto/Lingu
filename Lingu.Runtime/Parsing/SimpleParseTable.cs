namespace Lingu.Runtime.Parsing
{
    public class SimpleParseTable : ParseTable
    {
        private readonly TableItem[,] table;

        public SimpleParseTable(TableItem[,] table, int numberOfTerminals)
            : base(table.GetLength(0), table.GetLength(1), numberOfTerminals)
        {
            this.table = table;
        }

        public override TableItem this[int stateNo, int symNo] => table[stateNo, symNo];
    }
}
