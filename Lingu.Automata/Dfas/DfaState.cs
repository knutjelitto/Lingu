using System.Collections.Generic;
using System.Linq;

namespace Lingu.Automata
{
    public class DfaState
    {
        public DfaState(bool isFinal)
        {
            IsFinal = isFinal;
            Id = -1;
            Transitions = new List<DfaTransition>();
        }

        public bool IsFinal { get; }
        public int Id { get; set; }
        public List<DfaTransition> Transitions { get; }

        public IEnumerable<DfaTransition> EpsilonTransitions => Transitions.Where(t => t.Terminal.Set.IsEmpty);
        public IEnumerable<DfaTransition> TerminalTransitions => Transitions.Where(t => !t.Terminal.Set.IsEmpty);

        public static DfaState Make(bool isFinal)
        {
            return new DfaState(isFinal);
        }

        public void Add(Atom terminal, DfaState target)
        {
            Transitions.Add(new DfaTransition(terminal, target));
        }

        public override string ToString()
        {
            return $"({IsFinal},({string.Join(",", Transitions)}))";
        }
    }
}