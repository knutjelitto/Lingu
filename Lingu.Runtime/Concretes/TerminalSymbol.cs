using Lingu.Runtime.Structures;

namespace Lingu.Runtime.Concretes
{
    public class TerminalSymbol : Symbol, ITerminal
    {
        public TerminalSymbol(int id, string name, bool visible, string visual)
            : base(id, name, visible)
        {
            Visual = visual;
        }

        public string Visual { get; }
    }
}
