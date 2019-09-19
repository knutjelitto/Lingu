namespace Lingu.LR
{
    public class Goto : Action
    {
        public Goto(int state)
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
            return $"goto {State}";
        }
    }
}
