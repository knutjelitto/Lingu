namespace Lingu.Tree
{
    public class TerminalRepetition : TerminalExpression
    {
        public TerminalRepetition(TerminalExpression expression, int? min = null, int? max = null)
        {
            Expression = expression;
            Min = min;
            Max = max;
        }

        public TerminalExpression Expression { get; }
        public int? Min { get; }
        public int? Max { get; }
    }
}
