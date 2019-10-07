using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Lingu.Runtime.Lexing
{
    [DebuggerDisplay("{DD()}")]
    public class DfaState
    {
        public readonly int Id;
        public readonly bool Final;
        public readonly int Payload;

        public DfaTrans[] Transitions = Array.Empty<DfaTrans>();

        public DfaState(int id, bool final, int payload, DfaTrans[] transitions)
        {
            Id = id;
            Final = final;
            Payload = payload;
            Transitions = transitions;
        }

        public DfaState(int id, bool final, int payload)
        {
            Id = id;
            Final = final;
            Payload = payload;
        }

        public DfaState? Match(int ch)
        {
            foreach (var transition in Transitions)
            {
                if (transition.Set.Match(ch))
                {
                    return transition.Target;
                }
            }

            return null;
        }

        public string DD()
        {
            return ToString();
        }

        public override string ToString()
        {
            return $"({Id},{Final},{Payload.ToString()},({string.Join(",", Transitions)}))";
        }
    }
}
