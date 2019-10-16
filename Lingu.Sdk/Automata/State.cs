using Lingu.Commons;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

#nullable enable

namespace Lingu.Automata
{
    [DebuggerDisplay("{ToString()}")]
    public class State
    {
        public State(bool isFinal = false)
        {
            Final = isFinal;
            Id = -1;
            Payload = -1;
            Transitions = new List<Transition>();
        }

        public bool Final { get; set; }
        public int Id { get; set; }
        public int Payload { get; private set; }
        public bool IsPayload => Payload >= 0;
        public List<Transition> Transitions { get; }

        public IEnumerable<Transition> EpsilonTransitions => Transitions.Where(t => t.Set.IsEmpty);
        public IEnumerable<Transition> TerminalTransitions => Transitions.Where(t => !t.Set.IsEmpty);

        public void AddPayload(State state)
        {
            if (IsPayload && state.IsPayload)
            {
                throw new ArgumentOutOfRangeException(nameof(state));
            }
            else if (!IsPayload)
            {
                Payload = state.Payload;
            }
        }

        public void SetPayload(int payload)
        {
            if (IsPayload && payload >= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(payload));
            }
            else if (!IsPayload)
            {
                Payload = payload;
            }
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
            return $"({Id},{Final},{Payload.ToString()},({string.Join(",", Transitions)}))";
        }
    }
}
