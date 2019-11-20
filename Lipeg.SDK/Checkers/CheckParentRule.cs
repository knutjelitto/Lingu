using System.Collections.Generic;

using Lipeg.SDK.Tree;

namespace Lipeg.SDK.Checkers
{
    /// <summary>
    /// Check for rules that are reached from start symbol
    /// </summary>
    public class CheckParentRules : ACheckBase, ICheckPass
    {
        public CheckParentRules(Semantic semantic)
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

            private Stack<IRule> rules = new Stack<IRule>();
            private void Push(IRule rule) => rules.Push(rule);
            private void Pop() => rules.Pop();
            private IRule Rule => rules.Peek();

            protected override void VisitRule(IRule rule)
            {
                Push(rule);
                base.VisitRule(rule);
                Pop();
            }

            public override void VisitExpression(Expression expression)
            {
                base.VisitExpression(expression);
                expression.Attr(Semantic).SetRule(Rule);
            }
        }
    }
}
