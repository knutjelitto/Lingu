using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Lingu.Automata
{
    public partial class FA
    {
        private static partial class Operations
        {
            public static FA Union(FA dfa1, FA dfa2)
            {
                return CrossBuilder.Build(dfa1, dfa2, (s1, s2) => s1.IsFinal || s2.IsFinal);
            }

            public static FA Intersect(FA dfa1, FA dfa2)
            {
                return CrossBuilder.Build(dfa1, dfa2, (s1, s2) => s1.IsFinal && s2.IsFinal);
            }

            public static FA Difference(FA dfa1, FA dfa2)
            {
                return CrossBuilder.Build(dfa1, dfa2, (s1, s2) => s1.IsFinal && !s2.IsFinal);
            }

            private static class CrossBuilder
            {
                public static FA Build(FA dfa1, FA dfa2, Func<State, State, bool> isFinal)
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
                        var state1 = dfa1.States[n1];

                        for (var n2 = 0; n2 < dfa2.States.Count; n2 += 1)
                        {
                            var state2 = dfa2.States[n2];

                            var newState = new State(isFinal(state1, state2));
                            //if (newState.IsFinal)
                            //{
                                if (state1.IsPayload && !state2.IsPayload)
                                {
                                    newState.AddPayload(state1);
                                }
                                else if (!state1.IsPayload && state2.IsPayload)
                                {
                                    newState.AddPayload(state2);
                                }
                            //}

                            cross[n1, n2] = newState;
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
                                state.Add(Integers.From(ctrans.Range.Min, ctrans.Range.Max), cross[ctrans.Target1, ctrans.Target2]);
                            }
                        }
                    }

                    var dfa = From(cross[0, 0]);

                    EnsureComplete(dfa);

                    dfa = dfa.RemoveDead();

                    dfa = dfa.Minimize();

                    return dfa;
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

                    for (; ; )
                    {
                        Debug.Assert(r1.Min == r2.Min);

                        if (r1.Max == r2.Max)
                        {
                            Add(r1);

                            if (i1 == l1.Count && i2 == l2.Count)
                            {
                                break;
                            }
                            Debug.Assert(i1 < l1.Count && i2 < l2.Count);
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
                        foreach (var (min, max) in transition.Set.GetIntervals())
                        {
                            result.Add(new Trans { Range = new Range(min, max), Target = transition.Target.Id });
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
        }
    }
}
