namespace Lingu.Tree
{
    public sealed class RuleDefinition : Definition
    {
        public RuleDefinition(bool generated, Name name, Expression expression)
            : base(generated, name, expression)
        {
        }

        public RuleDefinition(Name name, Expression expression)
            : base(false, name, expression)
        {
        }
    }
}
