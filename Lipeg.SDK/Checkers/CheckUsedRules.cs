using Lipeg.Runtime;
using Lipeg.SDK.Tree;

namespace Lipeg.SDK.Checkers
{
    /// <summary>
    /// Check for rules that are used
    /// </summary>
    public class CheckUsedRules : ACheckBase, ICheckPass
    {
        public CheckUsedRules(Semantic semantic)
        : base(semantic)
        {
        }

        public void Check()
        {
            new Visitor(Semantic).VisitGrammarRules();

            foreach (var rule in Semantic.Rules)
            {
                if (!Semantic[rule].IsUsed)
                {
                    Results.AddError(new CheckError(ErrorSeverity.Warning, ErrorCode.UnusedRule, rule.Identifier));
                }
            }
        }

        private class Visitor : TreeVisitor
        {
            public Visitor(Semantic semantic) : base(semantic) { }

            protected override void VisitNameExpression(NameExpression expression)
            {
                Semantic[Semantic.Rules[expression.Identifier.Name]].SetIsUsed(true);
            }
        }
    }
}
