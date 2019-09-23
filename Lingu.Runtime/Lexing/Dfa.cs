#nullable enable

namespace Lingu.Runtime.Lexing
{
    public class Dfa
    {
        public readonly DfaState[] States;

        public Dfa(DfaState[] states)
        {
            States = states;
        }

        public DfaState Start => States[0];
    }
}
