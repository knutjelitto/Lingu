using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

#nullable enable

namespace Lingu.Runtime.Lexing
{
    public class Dfa
    {
        public static readonly Dfa Nope = new Dfa();
        public readonly DfaState[] States;

        public Dfa(params DfaState[] states)
        {
            Debug.Assert(states.Length > 0);

            States = states;
        }

        public IEnumerable<int> GetPayloads()
        {
            return States.Where(state => state.Payload >= 0).Select(state => state.Payload).Distinct();
        }

        public DfaState Start => States[0];
    }
}
