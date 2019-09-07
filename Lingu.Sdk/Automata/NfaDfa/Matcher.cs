namespace Lingu.Automata
{
    public class Matcher
    {
        public Matcher(FA automaton)
        {
            FA = automaton;
            State = FA.Start;
        }

        public FA FA { get; }

        public State State { get; private set; }

        public bool FullMatch(string characters)
        {
            State = FA.Start;

            foreach (var character in characters)
            {
                var matched = false;

                foreach (var transition in State.Transitions)
                {
                    if (transition.Terminal.Contains(character))
                    {
                        State = transition.Target;
                        matched = true;
                        break;
                    }
                }

                if (!matched)
                {
                    return false;
                }
            }

            return State.IsFinal;
        }
    }
}