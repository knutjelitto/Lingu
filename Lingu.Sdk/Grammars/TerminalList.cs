using Lingu.Commons;

namespace Lingu.Grammars
{
    public class TerminalList : UniqueList<Symbol, Terminal>
    {
        public TerminalList()
            : base(terminal => terminal, new Symbol.NamesEquals())
        {
        }
    }
}
