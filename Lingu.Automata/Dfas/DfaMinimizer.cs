using System.Collections.Generic;
using System.Linq;

namespace Lingu.Automata
{
    public class DfaMinimizer
    {
        private DfaMinimizer(Dfa dfa)
        {
            Dfa = dfa;
            FinalStates = Dfa.States.Where(state => state.IsFinal);
            NonFinalStates = Dfa.States.Where(state => !state.IsFinal);
            AllStates = Dfa.States;
        }

        public static Dfa Minimize(Dfa dfa, bool cloned = false)
        {
            return new DfaMinimizer(cloned ? dfa.Clone() : dfa).DoMinimize();
        }


        private Dfa Dfa { get; }

        private IEnumerable<DfaState> FinalStates { get; }
        private IEnumerable<DfaState> NonFinalStates { get; }
        private IEnumerable<DfaState> AllStates { get; }

        private Dfa DoMinimize()
        {
            MergeStates();
            MergeTransitions();

            return Dfa.From(Dfa.Start);
        }

        private void MergeTransitions()
        {
            foreach (var state in AllStates)
            {
                var i = 0;

                while (i < state.Transitions.Count)
                {
                    var j = i + 1;
                    while (j < state.Transitions.Count)
                    {
                        if (state.Transitions[i].Target.Equals(state.Transitions[j].Target))
                        {
                            state.Transitions[i].Terminal.Set.Add(state.Transitions[j].Terminal.Set);
                            state.Transitions.RemoveAt(j);
                            continue;
                        }
                        j += 1;
                    }
                    i += 1;
                }
            }
        }

        private void MergeStates()
        {
            //
            // https://en.wikipedia.org/wiki/DFA_minimization
            // Hopcroft's algorithm
            //

            var finals = new DfaStateSet(FinalStates);
            var nons = new DfaStateSet(NonFinalStates);

            var partitions = new List<DfaStateSet> { finals, nons };
            var working = new List<DfaStateSet> { finals };

            var terminals = new HashSet<Atom>(AllStates.SelectMany(state => state.Transitions).Select(transition => transition.Terminal));

            while (working.Count > 0)
            {
                var a = working[0];
                working.RemoveAt(0);

                foreach (var terminal in terminals)
                {
                    var x = new DfaStateSet();
                    foreach (var state in AllStates)
                    {
                        foreach (var transition in state.Transitions)
                        {
                            if (transition.Terminal.Set.Overlaps(terminal.Set))
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
                if (partition.Count > 1)
                {
                    var dfaStates = partition.ToList();
                    var premium = dfaStates.First();
                    var remove = dfaStates.Skip(1).ToList();

                    foreach (var state in AllStates)
                    {
                        foreach (var transition in state.Transitions)
                        {
                            if (remove.Contains(transition.Target))
                            {
                                transition.Retarget(premium);
                            }
                        }
                    }
                }
            }
        }
    }
}
