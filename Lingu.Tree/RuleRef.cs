namespace Lingu.Tree
{
    public class RuleRef : RuleExpression
    {
        public RuleRef(AtomName name)
        {
            Name = name;
        }

        public AtomName Name { get; }
    }
}
