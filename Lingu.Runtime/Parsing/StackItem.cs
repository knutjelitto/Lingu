using Lingu.Runtime.Structures;
using System.Diagnostics;

namespace Lingu.Runtime.Parsing
{
    [DebuggerDisplay("{DD()}")]
    internal struct StackItem
    {
        public readonly int State;
        public readonly IToken Token;

        public StackItem(IToken token, int state)
        {
            State = state;
            Token = token;
        }

        public string DD()
        {
            return $"{Token},{State}";
        }
    }
}
