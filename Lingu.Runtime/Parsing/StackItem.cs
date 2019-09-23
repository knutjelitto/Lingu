using Lingu.Runtime.Structures;

namespace Lingu.Runtime.Parsing
{
    internal struct StackItem
    {
        public readonly int State;
        public readonly IToken Token;

        public StackItem(int state, IToken token)
        {
            State = state;
            Token = token;
        }
    }
}
