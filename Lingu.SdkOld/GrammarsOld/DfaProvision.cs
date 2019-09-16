using Lingu.Automata;
using Lingu.Grammars;

namespace Lingu.GrammarsOld
{
    public class DfaProvision : Provision
    {
        private DfaProvision(string name, FA nfa)
            : base(name)
        {
            Dfa = nfa.ToDfa().Minimize();
            Terminal = new Terminal(this);
        }

        public FA Dfa { get; }
        public override Terminal Terminal { get; }

        public static DfaProvision From(string name, FA nfa)
        {
            return new DfaProvision(name, nfa);
        }

        public override Lexer MakeLexer(int offset)
        {
            return new DfaLexer(Terminal, offset);
        }
    }
}