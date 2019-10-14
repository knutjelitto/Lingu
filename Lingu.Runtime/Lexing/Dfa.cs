using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

#nullable enable

namespace Lingu.Runtime.Lexing
{
    public class Dfa
    {
        public static readonly Dfa Nope = new Dfa();

        public Dfa(params DfaState[] states)
        {
            Debug.Assert(states.Length > 0);
            States = states;
        }

        public DfaState[] States { get; }

        public IEnumerable<int> GetPayloads()
        {
            return States.Where(state => state.Payload >= 0).Select(state => state.Payload).Distinct();
        }

        public DfaState Start => States[0];
    }
}
