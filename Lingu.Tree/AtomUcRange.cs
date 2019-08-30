namespace Lingu.Tree
{
    public class AtomUcRange : TerminalAtom
    {
        public AtomUcRange(TerminalExpression from, TerminalExpression to)
        {
            From = from;
            To = to;
        }

        public TerminalExpression From { get; }
        public TerminalExpression To { get; }
    }
}
