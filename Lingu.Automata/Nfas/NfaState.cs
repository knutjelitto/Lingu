using System.Collections.Generic;
using System.Linq;
using Lingu.Commons;

namespace Lingu.Automata
{
    public class NfaState
    {
        public NfaState()
        {
            IsFinal = false;
            Id = -1;
            Transitions = new List<NfaTransition>();
        }

        public bool IsFinal { get; }
        public int Id { get; set; }
        public List<NfaTransition> Transitions { get; }

        public IEnumerable<NfaTransition> EpsilonTransitions => Transitions.Where(t => t.Terminal.Set.IsEmpty);
        public IEnumerable<NfaTransition> TerminalTransitions => Transitions.Where(t => !t.Terminal.Set.IsEmpty);

        public void Add(NfaState target)
        {
            Transitions.Add(new NfaTransition(Atom.From(IntegerSet.Empty), target));
        }

        public void Add(Atom terminal, NfaState target)
        {
            Transitions.Add(new NfaTransition(terminal, target));
        }

        public IEnumerable<NfaState> Closure()
        {
            var once = new UniqueQueue<NfaState>();

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
    }
}