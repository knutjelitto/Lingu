using Lipeg.Runtime;
using Lipeg.SDK.Tree;

namespace Lipeg.SDK.Checks
{
    /// <summary>
    /// Check if all rules are used
    /// </summary>
    public class CheckUnusedRules : Check, ICheckPass
    {
        public CheckUnusedRules(Semantic semantic)
        : base(semantic)
        {
        }

        public void Check()
        {
            new CheckUsedVisitor(Semantic).VisitGrammarRules();

            foreach (var rule in Semantic.Rules)
            {
                if (!rule.Attributes.Used)
                {
                    Results.AddError(new CheckError(ErrorCode.UnusedRule, rule.Identifier));
                }
            }
        }

        private class CheckUsedVisitor : TreeVisitor
        {
            public CheckUsedVisitor(Semantic semantic) : base(semantic) { }

            protected override void VisitNameExpression(NameExpression expression)
            {
                Semantic.Rules[expression.Identifier.Name].Attributes.Use();
            }
        }
    }
}
