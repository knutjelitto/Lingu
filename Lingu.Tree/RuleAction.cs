namespace Lingu.Tree
{
    public class RuleAction : RuleExpression
    {
        public RuleAction(AtomName name)
        {
            Name = name;
        }

        public AtomName Name { get; }
    }
}
