using Lipeg.Runtime;
using Lipeg.SDK.Tree;

namespace Lipeg.SDK.Checkers
{
    /// <summary>
    /// Check for rules that are used
    /// </summary>
    public class CheckIsUsedRules : CheckBase, ICheckPass
    {
        public CheckIsUsedRules(Grammar grammar)
            : base(grammar)
        {
        }

        public void Check()
        {
            new Visitor(Grammar).VisitGrammarRules();

            foreach (var rule in Grammar.Attr.Rules)
            {
                if (!rule.Attr.IsUsed)
                {
                    Results.AddError(new MessageWarning(MessageCode.UnusedRule, rule.Identifier));
                }
            }
        }

        private class Visitor : TreeVisitor
        {
            public Visitor(Grammar grammar) : base(grammar) { }

            protected override void VisitNameExpression(NameExpression expression)
            {
                Grammar.Attr.Rules[expression.Identifier.Name].Attr.SetIsUsed(true);
            }

            protected override void VisitInlineExpression(InlineExpression expression)
            {
                Grammar.Attr.Rules[expression.Rule.Identifier.Name].Attr.SetIsUsed(true);
            }
        }
    }
}
