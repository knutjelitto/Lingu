using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using Lingu.Commons;

#nullable enable

namespace Lingu.Automata
{
    public partial class FA
    {
        private static partial class Operations
        {
            public static FA Complete(FA dfa)
            {
                EnsureDfa(dfa);

                State? sink = null;

                foreach (var state in dfa.States)
                {
                    var rest = UnicodeSets.Any();

                    foreach (var transition in state.Transitions)
                    {
                        rest = rest.ExceptWith(transition.Set);
                    }

                    if (!rest.IsEmpty)
                    {
                        if (sink == null)
                        {
                            sink = new State();
                            sink.Add(Integers.Any, sink);
                        }

                        state.Add(Integers.From(rest), sink);
                    }
                }

                if (sink != null)
                {
                    sink.Id = dfa.States.Count;
                    dfa.States.Add(sink);
                }

                EnsureComplete(dfa);

                return dfa;
            }
        }
    }
}
