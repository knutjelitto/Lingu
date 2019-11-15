using System;

using Lipeg.Runtime;
using Lipeg.SDK.Tree;

namespace Lipeg.SDK.Checkers
{
    /// <summary>
    /// Check if all rules are defined
    /// </summary>
    public class CheckUndefinedRules : ACheckBase, ICheckPass
    {
        public CheckUndefinedRules(Semantic semantic)
            : base(semantic)
        {
        }

        public void Check()
        {
            new Visitor(Semantic).VisitGrammarRules();
        }

        private class Visitor : TreeVisitor
        {
            public Visitor(Semantic semantic) : base(semantic) { }

            protected override void VisitNameExpression(NameExpression expression)
            {
                if (!Semantic.Rules.TryGetValue(expression.Identifier.Name, out var _))
                {
                    Results.AddError(new CheckError(ErrorCode.UndefinedRule, expression.Identifier));
                    return;
                }
            }
        }
    }
}
