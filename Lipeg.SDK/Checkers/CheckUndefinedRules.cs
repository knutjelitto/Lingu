using System;

using Lipeg.Runtime;
using Lipeg.SDK.Tree;

namespace Lipeg.SDK.Checkers
{
    /// <summary>
    /// Check if all rules are defined
    /// </summary>
    public class CheckUndefinedRules : CheckBase, ICheckPass
    {
        public CheckUndefinedRules(Grammar grammar)
            : base(grammar)
        {
        }

        public void Check()
        {
            new Visitor(Grammar).VisitGrammarRules();
        }

        private class Visitor : TreeVisitor
        {
            public Visitor(Grammar grammar) : base(grammar) { }

            protected override void VisitNameExpression(NameExpression expression)
            {
                if (!Grammar.Attr.Rules.TryGetValue(expression.Identifier.Name, out var _))
                {
                    Results.AddError(new MessageError(MessageCode.UndefinedRule, expression.Identifier));
                    return;
                }
            }
        }
    }
}
