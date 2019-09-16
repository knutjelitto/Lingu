using Lingu.Runtime.LexDfa;
using Lingu.Tree;
using Lingu.Writers;

namespace Lingu.Grammars
{
    public class Terminal : Symbol
    {
        public Terminal(string name)
            : base(name)
        {
        }

        public Dfa Dfa { get; set; }
        public byte[] Bytes { get; set; }
        public string Visual { get; set; }
        public RawTerminal Raw { get; set; }

        public override void Dump(IndentWriter writer)
        {
        }
    }
}
