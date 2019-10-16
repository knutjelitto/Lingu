#nullable enable

namespace Lingu.Automata
{
    public partial class FA
    {
        private static partial class Operations
        {
            public static FA Complement(FA dfa)
            {
                EnsureDfa(dfa);

                for (var i = 0; i < dfa.States.Count; ++i)
                {
                    dfa.States[i].Final = !dfa.States[i].Final;
                }

                return dfa;
            }
        }
    }
}
