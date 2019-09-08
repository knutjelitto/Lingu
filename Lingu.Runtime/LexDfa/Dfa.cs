using System;
using System.Collections.Generic;
using System.Text;

namespace Lingu.Runtime.LexDfa
{
    public class Dfa
    {
        public readonly DfaState[] States;

        public Dfa(DfaState[] states)
        {
            States = states;
        }

        public DfaState Start => States[0];
    }
}
