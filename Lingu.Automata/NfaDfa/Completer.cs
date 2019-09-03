using System;
using System.Collections.Generic;
using System.Text;

namespace Lingu.Automata
{
    public class Completer
    {
        public static FA Complete(FA fa, bool cloned = false)
        {
            if (cloned)
            {
                fa = fa.Clone();
            }

            State sink = null;

            foreach (var state in fa.States)
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
                        sink = new State();
                        sink.Add(Atom.From(UnicodeSets.Any), sink);
                    }

                    state.Add(Atom.From(rest), sink);
                }
            }

            if (sink != null)
            {
                sink.Id = fa.States.Count;
                fa.States.Add(sink);
            }

            return fa;
        }
    }
}
