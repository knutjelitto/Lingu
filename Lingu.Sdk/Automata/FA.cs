using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Lingu.Automata
{
    public partial class FA
    {
        private FA(State start, State final, IEnumerable<State> states)
        {
            Start = start;
            Final = final;
            States = states.Select((state, i) => { state.Id = i; return state; }).ToList();

            if (final == null)
            {
                if (!States.Any(state => state.IsFinal))
                {
                    Debug.Assert(false, "no final state in DFA");
                }
            }
            else
            {
                if (States.Any(state => state.IsFinal))
                {
                    Debug.Assert(false, "final state in NFA");

                }
            }
        }

        public State Start { get; }
        public State Final { get; private set; }
        public List<State> States { get; }
        public IEnumerable<State> Finals => States.Where(state => state.IsFinal);
        public IEnumerable<State> Inners => States.Where(state => state.IsFinal);

        public static FA From(State start, State final)
        {
            if (start == null) throw new ArgumentNullException(nameof(start));
            if (final == null) throw new ArgumentNullException(nameof(final));

            return new FA(start, final, Enumerate(start));
        }

        public static FA From(State start)
        {
            return new FA(start, null, Enumerate(start));
        }

        public void Dump(string prefix, TextWriter writer)
        {
            foreach (var state in States)
            {
                var finA = state.IsFinal ? "(" : (state == Final ? "[" : ".");
                var finB = state.IsFinal ? ")" : (state == Final ? "]" : ".");
                writer.WriteLine($"{prefix}{finA}{state.Id}{finB}");
                foreach (var transition in state.TerminalTransitions)
                {
                    writer.WriteLine($"{prefix}    {transition.Target.Id} <= {transition.Set}");
                }
                foreach (var transition in state.EpsilonTransitions)
                {
                    writer.WriteLine($"{prefix}    {transition.Target.Id} <= -epsilon-");
                }
            }
        }

        public FA Complete(bool cloned = false)
        {
            return Operations.Complete(CloneIf(cloned));
        }

        public FA Substract(FA other, bool cloned = false)
        {
            return Operations.Substract(CloneIf(cloned), other.CloneIf(cloned));
        }


        public FA Minimize(bool cloned = false)
        {
            return Operations.Minimize(CloneIf(cloned));
        }

        public FA ToDfa(bool cloned = false)
        {
            return Operations.ToDfa(CloneIf(cloned));
        }

        public FA ToNfa(bool cloned = false)
        {
            return Operations.ToNfa(CloneIf(cloned));
        }

        public FA RemoveDead(bool cloned = false)
        {
            return Operations.RemoveDead(CloneIf(cloned));
        }

        public FA Not(bool cloned = false)
        {
            return Operations.Not(CloneIf(cloned));
        }

        private FA CloneIf(bool cloned)
        {
            return cloned ? Clone() : this;
        }

        public FA Clone()
        {
            var map = new Dictionary<State, State>();

            State Map(State state)
            {
                if (state == null)
                {
                    return null;
                }

                if (!map.TryGetValue(state, out var mapped))
                {
                    mapped = new State(state.IsFinal);
                    map.Add(state, mapped);

                    foreach (var transition in state.Transitions)
                    {
                        mapped.Add(transition.Set, Map(transition.Target));
                    }
                }

                return mapped;
            }

            if (Final != null)
            {
                return From(Map(Start), Map(Final));
            }
            return From(Map(Start));
        }

        private static IEnumerable<State> Enumerate(State start)
        {
            var visited = new HashSet<State>();

            void Visit(State state)
            {
                if (!visited.Contains(state))
                {
                    state.Id = visited.Count;
                    visited.Add(state);

                    foreach (var transition in state.Transitions)
                    {
                        Visit(transition.Target);
                    }
                }
            }

            Visit(start);

            return visited.OrderBy(state => state.Id);
        }
    }
}
