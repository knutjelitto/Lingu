using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using Hime.Redist;

using Lingu.Bootstrap.Tree;

namespace Lingu.Bootstrap
{
#if true
    public class TreeBuilder : LinguVisitor
    {
        public Grammar Visit(ASTNode node)
        {
            return VisitNode<Grammar>(node);
        }

        private T VisitChild<T>(ASTNode node, int child)
        {
            return VisitNode<T>(node.Children[child]);
        }

        private LitString LitString(ASTNode node, int child)
        {
            Debug.Assert(child < node.Children.Count);
            Debug.Assert(node.Children[child].SymbolType == SymbolType.Terminal);
            Debug.Assert(node.Children[child].Symbol.ID == LinguLexer.ID.TerminalLiteralString);
            return new LitString(node.Children[child].Value);
        }

        private LitString LitInteger(ASTNode node, int child)
        {
            Debug.Assert(child < node.Children.Count);
            Debug.Assert(node.Children[child].SymbolType == SymbolType.Terminal);
            Debug.Assert(node.Children[child].Symbol.ID == LinguLexer.ID.TerminalInteger);
            return new LitString(node.Children[child].Value);
        }

        protected override IEnumerable<object> VisitChildren(ASTNode node)
        {
            return base.VisitChildren(node);
        }

        protected override IEnumerable<T> VisitChildren<T>(ASTNode node)
        {
            return node.Children.Select(child => VisitNode<T>(child));
        }

        protected override object OnVariableFile(ASTNode node)
        {
            Debug.Assert(node.Children.Count == 1);

            return VisitChild<Grammar>(node, 0);
        }

        protected override object OnVariableCfGrammar(ASTNode node)
        {
            var name =  VisitChild<AtomName>(node, 0);
            var options = VisitChild<Options>(node, 1);
            var terminals = VisitChild<Terminals>(node, 2);

            return new Grammar(name, options);
        }

        protected override object OnVariableGrammarOptions(ASTNode node)
        {
            return new Options(VisitChildren<Option>(node));
        }

        protected override object OnVariableOption(ASTNode node)
        {
            return new Option(VisitChild<AtomName>(node, 0), LitString(node, 1));
        }

        protected override object OnVariableGrammarTerminals(ASTNode node)
        {
            return new Terminals(VisitChildren<TerminalItem>(node));
        }

        protected override object OnVariableTerminalItem(ASTNode node)
        {
            return base.OnVariableTerminalItem(node);
        }

        protected override object OnVariableTerminalRule(ASTNode node)
        {
            return new TerminalRule(VisitChild<AtomName>(node, 0), VisitChild<TerminalExpression>(node, 1));
        }

        protected override object OnVariableTerminalFragment(ASTNode node)
        {
            return new TerminalFragment(VisitChild<AtomName>(node, 0), VisitChild<TerminalExpression>(node, 1));
        }

        protected override object OnVariableTerminalContext(ASTNode node)
        {
            throw new NotImplementedException();
            return new TerminalContext(VisitChild<AtomName>(node, 0), VisitChildren<TerminalRule>(node));
        }

        protected override object OnVariableTerminalDefinition(ASTNode node)
        {
            if (node.Children.Count == 1)
            {
                return VisitChild<TerminalExpression>(node, 0);

            }
            return new TerminalDefinition(VisitChildren<TerminalExpression>(node));
        }

        protected override object OnVariableTerminalDifference(ASTNode node)
        {
            if (node.Children.Count == 1)
            {
                return VisitChild<TerminalExpression>(node, 0);

            }
            return new TerminalDifference(VisitChildren<TerminalExpression>(node));
        }

        protected override object OnVariableTerminalSequence(ASTNode node)
        {
            if (node.Children.Count == 1)
            {
                return VisitChild<TerminalExpression>(node, 0);

            }
            return new TerminalSequence(VisitChildren<TerminalExpression>(node));
        }

        protected override object OnVariableTerminalRepetition(ASTNode node)
        {
            var expression = VisitChild<TerminalExpression>(node, 0);
            if (node.Children.Count == 1)
            {
                return expression;
            }

            switch (node.Children[1].Value)
            {
                case "?": return new TerminalRepetition(expression, 0, 1);
                case "*": return new TerminalRepetition(expression, 0);
                case "+": return new TerminalRepetition(expression, 1);
                default:
                    throw new NotImplementedException();
            }
        }

        protected override object OnTerminalUnicodeCodepoint(ASTNode node)
        {
            Debug.Assert(!string.IsNullOrWhiteSpace(node.Value));

            return new AtomUcCodepoint(node.Value);
        }

        protected override object OnTerminalUnicodeBlock(ASTNode node)
        {
            Debug.Assert(!string.IsNullOrWhiteSpace(node.Value));

            return new AtomUcBlock(node.Value);
        }

        protected override object OnTerminalUnicodeCategory(ASTNode node)
        {
            Debug.Assert(!string.IsNullOrWhiteSpace(node.Value));

            return new AtomUcCategory(node.Value);
        }

        protected override object OnTerminalLiteralText(ASTNode node)
        {
            return new AtomText(node.Value);
        }

        protected override object OnTerminalLiteralAny(ASTNode node)
        {
            return new AtomAny();
        }

        protected override object OnTerminalName(ASTNode node)
        {
            Debug.Assert(!string.IsNullOrWhiteSpace(node.Value));

            return new AtomName(node.Value);
        }
    }
#endif
}
