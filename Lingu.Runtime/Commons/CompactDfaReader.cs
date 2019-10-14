using System.Diagnostics;
using System.Linq;

using Lingu.Runtime.Lexing;
using Lingu.Runtime.Structures;

#nullable enable

namespace Lingu.Runtime.Commons
{
    public class CompactDfaReader
    {
        private readonly BinReader reader;

        public CompactDfaReader(BinReader reader)
        {
            this.reader = reader;
        }

        public IDfaSet Read()
        {
            var map = this.reader.ReadInt32Array();

            var setsCount = this.reader.ReadInt32();
            var sets = new Set[setsCount];
            for (var s = 0; s < sets.Length; ++s)
            {
                var intervalCount = this.reader.ReadInt32();
                var intervals = new Interval[intervalCount];
                for (var i = 0; i < intervalCount; ++i)
                {
                    var min = this.reader.ReadInt32();
                    var max = this.reader.ReadInt32();
                    intervals[i] = new Interval(min, max);
                }
                sets[s] = new Set(intervals);
            }

            var dfaCount = this.reader.ReadInt32();
            var dfas = new Dfa[dfaCount];
            for (var d = 0; d < dfaCount; ++d)
            {
                var stateCount = this.reader.ReadInt32();
                var states = new DfaState[stateCount];
                for (var s = 0; s < stateCount; ++s)
                {
                    var final = this.reader.ReadBool();
                    var payload = this.reader.ReadInt32() - 1;
                    states[s] = new DfaState(s, final, payload);
                }
                for (var s = 0; s < stateCount; ++s)
                {
                    var transitionCount = this.reader.ReadInt32();
                    var transitions = new DfaTrans[transitionCount];
                    for (var t = 0; t < transitionCount; ++t)
                    {
                        var setId = this.reader.ReadInt32();
                        var targetId = this.reader.ReadInt32();
                        Debug.Assert(targetId < stateCount);
                        transitions[t] = new DfaTrans(states[targetId], sets[setId]);
                    }
                    states[s].Transitions = transitions;
                }
                dfas[d] = new Dfa(states);
            }

            return new DfaSet(dfas, map, dfas.Last());
        }
    }
}
