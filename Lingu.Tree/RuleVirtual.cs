namespace Lingu.Tree
{
    public class RuleVirtual : RuleExpression
    {
        public RuleVirtual(LitString value)
        {
            Value = value;
        }

        public LitString Value { get; }
    }
}
