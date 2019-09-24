namespace Lingu.Automata
{
    public class Transition
    {
        public Transition(Integers set, State target)
        {
            Set = set;
            Target = target;
            TransitionId = -1;
            SetId = -1;
        }

        public Integers Set { get; }
        public State Target { get; private set; }
        public int TargetId => Target.Id;

        public int TransitionId { get; set; }
        public int SetId { get; set; }

        public void Retarget(State newTarget)
        {
            Target = newTarget;
        }

        public override string ToString()
        {
            return $"{Set.ToIString()}->{TargetId.ToString()}";
        }
    }
}