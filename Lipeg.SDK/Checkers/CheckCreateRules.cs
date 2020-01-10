using System.Collections.Generic;
using System.Linq;

using Lipeg.Runtime;
using Lipeg.SDK.Tree;

namespace Lipeg.SDK.Checkers
{
    /// <summary>
    /// Create all rules
    /// </summary>
    internal class CheckCreateRules : CheckBase, ICheckPass
    {
        public CheckCreateRules(Grammar grammar)
            : base(grammar)
        {
        }

        public void Check()
        {
            foreach (var syntaxRule in Grammar.SyntaxRules)
            {
                syntaxRule.Attr.SetIsLexical(false);
            }
            foreach (var lexicalRule in Grammar.LexicalRules)
            {
                lexicalRule.Attr.SetIsLexical(true);
            }

            var visitor = new Visitor(Grammar, this);

            foreach (var rule in Grammar.AllRules.ToList())
            {
                TryAdd(rule);

                visitor.Visit(rule);
            }
        }

        public void TryAdd(IRule rule)
        {
            if (Grammar.Attr.Rules.TryGetValue(rule.Identifier.Name, out var already))
            {
                if (already == null) throw new InternalNullException();

                Results.AddError(new MessageError(MessageCode.AlreadyDefinedRule, already.Identifier));
                Results.AddError(new MessageError(MessageCode.RedefinedRule, rule.Identifier));
            }
            else
            {
                Grammar.Attr.Rules.Add(rule);
            }
        }

        private class Visitor : TreeVisitor
        {
            public Visitor(Grammar grammar, CheckCreateRules check)
                : base(grammar)
            {
                Check = check;
            }
            public CheckCreateRules Check { get; }

            private readonly Stack<IRule> parents = new Stack<IRule>();

            public void Visit(IRule rule)
            {
                this.parents.Push(rule);
                VisitRule(rule);
                this.parents.Pop();
            }

            protected override void VisitInlineExpression(InlineExpression expression)
            {
                var parent = this.parents.Peek();
                var rule = Rule.From(parent.Identifier.With(expression.InlineRule.Identifier), expression.InlineRule.Expression);

                Check.TryAdd(rule);
                rule.Attr.SetIsLexical(parent.Attr.IsLexical);
                rule.Attr.SetIsInline(true);
                if (rule.Attr.IsLexical)
                {
                    Grammar.LexicalRules.Add(rule);
                }
                else
                {
                    Grammar.SyntaxRules.Add(rule);
                }
                expression.Rule = rule;
                Visit(rule);
            }
        }
    }
}
