using Lipeg.Runtime;
using Lipeg.SDK.Tree;

namespace Lipeg.SDK.Checks
{
    /// <summary>
    /// Check for rules that are used
    /// </summary>
    public class CheckUsedRules : Check, ICheckPass
    {
        public CheckUsedRules(Semantic semantic)
        : base(semantic)
        {
        }

        public void Check()
        {
            new CheckUsedVisitor(Semantic).VisitGrammarRules();

            foreach (var rule in Semantic.Rules)
            {
                if (!Semantic[rule].Used)
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
                Semantic[Semantic.Rules[expression.Identifier.Name]].SetUsed();
            }
        }
    }
}
