using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Lingu.Automata;
using Lingu.Commons;
using Lingu.Grammars;
using Lingu.Runtime.Commons;
using Lingu.Runtime.Parsing;
using BinWriter = Lingu.Commons.BinWriter;

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
            Debug.Assert(Grammar.Dfas != null);
            Debug.Assert(Grammar.StateToDfa != null);
            Debug.Assert(Grammar.SpacingDfa != null);

            //BuildDfaSets();

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

            var bytes = this.writer.ToArray();

            var reader = new BinReader(bytes);

            var decoder = new CompactDfaReader(reader);

            var dfaSet = decoder.Read();

            return bytes;
        }

        private (IReadOnlyList<int> map, IReadOnlyList<FA> dfas) BuildDfaSets()
        {
            Debug.Assert(Grammar.ParseTable != null);

            var terminalSets = new List<Integers>();

            for (var stateNo = 0; stateNo < Grammar.ParseTable.NumberOfStates; ++stateNo)
            {
                var terminalSet = new Integers();

                for (var symNo = 0; symNo < Grammar.ParseTable.NumberOfTerminals; ++symNo)
                {
                    switch (Grammar.ParseTable[stateNo][symNo].Action)
                    {
                        case TableItem.Accept:
                        case TableItem.Shift:
                        case TableItem.Reduce:
                            terminalSet.Add(symNo);
                            break;
                    }
                }

                Debug.Assert(!terminalSet.IsEmpty);
                terminalSets.Add(terminalSet);
            }

            var ts = new List<(Terminal terminal, int index)>(Grammar.Terminals.Where(t => t.IsPid).Select((t, i) => (t, i)));
            var terminals = Grammar.Terminals.Where(t => t.IsPid).ToList();
            var tDfas = Enumerable.Repeat(FA.None(), terminals.Count).ToArray();

            var result = Parallel.ForEach(ts, x =>
            {
                var terminal = x.terminal;
                var index = x.index;
                var fa = terminal.Raw.Expression.GetFA();
                fa = fa.ToDfa();
                fa = fa.Minimize();
                fa = fa.RemoveDead();

                foreach (var state in fa.Finals)
                {
                    state.SetPayload(terminal.Id);
                }
                tDfas[index] = fa;
            });

            Debug.Assert(result.IsCompleted);

            var terminalDfas = tDfas.ToList();
            var already = new Dictionary<Integers, int>();
            var stateToDfas = new List<int>();

            foreach (var terminalSet in terminalSets)
            {
                Debug.Assert(!terminalSet.IsEmpty);

                if (!already.TryGetValue(terminalSet, out var index))
                {
                    index = already.Count;

                    already.Add(terminalSet, already.Count);

                }

                stateToDfas.Add(index);
            }

            var dfas = Enumerable.Repeat(FA.None(), already.Count).ToArray();

            result = Parallel.ForEach(already, kv =>
            {
                var terminalSet = kv.Key;
                var index = kv.Value;

                FA dfa;
                if (terminalSet.Cardinality == 1)
                {
                    dfa = terminalDfas[terminalSet.Single()].Clone().RemoveDead();
                }
                else
                {
                    dfa = Combine(terminalSet.Select(i => terminalDfas[i]));
                }

                var finals = dfa.Finals.Select(s => s.Payload).Distinct().OrderBy(p => p).ToList();
                var numbers = terminalSet.Distinct().OrderBy(p => p).ToList();
                Debug.Assert(finals.SequenceEqual(numbers));

                dfas[index] = dfa;
            });

            FA Combine(IEnumerable<FA> fas)
            {
                FA combined = fas.First().Clone();
                foreach (var fa in fas.Skip(1))
                {
                    combined = combined.Union(fa, true);
                }
                return combined;
            }

            Debug.Assert(result.IsCompleted);
            Debug.Assert(Grammar.Table != null);
            Debug.Assert(stateToDfas.Count == Grammar.ParseTable.NumberOfStates);

            Grammar.Dfas = dfas.ToArray();
            Grammar.StateToDfa = stateToDfas;

            return (stateToDfas, dfas.ToArray());
        }

    }
}
