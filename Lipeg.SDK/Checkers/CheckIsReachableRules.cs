using Lipeg.Runtime;
using Lipeg.SDK.Tree;

namespace Lipeg.SDK.Checkers
{
    /// <summary>
    /// Check for rules that are reached from start symbol
    /// </summary>
    public class CheckIsReachableRules : CheckBase
        , ICheckPass
    {
        public CheckIsReachableRules(Grammar grammar)
            : base(grammar)
        {
        }

        public void Check()
        {
            var start = Grammar.Attr.Start;
            start.Attr.SetIsReachable(true);
            var spacing = Grammar.Attr.Spacing;
            spacing.Attr.SetIsReachable(true);

            var visitor = new Visitor(Grammar);
            visitor.VisitExpression(start.Expression);
            visitor.VisitExpression(spacing.Expression);

            foreach (var rule in Grammar.Attr.Rules)
            {
                if (!rule.Attr.IsReachable)
                {
                    Results.AddError(new MessageWarning(MessageCode.UnreachableRule, rule.Identifier));
                }
            }

        }

        private class Visitor : TreeVisitor
        {
            public Visitor(Grammar grammar) : base(grammar) { }

            protected override void VisitNameExpression(NameExpression expression)
            {
                var rule = Grammar.Attr.Rules[expression.Identifier.Name];
                if (rule.Attr.SetIsReachable(true))
                {
                    VisitExpression(rule.Expression);
                }
            }

            protected override void VisitInlineExpression(InlineExpression expression)
            {
                var rule = Grammar.Attr.Rules[expression.Rule.Identifier.Name];
                if (rule.Attr.SetIsReachable(true))
                {
                    VisitExpression(rule.Expression);
                }
            }
        }
    }
}
