using System;
using System.Collections.Generic;
using System.Linq;

using Lingu.Commons;
using Lingu.Runtime.Commons;
using Lingu.Runtime.Structures;

#nullable enable

namespace Lingu.Build
{
    public class CompactTableWriter
    {
        private readonly IParseTable table;
        private readonly BinWriter writer;

        public CompactTableWriter(IParseTable table)
        {
            this.table = table;
            this.writer = new BinWriter();
        }

        public byte[] Write()
        {
            var states = new StateEntry[this.table.NumberOfStates];

            var compactTerminal = new List<int[]>();

            Map(compactTerminal,
                (stateNo, min, index) => { states[stateNo].terminalMin = min; states[stateNo].terminalIndex = index; },
                stateNo => this.table[stateNo].Terminals);

            var compactNonterminal = new List<int[]>();

            Map(compactNonterminal,
                (stateNo, min, index) => { states[stateNo].nonterminalMin = min; states[stateNo].nonterminalIndex = index; },
                stateNo => this.table[stateNo].Nonterminals);

            var writer = new BinWriter();

            writer.Write(this.table.NumberOfStates);
            writer.Write(this.table.NumberOfTerminals);
            writer.Write(this.table.NumberOfSymbols);

            writer.Write(compactTerminal.Count);
            foreach (var intse in compactTerminal)
            {
                writer.Write(intse);
            }

            writer.Write(compactNonterminal.Count);
            foreach (var intse in compactNonterminal)
            {
                writer.Write(intse);
            }

            foreach (var state in states)
            {
                writer.Write(state.terminalMin);
                writer.Write(state.terminalIndex);
                writer.Write(state.nonterminalMin);
                writer.Write(state.nonterminalIndex);
            }
            
            var bytes = writer.ToArray();

            var reader = new BinReader(bytes);

            var decoder = new CompactTableReader(reader);

            var table = decoder.Read();

            return bytes;
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
