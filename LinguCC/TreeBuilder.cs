using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using Lingu.Grammars;
using Lingu.Runtime.Structures;
using Lingu.Tree;

namespace Lingu.CC
{
    public class TreeBuilder : LinguVisitor<object>
    {
        protected override object DefaultOn(IToken token) => throw new NotImplementedException();

        public RawGrammar Visit(INonterminalToken root)
        {
            return Visit<RawGrammar>(root);
        }

        protected override object OnFile(INonterminalToken token)
        {
            return Visit<RawGrammar>(token[0]);
        }

        protected override object OnGrammar(INonterminalToken token)
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

        protected override object OnGrammarOptions(INonterminalToken token)
        {
            return token.Nonterminal(0).Children.Select(Visit<Option>).ToArray();
        }

        protected override object OnOption(INonterminalToken token)
        {
            return new Option(token.Terminal(0).Value, token.Terminal(1).Value);
        }

        protected override object OnGrammarRules(INonterminalToken token)
        {
            return token.Nonterminal(0).Children.Select(Visit<NonterminalRule>).ToArray();
        }

        protected override object OnRule(INonterminalToken token)
        {
            return NonterminalRule.From(token.Terminal(0).Value, false, Visit<IExpression>(token[1]));
        }

        protected override object OnRuleExpression(INonterminalToken token)
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

        protected override object OnRuleSequence(INonterminalToken token)
        {
            var children = token.Nonterminal(0).Children;
            var expressions = children.Select(Visit<IExpression>).ToArray();
            if (expressions.Length > 1)
            {
                return new Sequence(expressions);
            }

            return expressions[0];
        }

        protected override object OnIdentifier(ITerminalToken token)
        {
            return new Name(token.Value);
        }

        protected override object OnRuleDropElement(INonterminalToken token)
        {
            return new Drop(Visit<IExpression>(token[0]));
        }

        protected override object OnRulePromoteElement(INonterminalToken token)
        {
            return new Promote(Visit<IExpression>(token[0]));
        }

        protected override object OnText(ITerminalToken token)
        {
            return new Tree.String(token.Value);
        }

        protected override object OnRuleStar(INonterminalToken token)
        {
            return Repeat.Star(Visit<IExpression>(token[0]));
        }

        protected override object OnRulePlus(INonterminalToken token)
        {
            return Repeat.Plus(Visit<IExpression>(token[0]));
        }

        protected override object OnRuleOption(INonterminalToken token)
        {
            Debug.Assert(token.Count == 1);
            return Repeat.Optional(Visit<IExpression>(token[0]));
        }

        protected override object OnGrammarTerminals(INonterminalToken token)
        {
            return token.Nonterminal(0).Children.Select(Visit<TerminalRule>).ToArray();
        }

        protected override object OnTerminalRule(INonterminalToken token)
        {
            return TerminalRule.From(token.Terminal(0).Value, Visit<IExpression>(token[1]));
        }

        protected override object OnTerminalExpression(INonterminalToken token)
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

        protected override object OnTerminalSequence(INonterminalToken token)
        {
            var children = token.Nonterminal(0).Children;
            var expressions = children.Select(Visit<IExpression>).ToArray();
            if (expressions.Length > 1)
            {
                return new Sequence(expressions);
            }

            return expressions[0];
        }

        protected override object OnUcCodepoint(ITerminalToken token)
        {
            return new UcCodepoint(token.Value);
        }

        protected override object OnUcBlock(ITerminalToken token)
        {
            return new UcBlock(token.Value);
        }

        protected override object OnUcCategory(ITerminalToken token)
        {
            return new UcCategory(token.Value);
        }

        protected override object OnTerminalStar(INonterminalToken token)
        {
            return Repeat.Star(Visit<IExpression>(token[0]));
        }

        protected override object OnTerminalPlus(INonterminalToken token)
        {
            return Repeat.Plus(Visit<IExpression>(token[0]));
        }

        protected override object OnTerminalOption(INonterminalToken token)
        {
            return Repeat.Optional(Visit<IExpression>(token[0]));
        }

        protected override object OnTerminalDiff(INonterminalToken token)
        {
            return new Difference(Visit<IExpression>(token[0]), Visit<IExpression>(token[1]));
        }

        protected override object OnAny(ITerminalToken token)
        {
            return new Any();
        }

        protected override object OnCharacterRange(INonterminalToken token)
        {
            return new Tree.Range(Visit<IExpression>(token[0]), Visit<IExpression>(token[1]));
        }

        protected override object OnTerminalRangeLoop(INonterminalToken token)
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

        protected override object OnNumber(ITerminalToken token)
        {
            return new Integer(token.Value);
        }

        protected override object OnSubRule(INonterminalToken token)
        {
            return new SubRule(Visit<Name>(token[0]), Visit<IExpression>(token[1]));
        }

        protected override object OnTerminalNot(INonterminalToken token)
        {
            return new Not(Visit<IExpression>(token[0]));
        }

        protected override object OnRange(INonterminalToken token)
        {
            throw new NotSupportedException();
        }

    }
}
