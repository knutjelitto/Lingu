using System.Linq;

using Lingu.Automata;
using Lingu.Commons;
using Lingu.Grammars;

#nullable enable

namespace Lingu.Build
{
    public class CompactDfaWriter
    {
        private readonly Grammar Grammar;
        private readonly BinWriter writer;

        public CompactDfaWriter(Grammar grammar)
        {
            this.Grammar = grammar;
            this.writer = new BinWriter();
        }

        public byte[] Write()
        {
            var dfas = Grammar.Dfas.Concat(Enumerable.Repeat(Grammar.SpacingDfa, 1)).ToList();
            var sets = new UniqueList<Integers>();

            for (var i = 0; i < dfas.Count; ++i)
            {
                var dfa = dfas[i];

                foreach (var state in dfa.States)
                {
                    foreach (var transition in state.Transitions)
                    {
                        transition.SetId = sets.MaybeAlreadyAdd(transition.Set);
                    }
                }
            }

            this.writer.Write(this.Grammar.StateToDfa.Count);
            this.writer.Write(this.Grammar.StateToDfa);

            this.writer.Write(sets.Count);
            foreach (var set in sets)
            {
                var intervals = set.GetIntervals().ToList();
                this.writer.Write(intervals.Count);
                foreach (var (min, max) in intervals)
                {
                    this.writer.Write(min);
                    this.writer.Write(max);
                }
            }

            this.writer.Write(dfas.Count);
            foreach (var dfa in dfas)
            {
                this.writer.Write(dfa.States.Count);
                foreach (var state in dfa.States)
                {
                    this.writer.Write(state.Final);
                    this.writer.Write(state.Payload + 1);
                }
                foreach (var state in dfa.States)
                {
                    this.writer.Write(state.Transitions.Count);
                    foreach (var transition in state.Transitions)
                    {
                        this.writer.Write(transition.SetId);
                        this.writer.Write(transition.TargetId);
                    }
                }
            }

            return this.writer.ToArray();
        }
    }
}
