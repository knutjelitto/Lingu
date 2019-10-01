using Lingu.Runtime.Structures;

namespace Lingu.Runtime.Concretes
{
    public class NonterminalSymbol : Symbol, INonterminal
    {
        public NonterminalSymbol(int id, string name, RepeatKind repeat, LiftKind lift)
            : base(id, name)
        {
            Repeat = repeat;
            Lift = lift;
        }

        public RepeatKind Repeat { get; }
        public LiftKind Lift { get; }
    }
}
