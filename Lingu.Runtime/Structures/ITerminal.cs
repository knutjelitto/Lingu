using Lingu.Runtime.Lexing;

namespace Lingu.Runtime.Structures
{
    public interface ITerminal : ISymbol
    {
        string Visual { get; }
    }
}
