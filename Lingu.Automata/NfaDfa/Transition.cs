namespace Lingu.Automata
{
    public class Transition
    {
        public Transition(Atom terminal, State target)
        {
            Terminal = terminal;
            Target = target;
        }

        public Atom Terminal { get; }
        public State Target { get; private set; }

        public void Retarget(State newTarget)
        {
            Target = newTarget;
        }

        public override string ToString()
        {
            return Terminal.ToIString();
        }
    }
}