using Lingu.Automata;

namespace Lingu.Tree
{
    public class AtomAny : Atom
    {
        public override Nfa GetNfa() => Nfa.Any;
    }
}
