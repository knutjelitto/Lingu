using System;
using System.Collections.Generic;
using System.Linq;

using Lingu.Commons;
using Lingu.Output;
using Lingu.Runtime.Structures;

#nullable enable

namespace Lingu.Build
{
    public class CompactTableWriter
    {
        private readonly IParseTable table;

        public CompactTableWriter(IParseTable table)
        {
            this.table = table;

        }

        public void Dump(IWriter writer)
        {
            var states = new StateEntry[table.NumberOfStates];

            var compactTerminal = new List<int[]>();

            Map(compactTerminal,
                (stateNo, min, index) => { states[stateNo].terminalMin = min; states[stateNo].terminalIndex = index; },
                stateNo => this.table[stateNo].Terminals);

            var compactNonterminal = new List<int[]>();

            Map(compactNonterminal,
                (stateNo, min, index) => { states[stateNo].nonterminalMin = min; states[stateNo].nonterminalIndex = index; },
                stateNo => this.table[stateNo].Nonterminals);

            writer.WriteLine($"table-size: {table.NumberOfStates} x 4 x 2 bytes");
            writer.WriteLine($"          + {compactTerminal.Count} x {compactTerminal[0].Length} x 2 bytes");
            writer.WriteLine($"          + {compactNonterminal.Count} x {compactNonterminal[0].Length} x 2 bytes");
            writer.WriteLine($"          = {2* (table.NumberOfStates * 4 + compactTerminal.Count * compactTerminal[0].Length + compactNonterminal.Count * compactNonterminal[0].Length)} bytes");

            var bin = new BinWriter();

            bin.Write(this.table.NumberOfStates);
            bin.Write(this.table.NumberOfTerminals);
            bin.Write(this.table.NumberOfSymbols);

            bin.Write(compactTerminal.Count);
            foreach (var intse in compactTerminal)
            {
                bin.Write(intse);
            }

            bin.Write(compactNonterminal.Count);
            foreach (var intse in compactNonterminal)
            {
                bin.Write(intse);
            }

            foreach (var state in states)
            {
                bin.Write(state.terminalMin);
                bin.Write(state.terminalIndex);
                bin.Write(state.nonterminalMin);
                bin.Write(state.nonterminalIndex);
            }
            
            var bytes = bin.ToArray();
            writer.WriteLine($"          = {bytes.Length} bytes compressed");
        }

        private struct StateEntry
        {
            public int terminalMin;
            public int terminalIndex;
            public int nonterminalMin;
            public int nonterminalIndex;
        }

        private void Map(List<int[]> compact, Action<int, int, int> map, Func<int, IEnumerable<IStateItem>> make)
        {
            for (var stateNo = 0; stateNo < this.table.NumberOfStates; ++stateNo)
            {
                var codes = make(stateNo).Select(s => (int)s.Coded).ToArray();

                int min;
                if (codes.Any(i => i > 0))
                {
                    min = codes.Where(i => i > 0).Min() - 1;
                }
                else
                {
                    min = 0;
                }
                codes = codes.Select(i => i > 0 ? (ushort)(i - min) : i).ToArray();

                var foundTerminal = false;
                for (int i = 0; i < compact.Count; i++)
                {
                    int[] check = compact[i];
                    if (codes.SequenceEqual(check))
                    {
                        map(stateNo, min, i);
                        foundTerminal = true;
                        break;
                    }
                }
                if (!foundTerminal)
                {
                    map(stateNo, min, compact.Count);
                    compact.Add(codes);
                }
            }
        }
    }
}
