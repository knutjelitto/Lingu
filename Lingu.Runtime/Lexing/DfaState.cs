﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Lingu.Runtime.Lexing
{
    public class DfaState
    {
        private readonly DfaStateFlag Flags;
        public readonly int Payload;
        public readonly int Id;
        public readonly DfaTrans[] Transitions;

        public DfaState(int id, DfaStateFlag flags, int payload, DfaTrans[] transitions)
        {
            Id = id;
            Flags = flags;
            Payload = payload;
            Transitions = transitions;
        }

        public bool IsFinal => (Flags & DfaStateFlag.Final) != 0;

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
