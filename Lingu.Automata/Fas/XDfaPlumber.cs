using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lingu.Automata
{
    public class XDfaPlumber
    {
        public XDfaPlumber(XDfa dfa)
        {
            Dfa = dfa;
        }

        protected XDfa Dfa { get; private set; }

        public void Dump(string prefix, TextWriter writer)
        {
        }
    }
}