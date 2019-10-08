using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Lingu.Automata
{
    public partial class FA
    {
        private static partial class Operations
        {
            public static FA Minimize(FA dfa)
            {
                return new Minimizer().Minimize(dfa);
            }

            private class Minimizer
            {
                public FA Minimize(FA dfa)
                {
                    EnsureDfa(dfa);
                    dfa = Complete(dfa);
                    EnsureComplete(dfa);

                    var s = dfa.States;
                    var n = s.Count;

                    var table = new bool[n, n];

                    for (var i = 0; i < n; ++i)
                    {
                        for (var j = 0; j < n; ++j)
                        {
                            if (i >= j) continue;

                            table[i, j] = s[i].Final && !s[j].Final || s[i].Final && s[j].Final && s[i].Payload != s[j].Payload;
                        }
                    }

                    bool more = true;
                    while (more)
                    {
                        more = false;
                        for (var i = 0; i < n; ++i)
                        {
                            for (var j = 0; j < n; ++j)
                            {
                                if (i >= j) continue;

                                if (!table[i, j])
                                {
                                    foreach (var ti in s[i].Transitions)
                                    {
                                        foreach (var tj in s[j].Transitions)
                                        {
                                            if (ti.Set.Overlaps(tj.Set))
                                            {
                                                var si = ti.Target.Id;
                                                var sj = tj.Target.Id;
                                                if (si == sj)
                                                {
                                                    continue;
                                                }
                                                if (si > sj)
                                                {
                                                    var tmp = si;
                                                    si = sj;
                                                    sj = tmp;

                                                    Debug.Assert(si < sj);
                                                }

                                                var before = more;
                                                if (table[si,sj])
                                                {
                                                    var isij = table[i, j];
                                                    more = more || !table[i, j];
                                                    if (!before && more)
                                                    {
                                                        Debug.Assert(true);
                                                    }
                                                    table[i, j] = true;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    var combines = new List<StateSet>();

                    for (var i = 0; i < n; ++i)
                    {
                        for (var j = 0; j < n; ++j)
                        {
                            if (i >= j) continue;

                            if (!table[i,j])
                            {
                                combines.Add(new StateSet { s[i], s[j] });
                            }
                        }
                    }

                    var current = 0;
                    while (current < combines.Count)
                    {
                        for (var i = current + 1; i < combines.Count;)
                        {
                            if (combines[current].Overlaps(combines[i]))
                            {
                                combines[current].Add(combines[i]);
                                combines.RemoveAt(i);
                            }
                            else
                            {
                                i += 1;
                            }
                        }
                        current += 1;
                    }


                    foreach (var set in combines)
                    {
                        var premium = set.First();

                        var remove = set.Skip(1).ToList();

                        foreach (var state in s)
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

                    var mini = From(dfa.Start);

                    mini = MergeTransitions(mini);

                    return mini;
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
            }

#if false
            private class Minimizer2
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
#endif
        }
    }
}
