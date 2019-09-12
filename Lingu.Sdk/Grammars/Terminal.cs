using Lingu.Runtime.LexDfa;
using Lingu.Tree;
using Lingu.Writers;

namespace Lingu.Grammars
{
    public class Terminal : Rule
    {
        public Terminal(string name)
            : base(name)
        {
        }

        public bool IsFragment { get; set; }
        public Dfa Dfa { get; set; }
        public byte[] Bytes { get; set; }
        public string Alias { get; set; }
        public RawTerminal Raw { get; set; }

        public override void Dump(IndentWriter output, bool top)
        {
            Raw.Dump(output, top);
        }
    }
}
