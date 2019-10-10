using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using Lingu.Automata;
using Lingu.Commons;
using Lingu.Grammars;
using Lingu.Writers;

#nullable enable

namespace Lingu.Write
{
    public class CSharpWriterDfaSet : CSharpWriterTools
    {
        private readonly CsWriter writer;

        public CSharpWriterDfaSet(CSharpContext ctx)
            : base(ctx)
        {
            this.writer = ctx.Writer;
        }

        public void Write()
        {
            var (dfas, sets) = Prepare();

            writer.Block($"public static IDfaSet CreateDfaSet()", () =>
            {
                WriteMap("int[] map = ");
                writer.WriteLine();

                WriteSets("Set[] sets = ", dfas, sets);
                writer.WriteLine();

                var numWidth = (int)Math.Log10(sets.Count) + 2;

                for (var d = 0; d < dfas.Count; ++d)
                {
                    var dfa = dfas[d];

                    Debug.Assert(Grammar.Symbols != null);
                    var terminals = PPTerminalsInDfa(dfa);

                    writer.WriteLine($"/* dfa{d.ToString().PadLeft(numWidth)} -- {terminals} -- */");
                    
                    var states = string.Join(", ", dfa.States.Select(s => $"new DfaState({s.Id},{Bool(s.Final)},{s.Payload})"));
                    states = $"new DfaState[{dfa.States.Count}] {{{states}}}";
                    writer.WriteLine($"var states{d} = {states};");

                    for (var s = 0; s < dfa.States.Count; ++s)
                    {
                        var state = dfa.States[s];

                        string transitions;
                        if (state.Transitions.Count == 0)
                        {
                            transitions = $"Array.Empty<DfaTrans>()";
                        }
                        else
                        {
                            transitions = string.Join(", ", state.Transitions.Select(t => $"new DfaTrans(states{d}[{t.TargetId}], sets[{t.SetId}])"));
                            transitions = $"new DfaTrans[{state.Transitions.Count}] {{{transitions}}}";
                        }
                        writer.WriteLine($"states{d}[{s}].Transitions = {transitions};");
                    }
                    
                    writer.WriteLine();
                }

                writer.Data("var dfas = new Dfa[]", () =>
                {
                    WriteExtend(writer, Enumerable.Range(0, dfas.Count).Select(i => $"new Dfa(states{i})"));
                });

                writer.WriteLine();
                writer.WriteLine($"return new DfaSet(dfas, map, dfas.Last());");
            });
        }

        private string PPTerminalsInDfa(FA dfa)
        {
            Debug.Assert(Grammar.Symbols != null);
            var terminals = dfa.Finals.Where(f => f.Payload >= 0).Select(f => f.Payload).Distinct().Select(p => Grammar.Symbols[p].ToString());

            return string.Join(" | ", terminals);
        }

        private (List<FA> dfas, UniqueList<Integers> sets) Prepare()
        {
            Debug.Assert(Grammar.Dfas != null);
            Debug.Assert(Grammar.SpacingDfa != null);

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

            return (dfas, sets);
        }

        private void WriteMap(string head)
        {
            Debug.Assert(Grammar.StateToDfa != null);
            writer.Data(head, () =>
            {
                WriteExtend(writer, Grammar.StateToDfa.Select(i => i.ToString()));
            });
        }

        private void WriteSets(string head, IReadOnlyList<FA> dfas, UniqueList<Integers> sets)
        {

            writer.Data(head, () =>
            {
                var numWidth = (int)Math.Log10(sets.Count) + 2;
                for (var i = 0; i < sets.Count; ++i)
                {
                    var tuples = string.Join(", ", sets[i].GetIntervals().Select(minmax => $"new Interval({minmax.Min},{minmax.Max})"));
                    var num = i.ToString().PadLeft(numWidth);

                    writer.WriteLine($"/*{num} */ new Set({tuples}),");
                }
            });
        }
    }
}
