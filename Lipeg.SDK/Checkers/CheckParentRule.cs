using System.Collections.Generic;

using Lipeg.SDK.Tree;

namespace Lipeg.SDK.Checkers
{
    /// <summary>
    /// Check for rules that are reached from start symbol
    /// </summary>
    public class CheckParentRules : CheckBase, ICheckPass
    {
        public CheckParentRules(Grammar grammar)
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
                expression.Attr.SetRule(Rule);
                if (Rule.Attr.IsSyntax && expression.Attr.IsLexical)
                {
                    expression.Attr.SetIsWithSpacing(true);
                }
            }
        }
    }
}
