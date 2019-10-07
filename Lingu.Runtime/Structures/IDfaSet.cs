using Lingu.Runtime.Lexing;

namespace Lingu.Runtime.Structures
{
    public interface IDfaSet
    {
        Dfa this[int stateId] { get; }

        Dfa Spacing { get; }
    }
}