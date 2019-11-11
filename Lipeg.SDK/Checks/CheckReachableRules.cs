﻿using Lipeg.Runtime;
using Lipeg.SDK.Tree;

namespace Lipeg.SDK.Checks
{
    /// <summary>
    /// Check for rules that are reached from start symbol
    /// </summary>
    public class CheckReachableRules : Check, ICheckPass
    {
        public CheckReachableRules(Semantic semantic)
        : base(semantic)
        {
        }

        public void Check()
        {
            var start = Semantic[Grammar].Start;
            Semantic[start].SetReachable();
            var spacing = Semantic[Grammar].Spacing;
            Semantic[spacing].SetReachable();

            var visitor = new Visitor(Semantic);
            visitor.VisitExpression(start.Expression);
            visitor.VisitExpression(spacing.Expression);

            foreach (var rule in Semantic.Rules)
            {
                if (!Semantic[rule].Reachable)
                {
                    Results.AddError(new CheckError(ErrorCode.UnreachableRule, rule.Identifier));
                }
            }

        }

        private class Visitor : TreeVisitor
        {
            public Visitor(Semantic semantic) : base(semantic) { }

            protected override void VisitNameExpression(NameExpression expression)
            {
                var rule = Semantic.Rules[expression.Identifier.Name];
                if (Semantic[rule].SetReachable())
                {
                    VisitExpression(rule.Expression);
                }
            }
        }
    }
}
