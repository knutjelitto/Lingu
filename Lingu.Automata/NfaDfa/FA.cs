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
            var states = Enumerate(start);

            if (!states.Any(state => state.IsFinal))
            {
                Debug.Assert(false, "no final in stateset");
            }

            return new FA(start, null, states);
        }

        public FA Minimize()
        {
            return Minimizer.Minimize(this);
        }

        public FA Complete()
        {
            return Operations.Complete(this,true);
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
                    writer.WriteLine($"{prefix}    {transition.Target.Id} <= {transition.Terminal}");
                }
                foreach (var transition in state.EpsilonTransitions)
                {
                    writer.WriteLine($"{prefix}    {transition.Target.Id} <= -epsilon-");
                }
            }
        }

        public FA ToDfa()
        {
            return Operations.ToDfa(this);
        }

        public FA ToNfa(bool cloned = false)
        {
            var nfa = this;
            if (cloned)
            {
                nfa = nfa.Clone();
            }

            if (nfa.Final != null)
            {
                return nfa;
            }

            nfa.Final = new State();

            foreach (var final in nfa.Finals)
            {
                final.Add(nfa.Final);
            }

            nfa.Final.Id = nfa.States.Count;
            nfa.States.Add(nfa.Final);
            foreach (var state in nfa.States)
            {
                state.IsFinal = false;
            }

            return nfa;
        }

        public FA Negate(bool cloned = false)
        {
            var nfa = cloned ? this : this.Clone();

            for (var i = 0; i < nfa.States.Count; ++i)
            {
                nfa.States[i].IsFinal = !nfa.States[i].IsFinal;
            }

            return nfa;
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
                        mapped.Add(transition.Terminal, Map(transition.Target));
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
            var visited = new Dictionary<State, int>();

            void Visit(State state)
            {
                if (!visited.TryGetValue(state, out var _))
                {
                    state.Id = visited.Count;
                    visited.Add(state, visited.Count);

                    foreach (var transition in state.Transitions)
                    {
                        Visit(transition.Target);
                    }
                }
            }

            Visit(start);

            return visited.Keys.OrderBy(state => state.Id);
        }
    }
}
