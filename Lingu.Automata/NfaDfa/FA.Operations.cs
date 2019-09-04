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

                EnsureComplete(dfa);

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

            public static FA Cross(FA dfa1, FA dfa2)
            {
                return CrossBuilder.Build(dfa1, dfa2);
            }

            public static FA RemoveDead(FA dfa)
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

            private static void EnsureComplete(FA dfa)
            {
                EnsureDfa(dfa);
                foreach (var state in dfa.States)
                {
                    var all = new IntegerSet();
                    var sum = 0;
                    foreach (var transition in state.Transitions)
                    {
                        sum += transition.Terminal.Set.Cardinality;
                        all.Add(transition.Terminal.Set);
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

            private static class CrossBuilder
            {
                public static FA Build(FA dfa1, FA dfa2)
                {
                    EnsureDfa(dfa1);
                    EnsureDfa(dfa2);

                    dfa1 = Complete(dfa1);
                    dfa2 = Complete(dfa2);

                    EnsureComplete(dfa1);
                    EnsureComplete(dfa2);

                    var cross = new CrossState[dfa1.States.Count, dfa2.States.Count];

                    var t1 = dfa1.States.Select(s => GetTransitions(s)).ToList();
                    var t2 = dfa2.States.Select(s => GetTransitions(s)).ToList();

                    for (var n1 = 0; n1 < dfa1.States.Count; n1 += 1)
                    {
                        for (var n2 = 0; n2 < dfa2.States.Count; n2 += 1)
                        {
                            cross[n1, n2] = new CrossState
                            {
                                S1 = dfa1.States[n1].Id, S2 = dfa2.States[n2].Id
                            };

                            var m = GetMerge(t1[n1], t2[n2]);
                        }
                    }

                    return null;
                }

                private static List<CrossTrans> GetMerge(List<Trans> l1, List<Trans> l2)
                {
                    Debug.Assert(l1.Count > 0 && l2.Count > 0);

                    var i1 = 0;
                    var i2 = 0;

                    var t1 = l1[i1++];
                    var t2 = l2[i2++];

                    var cross = new List<CrossTrans>();

                    do
                    {
                        var intersection = t1.Set.IntersectWith(t2.Set);
                        if (!intersection.IsEmpty)
                        {
                            var ct = new CrossTrans { Set = intersection, S1 = t1.StateId, S2 = t2.StateId };
                            cross.Add(ct);
                        }
                        while (!t1.Set.IsEmpty && !t2.Set.IsEmpty)
                        {

                        }
                        if (t1.Set.IsProperSupersetOf(t2.Set))
                        {
                        }
                    }
                    while (i1 < l1.Count && i2 < l2.Count);

                    throw new NotImplementedException();
                }

                private static List<Trans> GetTransitions(State state)
                {
                    var result = new List<Trans>();
                    foreach (var transition in state.Transitions)
                    {
                        foreach (var range in transition.Terminal.Set.GetRanges())
                        {
                            result.Add(new Trans { Set = new IntegerSet(range), StateId = transition.Target.Id });
                        }
                    }

                    result = result.OrderBy(t => t.Set.Min).ToList();

                    Debug.Assert(result[0].Set.Min == 0);
                    Debug.Assert(result[result.Count - 1].Set.Max == UnicodeSets.MaxCodePoint);
                    for (int i = 1; i < result.Count; ++i)
                    {
                        Debug.Assert(result[i - 1].Set.Max + 1 == result[i].Set.Min);
                    }

                    return result;
                }

                private class Trans
                {
                    public IntegerSet Set;
                    public int StateId;
                }

                private class CrossTrans
                {
                    public IntegerSet Set;
                    public int S1;
                    public int S2;
                }

                private class CrossState
                {
                    public int S1;
                    public int S2;
                }

            }
        }
    }
}
