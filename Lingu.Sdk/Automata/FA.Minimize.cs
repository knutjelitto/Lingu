using System.Collections.Generic;
using System.Linq;

namespace Lingu.Automata
{
    public partial class FA
    {
        private static partial class Operations
        {
            public static FA Minimize(FA dfa)
            {
                return new Minimizer2().Minimize(dfa);
            }

            private class Minimizer2
            {
                public FA Minimize(FA dfa)
                {
                    EnsureDfa(dfa);
                    dfa = Complete(dfa);
                    EnsureComplete(dfa);

                    var s = dfa.States;
                    var n = s.Count;

                    var table = new bool[n, n];

                    for (var i = 0; i < n - 1; ++i)
                    {
                        for (var j = i + 1; j < n; ++j)
                        {
                            table[i, j] = s[i].IsFinal && !s[j].IsFinal /*|| !s[i].IsFinal && s[j].IsFinal*/;
                        }
                    }

                    for (var i = 0; i < n - 1; ++i)
                    {
                        for (var j = i + 1; j < n; ++j)
                        {
                            
                        }
                    }

                    return null;
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

#if true
                    var nons = new StateSet(dfa.Nons.ToList());
                    var all = dfa.States.ToList();

                    var partitions = new List<StateSet> { nons };
                    var working = new List<StateSet> { nons };

                    var fgroups = from state in dfa.Finals group state by state.Payload;

                    foreach (var fgroup in fgroups)
                    {
                        partitions.Add(new StateSet(fgroup));
                    }
#else
                    var finals = new StateSet(dfa.Finals.ToList());
                    var nons = new StateSet(dfa.Nons.ToList());
                    var all = dfa.States.ToList();

                    var partitions = new List<StateSet> { finals, nons };
                    var working = new List<StateSet> { finals };
#endif

                    var terminals = new HashSet<Integers>(all.SelectMany(state => state.Transitions).Select(transition => transition.Set));

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
#if true
                            var groups = from s in partition group s by s.Payload;

                            foreach (var group in groups)
                            {
                                List<State> dfaStates = group.ToList();

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
#else
                            List<State> dfaStates = partition.ToList();

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
#endif
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
