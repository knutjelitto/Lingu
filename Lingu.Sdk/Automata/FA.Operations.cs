using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using Lingu.Commons;

namespace Lingu.Automata
{
    public partial class FA
    {
        private static partial class Operations
        {
            [Conditional("DEBUG")]
            private static void EnsureComplete(FA dfa)
            {
                EnsureDfa(dfa);

                foreach (var state in dfa.States)
                {
                    var all = new Integers();
                    var sum = 0;
                    foreach (var transition in state.Transitions)
                    {
                        sum += transition.Set.Cardinality;
                        all.Add(transition.Set);
                    }
                    if (!UnicodeSets.IsAny(all))
                    {
                        throw new Exception("DFA: incomplete transition set (DFA is not `complete´)");
                    }
                    if (sum != all.Cardinality)
                    {
                        throw new Exception("DFA: overlapping transitions (DFA is not `sane´)");
                    }
                }
            }

            [Conditional("DEBUG")]
            private static void EnsureDistinctTransitions(State state)
            {
                foreach (var pair in state.Transitions.GlidePairWise())
                {
                    if (pair.Left.Set.Overlaps(pair.Right.Set))
                    {
                        throw new Exception("DFA: some transitions overlap");
                    }
                }

                var i = 0;
                while (i < state.Transitions.Count)
                {
                    var trans1 = state.Transitions[i];

                    if (trans1.Set.IsEmpty)
                    {
                        throw new Exception("DFA: epsilon transition");
                    }
                    var j = i + 1;
                    while (j < state.Transitions.Count)
                    {
                        var trans2 = state.Transitions[j];
                        if (trans1.Set.Overlaps(trans2.Set))
                        {
                            throw new Exception("DFA: some transitions overlap");
                        }
                        j += 1;
                    }
                    i += 1;
                }
            }

            [Conditional("DEBUG")]
            private static void EnsureDefiniteTransitions(State state)
            {
                foreach (var transition in state.Transitions)
                {
                    if (transition.Set.IsEmpty)
                    {
                        throw new Exception("DFA: epsilon transition");
                    }
                }
            }

            [Conditional("DEBUG")]
            private static void EnsureDfaTransitions(FA dfa)
            {
                foreach (var state in dfa.States)
                {
                    EnsureDfaTransition(state);
                }
            }

            [Conditional("DEBUG")]
            private static void EnsureDfaTransition(State state)
            {
                EnsureDistinctTransitions(state);
                EnsureDefiniteTransitions(state);
            }

            [Conditional("DEBUG")]
            private static void EnsureDfa(FA dfa)
            {
                if (dfa.Final != null)
                {
                    throw new Exception("DFA: dfa.Final must be null");
                }
                if (!dfa.Finals.Any())
                {
                    throw new Exception("DFA: no final state");
                }
                if (dfa.States.Count < 1)
                {
                    throw new Exception("DFA: at least on state");
                }
                EnsureDfaTransitions(dfa);
            }

        }
    }
}
