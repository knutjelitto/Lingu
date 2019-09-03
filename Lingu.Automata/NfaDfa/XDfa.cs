using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Lingu.Commons;

namespace Lingu.Automata
{
    public class XDfa
    {
        private XDfa(State start, IEnumerable<State> states)
        {
            Start = start;
            States = states.Select((state, i) => { state.Id = i; return state; }).ToList();
        }

        public State Start { get; }
        public List<State> States { get; }
        public int StateCount => States.Count;

        public static XDfa From(State start)
        {
            return new XDfa(start, Enumerate(start));
        }

#if false
        public XDfa Minimize()
        {
            return DfaMinimizer.Minimize(this);
        }

        public XDfa Complete()
        {
            return DfaCompleter.Complete(this);
        }
#endif

        public void Dump(string prefix, TextWriter writer)
        {
            foreach (var state in States)
            {
                var finA = state.IsFinal ? "(" : ".";
                var finB = state.IsFinal ? ")" : ".";
                writer.WriteLine($"{prefix}{finA}{state}{finB}:");
                foreach (var transition in state.Transitions)
                {
                    writer.WriteLine($"{prefix}  {States[transition.Target.Id]} <= {transition.Terminal}");
                }
            }
        }

        public XDfa Clone()
        {
            var map = new Dictionary<State, State>();

            State Map(State state)
            {
                if (!map.TryGetValue(state, out var mapped))
                {
                    mapped = new State(state.IsFinal);
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

        private static IEnumerable<State> Enumerate(State start)
        {
            var visited = new Dictionary<State, int>();

            void Visit(State state)
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