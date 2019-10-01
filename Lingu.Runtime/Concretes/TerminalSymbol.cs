using Lingu.Runtime.Structures;

namespace Lingu.Runtime.Concretes
{
    public class TerminalSymbol : Symbol, ITerminal
    {
        public TerminalSymbol(int id, string name, string visual)
            : base(id, name)
        {
            Visual = visual;
        }

        public string Visual { get; }
    }
}
