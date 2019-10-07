using Lingu.Runtime.Structures;
using System.Diagnostics;

namespace Lingu.Runtime.Parsing
{
    [DebuggerDisplay("{DD()}")]
    internal struct StackItem
    {
        public readonly int StateId;
        public readonly IToken Token;

        public StackItem(IToken token, int state)
        {
            StateId = state;
            Token = token;
        }

        public string DD()
        {
            return $"{Token},{StateId}";
        }
    }
}
