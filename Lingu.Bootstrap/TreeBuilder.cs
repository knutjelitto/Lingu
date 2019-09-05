using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using Hime.Redist;

using Lingu.Tree;

namespace Lingu.Bootstrap
{
    public class TreeBuilder : LinguVisitor
    {
        public TreeBuilder()
        {
        }

        private ReferenceKind CurrentContext { get; set; } = ReferenceKind.Illegal;

        private Grammar Grammar { get; set; }

        public Grammar Visit(ASTNode node)
        {
            VisitNode<Grammar>(node);

            Grammar.Resolve();

            return Grammar;
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

        protected IEnumerable<T> VisitChildren<T>(ASTNode node, int skip)
        {
            return node.Children.Skip(skip).Select(VisitNode<T>);
        }

        protected override object OnVariableFile(ASTNode node)
        {
            Debug.Assert(node.Children.Count == 1);

            return VisitChild<Grammar>(node, 0);
        }

        protected override object OnVariableCfGrammar(ASTNode node)
        {
            var name =  VisitChild<AtomName>(node, 0);

            Grammar = new Grammar(name);

            if (node.Children[1].SymbolType == SymbolType.Variable && node.Children[1].Symbol.ID == LinguParser.ID.VariableGrammarOptions)
            {
                CurrentContext = ReferenceKind.Illegal;
                VisitChild<Options>(node, 1);
            }

            CurrentContext = ReferenceKind.Terminal;
            VisitChild<Terminals>(node, 2);

            CurrentContext = ReferenceKind.TerminalOrRule;
            VisitChild<Rules>(node, 3);

            return null;
        }

        protected override object OnVariableGrammarOptions(ASTNode node)
        {
            Grammar.Options.AddRange(VisitChildren<Option>(node));
            return null;
        }

        protected override object OnVariableOption(ASTNode node)
        {
            return new Option(VisitChild<AtomName>(node, 0), VisitChild<AtomText>(node, 1));
        }

        protected override object OnVariableGrammarTerminals(ASTNode node)
        {
            Grammar.Terminals.AddRange(VisitChildren<TerminalDefinition>(node));
            return null;
        }

        protected override object OnVariableTerminalRule(ASTNode node)
        {
            return new TerminalDefinition(VisitChild<AtomName>(node, 0), VisitChild<Expression>(node, 1));
        }

        protected override object OnVariableTerminalExpression(ASTNode node)
        {
            if (node.Children.Count == 1)
            {
                return VisitChild<Expression>(node, 0);

            }
            return new Alternates(VisitChildren<Expression>(node));
        }

        protected override object OnVariableTerminalDifference(ASTNode node)
        {
            if (node.Children.Count == 1)
            {
                return VisitChild<Expression>(node, 0);

            }
            return new Difference(VisitChildren<Expression>(node));
        }

        protected override object OnVariableTerminalSequence(ASTNode node)
        {
            if (node.Children.Count == 1)
            {
                return VisitChild<Expression>(node, 0);

            }
            return new Sequence(VisitChildren<Expression>(node));
        }

        protected override object OnVariableTerminalRepetition(ASTNode node)
        {
            var expression = VisitChild<Expression>(node, 0);
            if (node.Children.Count == 1)
            {
                return expression;
            }
            if (node.Children.Count == 2)
            {

                var rep = node.Children[1];

                switch (rep.Value)
                {
                    case "?": return new Repetition(expression, 0, 1);
                    case "*": return new Repetition(expression, 0);
                    case "+": return new Repetition(expression, 1);
                    case null:
                    {
                        if (rep.Symbol.ID == LinguParser.ID.VirtualRange)
                        {
                            var int1 = VisitChild<AtomInteger>(rep, 0);
                            if (rep.Children.Count == 1)
                            {
                                // exactly
                                return new Repetition(expression, int1.Value, int1.Value);
                            }
                            if (rep.Children.Count == 2)
                            {
                                // from .. to
                                var int2 = VisitChild<AtomInteger>(rep, 1);

                                return new Repetition(expression, int1.Value, int2.Value);
                            }
                        }
                        break;
                    }
                }
            }

            throw new ArgumentOutOfRangeException(nameof(node));
        }

        protected override object OnVariableTerminalNot(ASTNode node)
        {
            return new Not(VisitChild<Expression>(node, 0));
        }

        protected override object OnVariableText(ASTNode node)
        {
            return VisitChild<Expression>(node, 0);
        }

        protected override object OnTerminalUnicodeCodepoint(ASTNode node)
        {
            Debug.Assert(!string.IsNullOrWhiteSpace(node.Value));

            return new AtomCodepoint(node.Value);
        }

        protected override object OnTerminalUnicodeBlock(ASTNode node)
        {
            Debug.Assert(!string.IsNullOrWhiteSpace(node.Value));

            return new AtomBlock(node.Value);
        }

        protected override object OnTerminalUnicodeCategory(ASTNode node)
        {
            Debug.Assert(!string.IsNullOrWhiteSpace(node.Value));

            return new AtomCategory(node.Value);
        }

        protected override object OnVariableRange(ASTNode node)
        {
            return new AtomRange(
                VisitChild<Expression>(node, 0),
                VisitChild<Expression>(node, 1));
        }

        protected override object OnTerminalLiteralText(ASTNode node)
        {
            Debug.Assert(!string.IsNullOrWhiteSpace(node.Value));

            var text = new AtomText(node.Value);

            if (CurrentContext == ReferenceKind.TerminalOrRule)
            {
                foreach (var t in Grammar.Terminals)
                {
                    if (t.IsGenerated && t.Expression.Equals(text))
                    {
                        return NewReference(t.Name, ReferenceKind.Terminal);
                    }
                }

                return NewReference(Grammar.GenTerminal(text).Name, ReferenceKind.Terminal);
            }

            return text;
        }

        protected override object OnTerminalLiteralAny(ASTNode node)
        {
            return new AtomAny();
        }

        protected override object OnVariableCharacter(ASTNode node)
        {
            return VisitChild<Expression>(node, 0);
        }

        protected override object OnTerminalName(ASTNode node)
        {
            Debug.Assert(!string.IsNullOrWhiteSpace(node.Value));

            return new AtomName(node.Value);
        }

        protected override object OnTerminalInteger(ASTNode node)
        {
            Debug.Assert(!string.IsNullOrWhiteSpace(node.Value));

            return new AtomInteger(node.Value);
        }

        protected override object OnVariableGrammarRules(ASTNode node)
        {
            Grammar.Rules.AddRange(VisitChildren<RuleDefinition>(node));
            return null;
        }

        protected override object OnVariableRule(ASTNode node)
        {
            return new RuleDefinition(VisitChild<AtomName>(node, 0), VisitChild<Expression>(node, 1));
        }

        protected override object OnVariableRuleExpression(ASTNode node)
        {
            if (node.Children.Count == 1)
            {
                return VisitChild<Expression>(node, 0);
            }

            return new Alternates(VisitChildren<Expression>(node));
        }

        protected override object OnVariableRuleSequence(ASTNode node)
        {
            if (node.Children.Count == 1)
            {
                return VisitChild<Expression>(node, 0);
            }

            return new Sequence(VisitChildren<Expression>(node));
        }

        protected override object OnVariableRuleAlternative(ASTNode node)
        {
            if (node.Children.Count == 0)
            {
                return new Epsilon();
            }

            return VisitChild<Expression>(node, 0);
        }

        protected override object OnVariableRuleRepetition(ASTNode node)
        {
            var expression = VisitChild<Expression>(node, 0);
            if (node.Children.Count == 1)
            {
                return expression;
            }
            if (node.Children.Count == 2)
            {
                switch (node.Children[1].Value)
                {
                    case "?": return new Repetition(expression, 0, 1);
                    case "*": return new Repetition(expression, 0);
                    case "+": return new Repetition(expression, 1);
                }
            }

            throw  new NotImplementedException();
        }
 
        protected override object OnVariableRuleSub(ASTNode node)
        {
            var name = VisitChild<AtomName>(node, 0);
            var expr = VisitChild<Expression>(node, 1);
#if true
            var rule = new RuleDefinition(true, name, expr);

            Grammar.Rules.Add(rule);

            return NewReference(name, ReferenceKind.TerminalOrRule);
#else

            return new SubRule(name, expr);
#endif
        }

        protected override object OnVariableRuleTreeAction(ASTNode node)
        {
            var expression = VisitChild<Expression>(node, 0);
            if (node.Children.Count == 1)
            {
                return expression;
            }
            if (node.Children.Count == 2)
            {
                switch (node.Children[1].Value)
                {
                    case "^":
                        return new Tree.TreeAction(expression, Tree.TreeAction.TreeActionX.Promote);
                    case "!":
                        return new Tree.TreeAction(expression, Tree.TreeAction.TreeActionX.Drop);
                }
            }

            throw new NotImplementedException();
        }

        protected override object OnVariableReference(ASTNode node)
        {
            if (CurrentContext != ReferenceKind.Illegal)
            {
                var name = VisitChild<AtomName>(node, 0);

                return NewReference(name, CurrentContext);
            }

            throw new NotImplementedException();
        }

        // #####################################################################

        private Reference NewReference(AtomName name, ReferenceKind kind)
        {
            var reference = new Reference(name, kind);

            Grammar.References.Add(reference);

            return reference;
        }

        // #####################################################################

        protected override object OnTerminalSeparator(ASTNode node)
        {
            throw new NotImplementedException();
        }

        protected override object OnVariableRuleAction(ASTNode node)
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
