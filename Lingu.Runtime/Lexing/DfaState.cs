using System;
using System.Collections.Generic;
using System.Text;

namespace Lingu.Runtime.Lexing
{
    public class DfaState
    {
        public readonly int Id;
        public readonly bool Final;
        public readonly int Payload;

        public readonly DfaTrans[] Transitions;

        public DfaState(int id, bool final, int payload, DfaTrans[] transitions)
        {
            Id = id;
            Final = final;
            Payload = payload;
            Transitions = transitions;
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
    }
}
