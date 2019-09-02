using System;
using System.Collections.Generic;
using System.Text;

namespace Lingu.Automata
{
    public class DfaCompleter
    {
        public static Dfa Complete(Dfa dfa, bool cloned = false)
        {
            if (cloned)
            {
                dfa = dfa.Clone();
            }

            DfaState sink = null;

            foreach (var state in dfa.States)
            {
                var rest = UnicodeSets.Any;

                foreach (var transition in state.Transitions)
                {
                    rest.Sub(transition.Terminal.Set.GetRanges());
                }

                if (!rest.IsEmpty)
                {
                    if (sink == null)
                    {
                        sink = new DfaState(false);
                        sink.Add(Atom.From(UnicodeSets.Any), sink);
                    }

                    state.Add(Atom.From(rest), sink);
                }
            }

            if (sink != null)
            {
                dfa.States.Add(sink);
            }

            return dfa;
        }
    }
}
