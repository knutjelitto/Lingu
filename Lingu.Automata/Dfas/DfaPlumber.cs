using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lingu.Automata
{
    public class DfaPlumber
    {
        public DfaPlumber(Dfa dfa)
        {
            SetDfa(dfa);
        }

        protected void SetDfa(Dfa dfa)
        {
            Dfa = dfa;
            States = VisitStates();
        }

        protected Dfa Dfa { get; private set; }

        protected Dictionary<DfaState, int> States { get; private set; }

        public IEnumerable<DfaState> GetOrderedStates()
        {
            return States.OrderBy(kv => kv.Value).Select(kv => kv.Key);
        }

        public void Dump(string prefix, TextWriter writer)
        {
            foreach (var pair in States.OrderBy(s => s.Value))
            {
                var finA = pair.Key.IsFinal ? "(" : ".";
                var finB = pair.Key.IsFinal ? ")" : ".";
                writer.WriteLine($"{prefix}{finA}{pair.Value}{finB}:");
                foreach (var transition in pair.Key.Transitions)
                {
                    writer.WriteLine($"{prefix}  {States[transition.Target]} <= {transition.Terminal}");
                }
            }
        }

        private Dictionary<DfaState, int> VisitStates()
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

            Visit(Dfa.Start);

            return visited;
        }
    }
}