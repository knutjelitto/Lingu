namespace Lingu.Runtime.Parsing
{
    public struct StackItem
    {
        public readonly int State;
        public readonly object Payload;

        public StackItem(int state, object payload)
        {
            State = state;
            Payload = payload;
        }
    }
}
