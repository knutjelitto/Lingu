using Lingu.Commons;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lingu.Automata
{
    public class State
    {
        public State(bool isFinal = false)
        {
            IsFinal = isFinal;
            Id = -1;
            Payload = -1;
            Transitions = new List<Transition>();
        }

        public bool IsFinal { get; set; }
        public int Id { get; set; }
        public int Payload { get; set; }
        public bool IsPayload => Payload >= 0;
        public List<Transition> Transitions { get; }

        public IEnumerable<Transition> EpsilonTransitions => Transitions.Where(t => t.Set.IsEmpty);
        public IEnumerable<Transition> TerminalTransitions => Transitions.Where(t => !t.Set.IsEmpty);

        public void Add(State target)
        {
            Transitions.Add(new Transition(Codepoints.Empty, target));
        }

        public void Add(Codepoints terminal, State target)
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
