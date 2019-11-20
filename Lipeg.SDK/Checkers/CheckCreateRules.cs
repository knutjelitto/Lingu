using System.Collections.Generic;
using System.Linq;

using Lipeg.Runtime;
using Lipeg.SDK.Tree;

namespace Lipeg.SDK.Checkers
{
    /// <summary>
    /// Create all rules
    /// </summary>
    internal class CheckCreateRules : ACheckBase, ICheckPass
    {
        public CheckCreateRules(Semantic semantic)
            : base(semantic)
        {
        }

        public void Check()
        {
            foreach (var syntaxRule in Grammar.SyntaxRules)
            {
                syntaxRule.Attr(Semantic).SetIsLexical(false);
            }
            foreach (var lexicalRule in Grammar.LexicalRules)
            {
                lexicalRule.Attr(Semantic).SetIsLexical(true);
            }

            var visitor = new Visitor(this, Semantic);

            foreach (var rule in Grammar.Rules.ToList())
            {
                TryAdd(rule);

                visitor.Visit(rule);
            }
        }

        public void TryAdd(IRule rule)
        {
            if (Semantic.Rules.TryGetValue(rule.Identifier.Name, out var already))
            {
                if (already == null) throw new InternalErrorException($"{nameof(already)} really shouldn't be NULL");

                Results.AddError(new MessageError(MessageCode.AlreadyDefinedRule, already.Identifier));
                Results.AddError(new MessageError(MessageCode.RedefinedRule, rule.Identifier));
            }
            else
            {
                Semantic.Rules.Add(rule);
            }
        }

        private class Visitor : TreeVisitor
        {
            public Visitor(CheckCreateRules check, Semantic semantic)
                : base(semantic)
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
                rule.Attr(Semantic).SetIsLexical(parent.Attr(Semantic).IsLexical);
                if (rule.Attr(Semantic).IsLexical)
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
