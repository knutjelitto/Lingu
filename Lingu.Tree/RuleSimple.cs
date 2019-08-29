namespace Lingu.Tree
{
    public sealed class RuleSimple : RuleItem
    {
        public RuleSimple(AtomName name, RuleExpression expression)
            : base(name)
        {
            Expression = expression;
        }
        public RuleExpression Expression { get; }
    }
}
