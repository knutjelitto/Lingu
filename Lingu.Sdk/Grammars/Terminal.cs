using Lingu.Commons;
using Lingu.Runtime.LexDfa;

namespace Lingu.Grammars
{
    public abstract class Terminal : Rule
    {
        public Terminal(int id, string name)
            : base(id, name)
        {
        }

        public Terminal(string name)
            : this(-1, name)
        {
        }

        public bool IsFragment { get; set; }
        public Dfa Dfa { get; set; }
        public string Alias { get; set; }
    }
}
