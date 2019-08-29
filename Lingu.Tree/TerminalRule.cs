namespace Lingu.Tree
{
    public class TerminalRule : TerminalItem
    {
        public TerminalRule(AtomName name, TerminalExpression definition)
            : base(name)
        {
            Definition = definition;
        }

        public TerminalExpression Definition { get; }
    }
}
