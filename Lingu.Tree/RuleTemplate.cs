namespace Lingu.Tree
{
    public sealed class RuleTemplate : RuleItem
    {
        public RuleTemplate(AtomName name, RuleTemplateParams templateParams,  RuleExpression expression)
            : base(name)
        {
            TemplateParams = templateParams;
            Expression = expression;
        }

        public RuleTemplateParams TemplateParams { get; }
        public RuleExpression Expression { get; }
    }
}
