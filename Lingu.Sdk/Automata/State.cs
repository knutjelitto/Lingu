using Lingu.Commons;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Lingu.Automata
{
    public class State
    {
        public State(bool isFinal = false)
        {
            IsFinal = isFinal;
            Id = -1;
            Payload = new Integers();
            Transitions = new List<Transition>();
        }

        public bool IsFinal { get; set; }
        public int Id { get; set; }
        private Integers Payload { get; }
        public bool IsPayload => Payload.Cardinality > 0;
        public string PayloadString => Payload.ToIString();
        public List<Transition> Transitions { get; }

        public IEnumerable<Transition> EpsilonTransitions => Transitions.Where(t => t.Set.IsEmpty);
        public IEnumerable<Transition> TerminalTransitions => Transitions.Where(t => !t.Set.IsEmpty);

        public void AddPayload(State other)
        {
            Debug.Assert(!Payload.Contains(-1));
            Debug.Assert(!other.Payload.Contains(-1));

            Payload.Add(other.Payload);
        }

        public void AddPayload(int load)
        {
            Debug.Assert(!Payload.Contains(-1));
            Debug.Assert(load != -1);

            Payload.Add(load);
        }

        public void Add(State target)
        {
            Transitions.Add(new Transition(Integers.Empty, target));
        }

        public void Add(Integers terminal, State target)
        {
            Transitions.Add(new Transition(terminal, target));
        }

        public void Add(Transition transition)
        {
            Transitions.Add(transition);
        }

        public IEnumerable<State> Closure()
        {
            var once = new UniqueQueue<State>();

            once.Enqueue(this);

            while (once.Count > 0)
            {
                var state = once.Dequeue();
                foreach (var transition in state.EpsilonTransitions)
                {
                    once.Enqueue(transition.Target);
                }
            }

            return once.Seen;
        }

        public override string ToString()
        {
            return $"({Id},{IsFinal},{Payload},({string.Join(",", Transitions)}))";
        }
    }
}
