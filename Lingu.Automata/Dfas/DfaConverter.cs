using System;
using System.Collections.Generic;
using System.Linq;
using Lingu.Commons;

namespace Lingu.Automata
{
    public class DfaConverter
    {
        public DfaConverter(Dfa dfa)
        {
            Dfa = dfa;
        }

        public Dfa Dfa { get; }

        public void Convert()
        {
            var once = new UniqueQueue<DfaStateSet>();
            var start = new DfaStateSet(Dfa.Start);
            once.Enqueue(start);

            while (once.Count > 0)
            {
                var prev = once.Dequeue();
                var next = new DfaStateSet();

                foreach (var state in prev)
                {

                }
            }
        }
    }
}
