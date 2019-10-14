using System.Diagnostics;
using Lingu.Runtime.Lexing;

namespace Lingu.Runtime.Commons
{
    public class DfaReader : ByteReader
    {
        public DfaReader(byte[] bytes, int offset)
            : base(bytes, offset)
        {
        }

        public DfaReader(byte[] bytes)
            : this(bytes, 0)
        {
        }

        public Dfa Read()
        {
            var stateCount = ReadInt32();
            var states = new DfaState[stateCount];
            for (var i = 0; i < stateCount; ++i)
            {
                var final = ReadBool();
                var payload = ReadInt32() - 1;
                var trans = new DfaTrans[ReadInt32()];
                states[i] = new DfaState(i, final, payload, trans);
            }

            var setCount = ReadInt32();
            var sets = new Set[setCount];
            for (var s = 0; s < setCount; ++s)
            {
                var intervalCount = ReadInt32();
                var intervals = new Interval[intervalCount];
                for (var i = 0; i < intervalCount; ++i)
                {
                    intervals[i] = new Interval(ReadInt32(), ReadInt32());
                }
                sets[s] = new Set(intervals);
            }

            var transitionCount = ReadInt32();
            var transitions = new DfaTrans[transitionCount];
            for (var t = 0; t < transitionCount; ++t)
            {
                var target = states[ReadInt32()];
                var set = sets[ReadInt32()];
                transitions[t] = new DfaTrans(target, set);
            }

            for (var s = 0; s < stateCount; ++s)
            {
                var state = states[s];
                for (var t = 0; t < state.Transitions.Length; ++t)
                {
                    state.Transitions[t] = transitions[ReadInt32()];
                }
            }

            return new Dfa(states);
        }
    }
}
