using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using Lingu.Commons;

namespace Lingu.Automata
{
    public partial class FA
    {
        private static partial class Operations
        {
            public static FA ToNfa(FA dfa)
            {
                if (dfa.Final != null)
                {
                    return dfa;
                }

                dfa.Final = new State();

                foreach (var final in dfa.Finals)
                {
                    final.Add(dfa.Final);
                    final.AddPayload(dfa.Final);
                }

                dfa.Final.Id = dfa.States.Count;
                dfa.States.Add(dfa.Final);
                foreach (var state in dfa.States)
                {
                    state.Final = false;
                }

                return dfa;
            }
        }
    }
}
