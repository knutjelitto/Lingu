using Lipeg.Runtime;
using Lipeg.SDK.Tree;

namespace Lipeg.SDK.Checkers
{
    /// <summary>
    /// Check for rules that are used
    /// </summary>
    public class CheckIsUsedRules : ACheckBase, ICheckPass
    {
        public CheckIsUsedRules(Semantic semantic)
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
                    Results.AddError(new MessageWarning(MessageCode.UnusedRule, rule.Identifier));
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

            protected override void VisitInlineExpression(InlineExpression expression)
            {
                Semantic[Semantic.Rules[expression.Rule.Identifier.Name]].SetIsUsed(true);
            }
        }
    }
}
