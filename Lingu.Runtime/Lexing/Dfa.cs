#nullable enable

namespace Lingu.Runtime.Lexing
{
    public class Dfa
    {
        public static Dfa Nope = new Dfa();

        public readonly DfaState[] States;

        public Dfa(params DfaState[] states)
        {
            States = states;
        }

        public DfaState Start => States[0];
    }
}
