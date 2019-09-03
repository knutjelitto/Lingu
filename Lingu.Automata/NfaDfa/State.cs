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
            Transitions = new List<Transition>();
        }

        public bool IsFinal { get; set; }
        public int Id { get; set; }
        public List<Transition> Transitions { get; }

        public IEnumerable<Transition> EpsilonTransitions => Transitions.Where(t => t.Terminal.Set.IsEmpty);
        public IEnumerable<Transition> TerminalTransitions => Transitions.Where(t => !t.Terminal.Set.IsEmpty);

        public void Add(State target)
        {
            Transitions.Add(new Transition(Atom.From(IntegerSet.Empty), target));
        }

        public void Add(Atom terminal, State target)
        {
            Transitions.Add(new Transition(terminal, target));
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
            return $"({Id},{IsFinal},({string.Join(",", Transitions)}))";
        }

    }
}
