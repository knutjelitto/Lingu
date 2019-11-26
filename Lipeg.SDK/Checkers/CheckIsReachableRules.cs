﻿using Lipeg.Runtime;
using Lipeg.SDK.Tree;

namespace Lipeg.SDK.Checkers
{
    /// <summary>
    /// Check for rules that are reached from start symbol
    /// </summary>
    public class CheckIsReachableRules : ACheckBase
        , ICheckPass
    {
        public CheckIsReachableRules(Semantic semantic)
        : base(semantic)
        {
        }

        public void Check()
        {
            var start = Semantic[Grammar].Start;
            Semantic[start].SetIsReachable(true);
            var spacing = Semantic[Grammar].Spacing;
            Semantic[spacing].SetIsReachable(true);

            var visitor = new Visitor(Semantic);
            visitor.VisitExpression(start.Expression);
            visitor.VisitExpression(spacing.Expression);

            foreach (var rule in Semantic.Rules)
            {
                if (!Semantic[rule].IsReachable)
                {
                    Results.AddError(new MessageWarning(MessageCode.UnreachableRule, rule.Identifier));
                }
            }

        }

        private class Visitor : TreeVisitor
        {
            public Visitor(Semantic semantic) : base(semantic) { }

            protected override void VisitNameExpression(NameExpression expression)
            {
                var rule = Semantic.Rules[expression.Identifier.Name];
                if (Semantic[rule].SetIsReachable(true))
                {
                    VisitExpression(rule.Expression);
                }
            }

            protected override void VisitInlineExpression(InlineExpression expression)
            {
                var rule = Semantic.Rules[expression.Rule.Identifier.Name];
                if (Semantic[rule].SetIsReachable(true))
                {
                    VisitExpression(rule.Expression);
                }
            }
        }
    }
}