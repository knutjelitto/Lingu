﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using Hime.Redist;
using Lingu.Bootstrap.Hime;
using Lingu.Grammars;
using Lingu.Tree;

namespace Lingu.Bootstrap
{
    public class TreeBuilder : LinguVisitor
    {
        public RawGrammar Visit(ASTNode node)
        {
            return VisitNode<RawGrammar>(node);
        }

        private T VisitChild<T>(ASTNode node, int child)
        {
            return VisitNode<T>(node.Children[child]);
        }

        protected override IEnumerable<object> VisitChildren(ASTNode node)
        {
            throw new NotImplementedException();
        }

        protected override IEnumerable<T> VisitChildren<T>(ASTNode node)
        {
            return node.Children.Select(VisitNode<T>);
        }

        // #####################################################################

        protected override object OnVariableFile(ASTNode node)
        {
            Debug.Assert(node.Children.Count == 1);

            return VisitChild<RawGrammar>(node, 0);
        }

        protected override object OnVariableCfGrammar(ASTNode node)
        {
            var name =  VisitChild<Name>(node, 0);

            var grammar = new RawGrammar(name.Text);

            foreach (var subNode in node.Children.Skip(1))
            {
                if (subNode.Symbol.ID == LinguParser.ID.VariableGrammarOptions)
                {
                    grammar.Options.AddRange(VisitChildren<Option>(subNode));
                }

                if (subNode.Symbol.ID == LinguParser.ID.VariableGrammarTerminals)
                {
                    grammar.Terminals.AddRange(VisitChildren<RawTerminal>(subNode));
                }

                if (subNode.Symbol.ID == LinguParser.ID.VariableGrammarRules)
                {
                    grammar.Nonterminals.AddRange(VisitChildren<RawNonterminal>(subNode));
                }
            }

            return grammar; 
        }

        protected override object OnVariableOption(ASTNode node)
        {
            return new Option(VisitChild<Name>(node, 0).Text, VisitChild<Name>(node, 1).Text);
        }

        protected override object OnVariableTerminalRule(ASTNode node)
        {
            return new RawTerminal(VisitChild<Name>(node, 0).Text, VisitChild<IExpression>(node, 1));
        }

        protected override object OnVariableTerminalExpression(ASTNode node)
        {
            if (node.Children.Count == 1)
            {
                return VisitChild<IExpression>(node, 0);

            }
            return new Alternates(VisitChildren<IExpression>(node));
        }

        protected override object OnVariableTerminalDifference(ASTNode node)
        {
            if (node.Children.Count == 1)
            {
                return VisitChild<IExpression>(node, 0);

            }
            return new Difference(VisitChildren<IExpression>(node));
        }

        protected override object OnVariableTerminalSequence(ASTNode node)
        {
            if (node.Children.Count == 1)
            {
                return VisitChild<IExpression>(node, 0);
            }

            return new Sequence(VisitChildren<IExpression>(node));
        }

        protected override object OnVariableTerminalRepetition(ASTNode node)
        {
            var expression = VisitChild<IExpression>(node, 0);
            if (node.Children.Count == 1)
            {
                return expression;
            }
            if (node.Children.Count == 2)
            {
                var rep = node.Children[1];

                var repeat = new Repeat(1, 1);

                switch (rep.Value)
                {
                    case "?":
                        repeat = new Repeat(0, 1);
                        break;
                    case "*":
                        repeat = new Repeat(0);
                        break;
                    case "+":
                        repeat = new Repeat(1);
                        break;
                    case null:
                        {
                            if (rep.Symbol.ID == LinguParser.ID.VirtualRange)
                            {
                                var int1 = VisitChild<Integer>(rep, 0);
                                if (rep.Children.Count == 1)
                                {
                                    // exactly
                                    repeat = new Repeat(int1.Value, int1.Value);
                                }
                                if (rep.Children.Count == 2)
                                {
                                    // from .. to
                                    var int2 = VisitChild<Integer>(rep, 1);

                                    repeat = new Repeat(int1.Value, int2.Value);
                                }
                            }
                            break;
                        }
                    default:
                        throw new ArgumentOutOfRangeException(nameof(node));
                }

                expression.Repeat = repeat;
                return expression;
            }

            throw new ArgumentOutOfRangeException(nameof(node));
        }

        protected override object OnVariableTerminalNot(ASTNode node)
        {
            return new Not(VisitChild<IExpression>(node, 0));
        }

        protected override object OnVariableText(ASTNode node)
        {
            return VisitChild<IExpression>(node, 0);
        }

        protected override object OnTerminalUnicodeCodepoint(ASTNode node)
        {
            Debug.Assert(!string.IsNullOrWhiteSpace(node.Value));

            return new UcCodepoint(node.Value);
        }

        protected override object OnTerminalUnicodeBlock(ASTNode node)
        {
            Debug.Assert(!string.IsNullOrWhiteSpace(node.Value));

            return new UcBlock(node.Value);
        }

