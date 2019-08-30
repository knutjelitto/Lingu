namespace Lingu.Tree
{
    public sealed class Rule : NamedNode
    {
        public Rule(AtomName name, RuleExpression expression)
            : base(name)
        {
            Expression = expression;
        }
        public RuleExpression Expression { get; }
    }
}
