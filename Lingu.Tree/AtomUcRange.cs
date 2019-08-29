namespace Lingu.Tree
{
    public class AtomUcRange : TerminalAtom
    {
        public AtomUcRange(TerminalUcCodepoint from, TerminalUcCodepoint to)
        {
            From = from;
            To = to;
        }

        public TerminalUcCodepoint From { get; }
        public TerminalUcCodepoint To { get; }
    }
}
