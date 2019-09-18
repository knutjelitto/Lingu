namespace Lingu.LR
{
    public class Shift : Action
    {
        public Shift(int state)
        {
            State = state;
        }

        public int State { get; private set; }

        public void Patch(int newState)
        {
            State = newState;
        }

        public override string ToString()
        {
            return $"shift {State}";
        }
    }
}
