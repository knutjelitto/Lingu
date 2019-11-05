using System;

using Lipeg.Runtime;
using Lipeg.SDK.Tree;

namespace Lipeg.SDK.Checking
{
    /// <summary>
    /// Check if all rules are defined
    /// </summary>
    public class CheckDefinedRules : Check, ICheckPass
    {
        public CheckDefinedRules(Semantic semantic)
            : base(semantic)
        {
        }

        public void Check()
        {
            new CheckDefinedVisitor(Semantic).VisitGrammarRules();
        }

        private class CheckDefinedVisitor : CheckVisitor
        {
            public CheckDefinedVisitor(Semantic semantic) : base(semantic) { }

            protected override void VisitNameExpression(NameExpression expression)
            {
                if (!Semantic.Rules.TryGetValue(expression.Identifier.Name, out var _))
                {
                    Results.AddError(new CheckError(ErrorCode.UndefinedRule, expression.Identifier.Location, expression.Identifier.Name));
                }
            }
        }
    }
}
