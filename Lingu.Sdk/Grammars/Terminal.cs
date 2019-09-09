using Lingu.Commons;
using Lingu.Runtime.LexDfa;

namespace Lingu.Grammars
{
    public abstract class Terminal : Symbol
    {
        public Terminal(string name)
            : base(name)
        {
        }

        public int Id { get; set;  }
        public bool IsFragment { get; set; }
        public bool IsGenerated { get; set; }
        public Dfa Dfa { get; set; }
        public string Alias { get; set; }
    }
}
