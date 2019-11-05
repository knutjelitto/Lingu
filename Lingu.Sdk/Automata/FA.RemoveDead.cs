using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

#nullable enable

namespace Lingu.Automata
{
    public partial class FA
    {
        private static partial class Operations
        {
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

                    if (set.All(s => !s.Final))
                    {
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
                        mapped = new State(state.Final);
                        mapped.AddPayload(state);
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
        }
    }
}
