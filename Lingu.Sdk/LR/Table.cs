using System.Collections.Generic;

namespace Lingu.LR
{
    public class Table<TRow, TCol, TValue>
    {
        private Dictionary<TRow, Dictionary<TCol, TValue>> tab;

        public Table(TValue missing)
        {
            tab = new Dictionary<TRow, Dictionary<TCol, TValue>>();
            Missing = missing;
        }

        public TValue this[TRow row, TCol col]
        {
            get
            {
                if (tab.TryGetValue(row, out var column))
                {
                    if (column.TryGetValue(col, out var value))
                    {
                        return value;
                    }
                }
                return Missing;
            }
            set
            {
                if (!tab.TryGetValue(row, out var column))
                {
                    column = new Dictionary<TCol, TValue>();
                    tab.Add(row, column);
                }
                column[col] = value;
            }
        }

        public TValue Missing { get; }
    }
}
