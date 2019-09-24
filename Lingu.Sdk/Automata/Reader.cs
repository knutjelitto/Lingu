using System;
using System.Collections.Generic;
using System.Text;

using Lingu.Commons;
using Lingu.Runtime.Lexing;

#nullable enable

namespace Lingu.Automata
{
    public class Reader
    {
        public static Dfa ReadDfa(byte[] bytes)
        {
            var reader = new DfaReader(bytes, 0);

            var dfa = reader.Read();

            return dfa;
        }

        public static FA ReadDfaAsFA(byte[] bytes)
        {
            var reader = new BinReader(bytes);

            var stateCount = reader.ReadInt32();

            var states = new State[stateCount];
            for (var i = 0; i < stateCount; ++i)
            {
                states[i] = new State();
            }

            var setCount = reader.ReadInt32();
            var sets = new Integers[setCount];
            for (var s = 0; s < setCount; ++s)
            {
                var intervalCount = reader.ReadInt32();
                var intervals = new (int min, int max)[intervalCount];
                for (var i = 0; i < intervalCount; ++i)
                {
                    intervals[i] = (reader.ReadInt32(), reader.ReadInt32());
                }
                sets[s] = new Integers(intervals);
            }

            var transitionCount = reader.ReadInt32();
            var transitions = new Transition[transitionCount];
            for (var t = 0; t < transitionCount; ++t)
            {
                var target = states[reader.ReadInt32()];
                var set = sets[reader.ReadInt32()];
                transitions[t] = new Transition(set, target);
            }

            for (var s = 0; s < stateCount; ++s)
            {
                states[s].IsFinal = reader.ReadBool();
                var count = reader.ReadInt32();
                for (var t = 0; t < count; ++t)
                {
                    states[s].Add(transitions[reader.ReadInt32()]);
                }
            }

            return FA.From(states[0]);
        }
    }
}
