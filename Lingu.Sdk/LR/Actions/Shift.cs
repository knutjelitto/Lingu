namespace Lingu.LR
{
    public class Shift : Action
    {
        public Shift(int state)
        {
            State = state;
        }

        public int State { get; }

        public override string ToString()
        {
            return $"shift {State}";
        }
    }
}
