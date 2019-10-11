using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using Lingu.Runtime.Concretes;

namespace Lingu.Runtime.Parsing
{
    public class CompactTable
    {
        private readonly U16ParseTable table;

        public CompactTable(U16ParseTable table)
        {
            this.table = table;

            Compact();
        }

        private void Compact()
        {
            var already = new List<ushort[]>();

            for (var stateNo = 0; stateNo < this.table.NumberOfStates; ++stateNo)
            {
                var x = ((SimpleState) this.table[stateNo]).GetTerminals().ToArray().Select(s => s.Coded).ToArray();
                var min = x.Where(i => i > 0).Min() - 1;
                x = x.Select(i => i > 0 ? (ushort)(i - min) : i).ToArray();

                var found = false;
                foreach (var check in already)
                {
                    if (x.SequenceEqual(check))
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    already.Add(x);
                }
            }
        }

        private struct TerminalSpan
        {
#if false
            private TableItem item;
            private int number;
            private ushort[] symbols;
#endif
        }
    }
}
