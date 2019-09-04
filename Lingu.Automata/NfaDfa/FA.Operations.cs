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


            public static FA ToNfa(FA dfa)
            {
                if (dfa.Final != null)
                {
                    return dfa;
                }

                dfa.Final = new State();

                foreach (var final in dfa.Finals)
                {
                    final.Add(dfa.Final);
                }

                dfa.Final.Id = dfa.States.Count;
                dfa.States.Add(dfa.Final);
                foreach (var state in dfa.States)
                {
                    state.IsFinal = false;
                }

                return dfa;
            }


            public static FA Complete(FA dfa)
            {
                EnsureDfa(dfa);

                State sink = null;

                foreach (var state in dfa.States)
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
                    sink.Id = dfa.States.Count;
                    dfa.States.Add(sink);
                }

                return dfa;
            }

            public static FA Negate(FA dfa)
            {
                EnsureDfa(dfa);

                for (var i = 0; i < dfa.States.Count; ++i)
                {
                    dfa.States[i].IsFinal = !dfa.States[i].IsFinal;
                }

                return dfa;
            }


            public static FA Remove(FA dfa)
            {
                EnsureDfa(dfa);

                var closures = new Dictionary<State, HashSet<State>>();

                void Initial(State state)
                {
                    var set = new HashSet<State>() { state };

                    foreach (var transition in state.Transitions)
                    {
                        set.Add(transition.Target);
                    }

                    closures.Add(state, set);
                }

                bool Close(State state)
                {
                    var set = closures[state];

                    var before = set.Count;

                    foreach (var buddy in set.Where(s => s != state).ToList())
                    {
                        var buddySet = closures[buddy];

                        set.UnionWith(buddySet);
                    }

                    var after = set.Count;

                    return after > before;
                }

                foreach (var state in dfa.States)
                {
                    Initial(state);
                }

                var added = true;
                while (added)
                {
                    added = false;

                    foreach (var state in dfa.States)
                    {
                        added = added || Close(state);
                    }
                }

                var dead = new HashSet<State>();

                foreach (var state in dfa.States)
                {
                    var set = closures[state];

                    if (set.All(s => !s.IsFinal))
                    {
                        Debug.Assert(true);

                        dead.UnionWith(set);
                    }
                }

                return RemoveDead(dfa, dead);
            }

            private static FA RemoveDead(FA dfa, HashSet<State> dead)
            {
                if (dead.Count == 0)
                {
                    return dfa;
                }

                var map = new Dictionary<State, State>();

                State Map(State state)
                {
                    if (!map.TryGetValue(state, out var mapped))
                    {
                        mapped = new State(state.IsFinal);
                        map.Add(state, mapped);

                        foreach (var transition in state.Transitions)
                        {
                            if (!dead.Contains(transition.Target))
                            {
                                mapped.Add(transition.Terminal, Map(transition.Target));
                            }
                        }
                    }

                    return mapped;
                }

                return From(Map(dfa.Start));
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

                        if (trans1.Terminal.Set.IsEmpty)
                        {
                            throw new Exception("DFA: epsilon transition");
                        }
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
