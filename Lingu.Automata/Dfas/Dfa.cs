using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Lingu.Commons;

namespace Lingu.Automata
{
    public class Dfa
    {
        private Dfa(DfaState start, IEnumerable<DfaState> states)
        {
            Start = start;
            States = states.ToList();
        }

        public DfaState Start { get; }
        public List<DfaState> States { get; }
        public int StateCount => States.Count;

        public static Dfa From(DfaState start)
        {
            return new Dfa(start, Enumerate(start));
        }

        public Dfa Minimize()
        {
            return DfaMinimizer.Minimize(this);
        }

        public Dfa Complete()
        {
            return DfaCompleter.Complete(this);
        }

        public void Number()
        {
            for (var id = 0; id < States.Count; ++id)
            {
                States[id].Id = id;
            }
        }

        public Nfa ToDfa()
        {
            throw new NotImplementedException();
        }

        public void Dump(string prefix, TextWriter writer)
        {
            new DfaPlumber(this).Dump(prefix, writer);
        }

        public Dfa Clone()
        {
            var map = new Dictionary<DfaState, DfaState>();

            DfaState Map(DfaState state)
            {
                if (!map.TryGetValue(state, out var mapped))
                {
                    mapped = new DfaState(state.IsFinal);
                    map.Add(state, mapped);

                    foreach (var transition in state.Transitions)
                    {
                        mapped.Add(transition.Terminal, Map(transition.Target));
                    }
                }

                return mapped;
            }

            return From(Map(Start));
        }

        private static IEnumerable<DfaState> Enumerate(DfaState start)
        {
            var visited = new Dictionary<DfaState, int>();

            void Visit(DfaState state)
            {
                if (!visited.TryGetValue(state, out var _))
                {
                    visited.Add(state, visited.Count + 1);

                    foreach (var transition in state.Transitions)
                    {
                        Visit(transition.Target);
                    }
                }
            }

            Visit(start);

            return visited.OrderBy(kv => kv.Value).Select(kv => kv.Key);
        }

    }
}