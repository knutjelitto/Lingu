using Lingu.Commons;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Lingu.Automata
{
    public partial class FA
    {
        private static class Operations
        {
            public static FA ToDfa(FA nfa)
            {
                if (nfa.Final == null)
                {
                    EnsureDfa(nfa);
                    return nfa;
                }
                var once = new UniqueQueue<Closure>();
                var start = new Closure(nfa.Start, nfa.Final);
                once.Enqueue(start);

                while (once.Count > 0)
                {
                    var closure = once.Dequeue();
                    var transitions = closure.UnambiguateTransitions();

                    foreach (var transition in transitions)
                    {
                        var terminal = transition.Key;
                        var targets = transition.Value;
                        var targetClosure = new Closure(targets, nfa.Final);
                        once.Enqueue(targetClosure, out targetClosure);
                        var target = targetClosure.DfaState;

                        closure.DfaState.Add(Atom.From(terminal), target);
                    }
                }

                return From(start.DfaState);
            }

            public static FA Complete(FA fa, bool cloned = false)
            {
                if (cloned)
                {
                    fa = fa.Clone();
                }

                State sink = null;

                foreach (var state in fa.States)
                {
                    var rest = UnicodeSets.Any();

                    foreach (var transition in state.Transitions)
                    {
                        rest.Sub(transition.Terminal.Set.GetRanges());
                    }

                    if (!rest.IsEmpty)
                    {
                        if (sink == null)
                        {
                            sink = new State();
                            sink.Add(Atom.From(UnicodeSets.Any()), sink);
                        }

                        state.Add(Atom.From(rest), sink);
                    }
                }

                if (sink != null)
                {
                    sink.Id = fa.States.Count;
                    fa.States.Add(sink);
                }

                return fa;
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
                foreach (var state in dfa.States)
                {
                    var i = 0;
                    while (i < state.Transitions.Count)
                    {
                        var trans1 = state.Transitions[i];
                        var j = i + 1;
                        while (j < state.Transitions.Count)
                        {
                            var trans2 = state.Transitions[j];
                            if (trans1.Terminal.Set.Overlaps(trans2.Terminal.Set))
                            {
                                throw new Exception("DFA: some transitions overlap");
                            }
                            j += 1;
                        }
                        i += 1;
                    }
                }
            }
        }
    }
}
