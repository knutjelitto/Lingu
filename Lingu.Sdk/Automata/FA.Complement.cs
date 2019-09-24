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
            public static FA Complement(FA dfa)
            {
                EnsureDfa(dfa);

                for (var i = 0; i < dfa.States.Count; ++i)
                {
                    dfa.States[i].IsFinal = !dfa.States[i].IsFinal;
                }

                return dfa;
            }
        }
    }
}
