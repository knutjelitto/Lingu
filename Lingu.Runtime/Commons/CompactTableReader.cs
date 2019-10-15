using Lingu.Runtime.Structures;

#nullable enable

namespace Lingu.Runtime.Commons
{
    public class CompactTableReader
    {
        private readonly BinReader reader;

        public CompactTableReader(BinReader reader)
        {
            this.reader = reader;
        }

        public IParseTable Read()
        {
            var numberOfStates = this.reader.ReadInt32();
            var numberOfTerminals = this.reader.ReadInt32();
            var numberOfSymbols = this.reader.ReadInt32();
            var numberOfNonterminals = numberOfSymbols - numberOfTerminals;

            var compactTerminalCount = this.reader.ReadInt32();
            var compactTerminals = new int[compactTerminalCount][];
            for (var i = 0; i < compactTerminalCount; ++i)
            {
                var compacts = new int[numberOfTerminals];
                for (var c = 0; c < numberOfTerminals; ++c)
                {
                    compacts[c] = this.reader.ReadInt32();
                }
                compactTerminals[i] = compacts;
            }

            var compactNonterminalCount = this.reader.ReadInt32();
            var compactNonterminals = new int[compactNonterminalCount][];
            for (var i = 0; i < compactNonterminalCount; ++i)
            {
                var compacts = new int[numberOfNonterminals];
                for (var c = 0; c < numberOfNonterminals; ++c)
                {
                    compacts[c] = this.reader.ReadInt32();
                }
                compactNonterminals[i] = compacts;
            }

            var states = new CompactState[numberOfStates];
            for (var i = 0; i < states.Length; ++i)
            {
                var terminalMin = reader.ReadInt32();
                var terminalIndex = reader.ReadInt32();
                var nonterminalMin = reader.ReadInt32();
                var nonterminalIndex = reader.ReadInt32();

                var state = new CompactState(
                    terminalMin, compactTerminals[terminalIndex],
                    nonterminalMin, compactNonterminals[nonterminalIndex]);

                states[i] = state;
            }

            return new CompactParseTable(states, numberOfTerminals, numberOfSymbols);
        }
    }
}