        protected override object OnTerminalUnicodeCategory(ASTNode node)
        {
            Debug.Assert(!string.IsNullOrWhiteSpace(node.Value));

            return new UcCategory(node.Value);
        }

        protected override object OnVariableRange(ASTNode node)
        {
            return new Tree.Range(
                VisitChild<IExpression>(node, 0),
                VisitChild<IExpression>(node, 1));
        }

        protected override object OnTerminalLiteralText(ASTNode node)
        {
            Debug.Assert(!string.IsNullOrWhiteSpace(node.Value));

            return new Tree.String(node.Value);
        }

        protected override object OnTerminalLiteralAny(ASTNode node)
        {
            return new Any();
        }

        protected override object OnVariableCharacter(ASTNode node)
        {
            return VisitChild<IExpression>(node, 0);
        }

        protected override object OnTerminalName(ASTNode node)
        {
            Debug.Assert(!string.IsNullOrWhiteSpace(node.Value));

            return new Name(node.Value);
        }

        protected override object OnTerminalInteger(ASTNode node)
        {
            Debug.Assert(!string.IsNullOrWhiteSpace(node.Value));

            return new Integer(node.Value);
        }

        protected override object OnVariableRule(ASTNode node)
        {
            var name = VisitChild<Name>(node, 0);
            var expression = VisitChild<IExpression>(node, 1);
            var rule = new RawNonterminal(name.Text, expression);

            return rule;
        }

        protected override object OnVariableRuleExpression(ASTNode node)
        {
            if (node.Children.Count == 1)
            {
                return VisitChild<IExpression>(node, 0);
            }

            return new Alternates(VisitChildren<IExpression>(node));
        }

        protected override object OnVariableRuleSequence(ASTNode node)
        {
            if (node.Children.Count == 1)
            {
                return VisitChild<IExpression>(node, 0);
            }

            return new Sequence(VisitChildren<IExpression>(node));
        }

        protected override object OnVariableRuleAlternative(ASTNode node)
        {
            if (node.Children.Count == 0)
            {
                return new Epsilon();
            }

            return VisitChild<IExpression>(node, 0);
        }

        protected override object OnVariableRuleRepetition(ASTNode node)
        {
            var expression = VisitChild<IExpression>(node, 0);
            if (node.Children.Count == 1)
            {
                return expression;
            }
            if (node.Children.Count == 2)
            {
                var rep = node.Children[1];

                var repeat = new Repeat(1, 1);

                switch (rep.Value)
                {
                    case "?":
                        repeat = new Repeat(0, 1);
                        break;
                    case "*":
                        repeat = new Repeat(0);
                        break;
                    case "+":
                        repeat = new Repeat(1);
                        break;
                }

                expression.Repeat = repeat;
            }

            throw new NotImplementedException();
        }

        protected override object OnVariableRuleSub(ASTNode node)
        {
            var name = VisitChild<Name>(node, 0);
            var expr = VisitChild<IExpression>(node, 1);

            return new SubRule(name, expr);
        }

        protected override object OnVariableRuleTreeAction(ASTNode node)
        {
            if (node.Children.Count == 1)
            {
                return VisitChild<IExpression>(node, 0);
            }
            if (node.Children.Count == 2)
            {
                var expression = VisitChild<IExpression>(node, 1);

                switch (node.Children[0].Value)
                {
                    case "^":
                        expression.Action = TreeActionKind.Promote;
                        break;
                    case ",":
                        expression.Action = TreeActionKind.Drop;
                        break;
                }
                return expression;
            }

            throw new NotImplementedException();
        }

        protected override object OnVariableReference(ASTNode node)
        {
            return VisitChild<Name>(node, 0);
        }

        // #####################################################################
        // #####################################################################

        protected override object OnVariableGrammarOptions(ASTNode node)
        {
            throw new NotImplementedException();
        }

        protected override object OnVariableGrammarTerminals(ASTNode node)
        {
            throw new NotImplementedException();
        }

        protected override object OnVariableGrammarRules(ASTNode node)
        {
            throw new NotImplementedException();
        }

        protected override object OnTerminalSeparator(ASTNode node)
        {
            throw new NotImplementedException();
        }

        protected override object OnVariableRuleAtom(ASTNode node)
        {
            throw new NotImplementedException();
        }

        protected override object OnVariableRuleElement(ASTNode node)
        {
            throw new NotImplementedException();
        }

        protected override object OnVariableTerminalElement(ASTNode node)
        {
            throw new NotImplementedException();
        }

        protected override object OnVariableTerminalAtom(ASTNode node)
        {
            throw new NotImplementedException();
        }

        protected override object OnVariableTerminalCardinalilty(ASTNode node)
        {
            throw new NotImplementedException();
        }

        protected override object OnVirtualRange(ASTNode node)
        {
            throw new NotImplementedException();
        }
    }
}
