using Lingu.Runtime.LexDfa;

namespace Lingu.Grammars
{
    public class Terminal : Symbol<Terminal>
    {
        public Terminal(string name, Dfa dfa)
            : this(name, null, dfa)
        {
        }

        public Terminal(string name, string alias, Dfa dfa)
            : base(name)
        {
            Alias = alias;
            Dfa = dfa;
        }

        public string Alias { get; }
        public Dfa Dfa { get; }
    }
}
