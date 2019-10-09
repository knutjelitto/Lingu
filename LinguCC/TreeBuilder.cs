using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using Lingu.Grammars;
using Lingu.Runtime.Structures;
using Lingu.Tree;

namespace Lingu.CC
{
    public class TreeBuilder : LinguVisitor.Visitor<object>
    {
        protected override object Default(IToken token) => throw new NotImplementedException();

        public RawGrammar Visit(INonterminalToken root)
        {
            return Visit<RawGrammar>(root);
        }

        public override object OnFile(INonterminalToken token)
        {
            return Visit<RawGrammar>(token[0]);
        }

        public override object OnGrammar(INonterminalToken token)
        {
            Debug.Assert(token[0].Symbol == LinguContext.Data.identifier);
            var grammar = new RawGrammar(token.Terminal(0).Value);

            foreach (var section in token.Nonterminal(1).Children)
            {
                var children = Visit<IReadOnlyList<Symbol>>(section);

                grammar.Options.AddRange(children.OfType<Option>());
                grammar.Terminals.AddRange(children.OfType<TerminalRule>());
                grammar.Nonterminals.AddRange(children.OfType<NonterminalRule>());
            }
            return grammar;
        }

        public override object OnGrammarOptions(INonterminalToken token)
        {
            return token.Nonterminal(0).Children.Select(Visit<Option>).ToArray();
        }

        public override object OnOption(INonterminalToken token)
        {
            return new Option(token.Terminal(0).Value, token.Terminal(1).Value);
        }

        public override object OnGrammarRules(INonterminalToken token)
        {
            return token.Nonterminal(0).Children.Select(Visit<NonterminalRule>).ToArray();
        }

        public override object OnRule(INonterminalToken token)
        {
            return NonterminalRule.From(token.Terminal(0).Value, false, Visit<IExpression>(token[1]));
        }

        public override object OnRuleExpression(INonterminalToken token)
        {
            var expression = Visit<IExpression>(token[0]);

            var children = token.Nonterminal(1).Children;

            if (children.Count > 0)
            {
                var expressions = new List<IExpression> {expression};
                foreach (var child in children)
                {
                    expressions.Add(Visit<IExpression>(child));
                }
                expression = new Alternates(expressions);
            }

            return expression;
        }

        public override object OnRuleSequence(INonterminalToken token)
        {
            var children = token.Nonterminal(0).Children;
            var expressions = children.Select(Visit<IExpression>).ToArray();
            if (expressions.Length > 1)
            {
                return new Sequence(expressions);
            }

            return expressions[0];
        }

        public override object OnIdentifier(ITerminalToken token)
        {
            return new Name(token.Value);
        }

        public override object OnRuleDropElement(INonterminalToken token)
        {
            return new Drop(Visit<IExpression>(token[0]));
        }

        public override object OnRulePromoteElement(INonterminalToken token)
        {
            return new Promote(Visit<IExpression>(token[0]));
        }

        public override object OnText(ITerminalToken token)
        {
            return new Tree.String(token.Value);
        }

        public override object OnRuleStarClosure(INonterminalToken token)
        {
            return Repeat.Star(Visit<IExpression>(token[0]));
        }

        public override object OnRulePlusClosure(INonterminalToken token)
        {
            return Repeat.Plus(Visit<IExpression>(token[0]));
        }

        public override object OnRuleOptional(INonterminalToken token)
        {
            return Repeat.Optional(Visit<IExpression>(token[0]));
        }

        public override object OnGrammarTerminals(INonterminalToken token)
        {
            return token.Nonterminal(0).Children.Select(Visit<TerminalRule>).ToArray();
        }

        public override object OnTerminalRule(INonterminalToken token)
        {
            return TerminalRule.From(token.Terminal(0).Value, Visit<IExpression>(token[1]));
        }

        public override object OnTerminalExpression(INonterminalToken token)
        {
            var expressions = new List<IExpression>() { Visit<IExpression>(token[0]) };

            var children = token.Nonterminal(1).Children;

            expressions.AddRange(children.Select(Visit<IExpression>));

            if (expressions.Count > 1)
            {
                return new Alternates(expressions);
            }

            return expressions[0];
        }

        public override object OnTerminalSequence(INonterminalToken token)
        {
            var children = token.Nonterminal(0).Children;
            var expressions = children.Select(Visit<IExpression>).ToArray();
            if (expressions.Length > 1)
            {
                return new Sequence(expressions);
            }

            return expressions[0];
        }

        public override object OnUcCodepoint(ITerminalToken token)
        {
            return new UcCodepoint(token.Value);
        }
        public override object OnUcBlock(ITerminalToken token)
        {
            return new UcBlock(token.Value);
        }

        public override object OnUcCategory(ITerminalToken token)
        {
            return new UcCategory(token.Value);
        }

        public override object OnTerminalStarClosure(INonterminalToken token)
        {
            return Repeat.Star(Visit<IExpression>(token[0]));
        }

        public override object OnTerminalPlusClosure(INonterminalToken token)
        {
            return Repeat.Plus(Visit<IExpression>(token[0]));
        }

        public override object OnTerminalOptional(INonterminalToken token)
        {
            return Repeat.Optional(Visit<IExpression>(token[0]));
        }

        public override object OnTerminalDiff(INonterminalToken token)
        {
            return new Difference(Visit<IExpression>(token[0]), Visit<IExpression>(token[1]));
        }

        public override object OnAny(ITerminalToken token)
        {
            return new Any();
        }

        public override object OnCharacterRange(INonterminalToken token)
        {
            return new Tree.Range(Visit<IExpression>(token[0]), Visit<IExpression>(token[1]));
        }

        public override object OnTerminalRangeLoop(INonterminalToken token)
        {
            var expression = Visit<IExpression>(token[0]);

            var range = token.Nonterminal(1).Children;

            var x1 = Visit<Integer>(range[0]);

            var rest = ((INonterminalToken) range[1]).Children;

            if (rest.Count == 0)
            {
                return Repeat.From(expression, x1.Value, x1.Value);
            }

            var x2 = Visit<Integer>(rest[0]);

            return Repeat.From(expression, x1.Value, x2.Value);
        }

        public override object OnNumber(ITerminalToken token)
        {
            return new Integer(token.Value);
        }

        public override object OnSubRule(INonterminalToken token)
        {
            return new SubRule(Visit<Name>(token[0]), Visit<IExpression>(token[1]));
        }

        public override object OnTerminalNot(INonterminalToken token)
        {
            return new Not(Visit<IExpression>(token[0]));
        }

        public override object OnRange(INonterminalToken token)
        {
            throw new NotSupportedException();
        }

    }
}
