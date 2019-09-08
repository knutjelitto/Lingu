using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using Lingu.Commons;

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

                        closure.DfaState.Add(Codepoints.From(terminal), target);
                    }
                }

                var dfa = From(start.DfaState);

                EnsureDfa(dfa);

                return dfa;
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

            public static FA Minimize(FA dfa)
            {
                return new Minimizer().Minimize(dfa);
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
                        rest = rest.ExceptWith(transition.Set);
                    }

                    if (!rest.IsEmpty)
                    {
                        if (sink == null)
                        {
                            sink = new State();
                            sink.Add(Codepoints.Any, sink);
                        }

                        state.Add(Codepoints.From(rest), sink);
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

            public static FA Union(FA dfa1, FA dfa2)
            {
                return CrossBuilder.Build(dfa1, dfa2, (s1, s2) => s1.IsFinal || s2.IsFinal);
            }

            public static FA Intersect(FA dfa1, FA dfa2)
            {
                return CrossBuilder.Build(dfa1, dfa2, (s1, s2) => s1.IsFinal && s2.IsFinal);
            }

            public static FA Substract(FA dfa1, FA dfa2)
            {
                return CrossBuilder.Build(dfa1, dfa2, (s1, s2) => s1.IsFinal && !s2.IsFinal);
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
                                mapped.Add(transition.Set, Map(transition.Target));
                            }
                        }
                    }

                    return mapped;
                }

                return From(Map(dfa.Start));
            }

            [Conditional("DEBUG")]
            private static void EnsureComplete(FA dfa)
            {
                EnsureDfa(dfa);

                foreach (var state in dfa.States)
                {
                    var all = new Codepoints();
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

            private static class CrossBuilder
            {
                public static FA Build(FA dfa1, FA dfa2, Func<State,State,bool> isFinal)
                {
                    EnsureDfa(dfa1);
                    EnsureDfa(dfa2);

                    dfa1 = Complete(dfa1);
                    dfa2 = Complete(dfa2);

                    EnsureComplete(dfa1);
                    EnsureComplete(dfa2);

                    var cross = new State[dfa1.States.Count, dfa2.States.Count];

                    var t1 = dfa1.States.Select(s => GetTransitions(s)).ToList();
                    var t2 = dfa2.States.Select(s => GetTransitions(s)).ToList();

                    for (var n1 = 0; n1 < dfa1.States.Count; n1 += 1)
                    {
                        for (var n2 = 0; n2 < dfa2.States.Count; n2 += 1)
                        {
                            cross[n1, n2] = new State(isFinal(dfa1.States[n1], dfa2.States[n2]));
                        }
                    }

                    for (var n1 = 0; n1 < dfa1.States.Count; n1 += 1)
                    {
                        for (var n2 = 0; n2 < dfa2.States.Count; n2 += 1)
                        {
                            var state = cross[n1, n2];
                            var ctranses = GetMerge(t1[n1], t2[n2]);
                            foreach (var ctrans in ctranses)
                            {
                                state.Add(Codepoints.From(ctrans.Range.Min, ctrans.Range.Max), cross[ctrans.Target1, ctrans.Target2]);
                            }
                        }
                    }

                    var dfa = From(cross[0,0]);

                    EnsureComplete(dfa);

                    return dfa.RemoveDead().Minimize();
                }

                private static List<CrossTrans> GetMerge(List<Trans> l1, List<Trans> l2)
                {
                    Debug.Assert(l1.Count > 0 && l2.Count > 0);

                    var i1 = 0;
                    var i2 = 0;

                    var t1 = l1[i1++];
                    var r1 = t1.Range;
                    var t2 = l2[i2++];
                    var r2 = t2.Range;

                    var result = new List<CrossTrans>();

                    void Add(Range range)
                    {
                        result.Add(new CrossTrans { Range = range, Target1 = t1.Target, Target2 = t2.Target });
                    }

                    for (;;)
                    {
                        Debug.Assert(r1.Min == r2.Min);

                        if (r1.Max == r2.Max)
                        {
                            Add(r1);

                            if (i1 == l1.Count && i2 == l2.Count)
                            {
                                break;
                            }
                            Debug.Assert(i1 < l1.Count && i2 < l2.Count );
                            t1 = l1[i1++];
                            r1 = t1.Range;
                            t2 = l2[i2++];
                            r2 = t2.Range;
                        }
                        else if (r1.Max < r2.Max)
                        {
                            Add(r1);

                            Debug.Assert(i1 < l1.Count);
                            r2 = new Range(r1.Max + 1, r2.Max);
                            t1 = l1[i1++];
                            r1 = t1.Range;
                        }
                        else if (r2.Max < r1.Max)
                        {
                            Add(r2);

                            Debug.Assert(i2 < l2.Count);
                            r1 = new Range(r2.Max + 1, r1.Max);
                            t2 = l2[i2++];
                            r2 = t2.Range;
                        }
                    }

                    Debug.Assert(result[0].Range.Min == 0);
                    Debug.Assert(result[result.Count - 1].Range.Max == UnicodeSets.MaxCodePoint);
                    for (int i = 1; i < result.Count; ++i)
                    {
                        Debug.Assert(result[i - 1].Range.Max + 1 == result[i].Range.Min);
                    }

                    return result;
                }

                private static List<Trans> GetTransitions(State state)
                {
                    var result = new List<Trans>();
                    foreach (var transition in state.Transitions)
                    {
                        foreach (var range in transition.Set.GetIntervals())
                        {
                            result.Add(new Trans { Range = new Range(range.Min, range.Max), Target = transition.Target.Id });
                        }
                    }

                    result = result.OrderBy(t => t.Range.Min).ToList();

                    Debug.Assert(result[0].Range.Min == 0);
                    Debug.Assert(result[result.Count - 1].Range.Max == UnicodeSets.MaxCodePoint);
                    for (int i = 1; i < result.Count; ++i)
                    {
                        Debug.Assert(result[i - 1].Range.Max + 1 == result[i].Range.Min);
                    }

                    return result;
                }

                private struct Range
                {
                    public Range(int min, int max)
                    {
                        Min = min;
                        Max = max;
                    }
                    public readonly int Min;
                    public readonly int Max;
                }

                private class Trans
                {
                    public Range Range;
                    public int Target;
                }

                private class CrossTrans
                {
                    public Range Range;
                    public int Target1;
                    public int Target2;
                }
            }

            private class Minimizer
            {
                public FA Minimize(FA dfa)
                {
                    EnsureDfa(dfa);

                    dfa = MergeStates(dfa);
                    dfa = MergeTransitions(dfa);

                    var result = From(dfa.Start);

                    EnsureDfa(result);

                    return result;
                }

                private FA MergeTransitions(FA dfa)
                {
                    foreach (var state in dfa.States)
                    {
                        //EnsureDfaTransition(state);

                        var i = 0;

                        while (i < state.Transitions.Count)
                        {
                            var j = i + 1;
                            while (j < state.Transitions.Count)
                            {
                                if (state.Transitions[i].Target.Equals(state.Transitions[j].Target))
                                {
                                    state.Transitions[i].Set.Add(state.Transitions[j].Set);
                                    state.Transitions.RemoveAt(j);
                                    continue;
                                }
                                j += 1;
                            }
                            i += 1;
                        }
                    }

                    return dfa;
                }

                private FA MergeStates(FA dfa)
                {
                    //
                    // https://en.wikipedia.org/wiki/DFA_minimization
                    // Hopcroft's algorithm
                    //

                    var finals = new StateSet(dfa.Finals.ToList());
                    var nons = new StateSet(dfa.Inners.ToList());
                    var all = dfa.States.ToList();

                    var partitions = new List<StateSet> { finals, nons };
                    var working = new List<StateSet> { finals };

                    var terminals = new HashSet<Codepoints>(all.SelectMany(state => state.Transitions).Select(transition => transition.Set));

                    while (working.Count > 0)
                    {
                        var a = working[0];
                        working.RemoveAt(0);

                        foreach (var terminal in terminals)
                        {
                            var x = new StateSet();
                            foreach (var state in all)
                            {
                                foreach (var transition in state.Transitions)
                                {
                                    if (transition.Set.Overlaps(terminal))
                                    {
                                        if (a.Contains(transition.Target))
                                        {
                                            x.Add(state);
                                            break;
                                        }
                                    }
                                }
                            }

                            var i = 0;

                            while (i < partitions.Count)
                            {
                                var y = partitions[i];
                                var x_intersect_y = x.IntersectWith(y);

                                var y_without_x = y.ExceptWith(x);

                                if (x_intersect_y.IsEmpty || y_without_x.IsEmpty)
                                {
                                    i += 1;
                                    continue;
                                }
                                partitions[i] = x_intersect_y;
                                i += 1;
                                partitions.Insert(i, y_without_x);
                                i += 1;

                                var j = 0;
                                while (j < working.Count)
                                {
                                    if (working[j] == y)
                                    {
                                        working.RemoveAt(j);
                                        working.Add(x_intersect_y);
                                        working.Add(y_without_x);
                                        break;
                                    }

                                    j += 1;
                                }

                                if (j == working.Count)
                                {
                                    // ReSharper disable once ConvertIfStatementToConditionalTernaryExpression
                                    if (x_intersect_y.Count <= y_without_x.Count)
                                    {
                                        working.Add(x_intersect_y);
                                    }
                                    else
                                    {
                                        working.Add(y_without_x);
                                    }
                                }
                            }
                        }
                    }

                    foreach (var partition in partitions)
                    {
                        if (partition.Count >= 1)
                        {
                            var dfaStates = partition.ToList();
                            var premium = dfaStates.First();
                            var remove = dfaStates.Skip(1).ToList();

                            foreach (var state in all)
                            {
                                foreach (var transition in state.Transitions)
                                {
                                    if (remove.Contains(transition.Target))
                                    {
                                        transition.Retarget(premium);
                                    }
                                }
                            }

                            EnsureDistinctTransitions(premium);
                        }
                    }

                    var result = FA.From(dfa.Start);

                    EnsureDfa(result);

                    return result;
                }
            }
        }
    }
}
