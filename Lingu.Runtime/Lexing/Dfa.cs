using System.Collections.Generic;
using System.Linq;

#nullable enable

namespace Lingu.Runtime.Lexing
{
    public class Dfa
    {
        public static Dfa Nope = new Dfa();
        public readonly DfaState[] States;

        public Dfa(params DfaState[] states)
        {
            States = states;
        }

        public IEnumerable<int> GetPayloads()
        {
            return States.Where(s => s.Payload >= 0).Select(s => s.Payload);
        }

        public DfaState Start => States[0];
    }
}
