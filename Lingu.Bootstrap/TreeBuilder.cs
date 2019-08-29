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

        protected override IEnumerable<object> VisitChildren(ASTNode node)
        {
            throw new NotImplementedException();
        }

        protected override IEnumerable<T> VisitChildren<T>(ASTNode node)
        {
            return node.Children.Select(VisitNode<T>);
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
            var rules = VisitChild<Rules>(node, 3);

            return new Grammar(name, options, terminals, rules);
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
            if (node.Children.Count == 2)
            {

                var rep = node.Children[1];

                switch (rep.Value)
                {
                    case "?": return new TerminalRepetition(expression, 0, 1);
                    case "*": return new TerminalRepetition(expression, 0);
                    case "+": return new TerminalRepetition(expression, 1);
                    case null:
                    {
                        if (rep.Symbol.ID == LinguParser.ID.VirtualRange)
                        {
                            var int1 = VisitChild<AtomInteger>(rep, 0);
                            if (rep.Children.Count == 1)
                            {
                                // exactly
                                return new TerminalRepetition(expression, int1.Value, int1.Value);
                            }
                            if (rep.Children.Count == 2)
                            {
                                // from .. to
                                var int2 = VisitChild<AtomInteger>(rep, 1);

                                return new TerminalRepetition(expression, int1.Value, int2.Value);
                            }
                        }
                        break;
                    }
                }
            }

            throw new ArgumentOutOfRangeException(nameof(node));
        }

        protected override object OnTerminalUnicodeCodepoint(ASTNode node)
        {
            Debug.Assert(!string.IsNullOrWhiteSpace(node.Value));

            return new TerminalUcCodepoint(node.Value);
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

        protected override object OnVariableTerminalRange(ASTNode node)
        {
            return new AtomUcRange(
                VisitChild<TerminalUcCodepoint>(node, 0),
                VisitChild<TerminalUcCodepoint>(node, 1));
        }

        protected override object OnTerminalLiteralText(ASTNode node)
        {
            Debug.Assert(!string.IsNullOrWhiteSpace(node.Value));

            return new LitText(node.Value);
        }

        protected override object OnTerminalLiteralString(ASTNode node)
        {
            Debug.Assert(!string.IsNullOrWhiteSpace(node.Value));

            return new LitString(node.Value);
        }

        protected override object OnVariableTerminalText(ASTNode node)
        {
            return new TerminalText(VisitChild<LitText>(node, 0));
        }

        protected override object OnTerminalLiteralAny(ASTNode node)
        {
            return new AtomAny();
        }

        protected override Object OnTerminalLiteralClass(ASTNode node)
        {
            Debug.Assert(!string.IsNullOrWhiteSpace(node.Value));

            return new AtomClass(node.Value);
        }

        protected override object OnTerminalName(ASTNode node)
        {
            Debug.Assert(!string.IsNullOrWhiteSpace(node.Value));

            return new AtomName(node.Value);
        }

        protected override Object OnTerminalInteger(ASTNode node)
        {
            Debug.Assert(!string.IsNullOrWhiteSpace(node.Value));

            return new AtomInteger(node.Value);
        }

        protected override Object OnVariableGrammarRules(ASTNode node)
        {
            return new Rules(VisitChildren<RuleItem>(node));
        }

        protected override Object OnVariableRuleSimple(ASTNode node)
        {
            return new RuleSimple(
                VisitChild<AtomName>(node, 0), 
                VisitChild<RuleExpression>(node, 1));
        }

        protected override Object OnVariableRuleTemplate(ASTNode node)
        {
            return new RuleTemplate(
                VisitChild<AtomName>(node, 0),
                VisitChild<RuleTemplateParams>(node, 1),
                VisitChild<RuleExpression>(node, 2));
        }

        protected override Object OnVariableRuleParams(ASTNode node)
        {
            return new RuleTemplateParams(VisitChildren<AtomName>(node));
        }

        protected override Object OnVariableRuleDefinition(ASTNode node)
        {
            if (node.Children.Count == 1)
            {
                return VisitChild<RuleExpression>(node, 0);
            }

            return new RuleDefinition(VisitChildren<RuleExpression>(node));
        }

        protected override Object OnVariableRuleAlternative(ASTNode node)
        {
            if (node.Children.Count == 0)
            {
                return new RuleEpsilon();
            }

            return VisitChild<RuleExpression>(node, 0);
        }

        protected override Object OnVariableRuleSequence(ASTNode node)
        {
            if (node.Children.Count == 1)
            {
                return VisitChild<RuleExpression>(node, 0);
            }

            return new RuleAlternative(VisitChildren<RuleExpression>(node));
        }

        protected override Object OnVariableRuleRepetition(ASTNode node)
        {
            var expression = VisitChild<RuleExpression>(node, 0);
            if (node.Children.Count == 1)
            {
                return expression;
            }
            if (node.Children.Count == 2)
            {
                switch (node.Children[1].Value)
                {
                    case "?": return new RuleRepetition(expression, 0, 1);
                    case "*": return new RuleRepetition(expression, 0);
                    case "+": return new RuleRepetition(expression, 1);

                }
            }

            throw  new NotImplementedException();
        }

        protected override object OnVariableRuleTreeAction(ASTNode node)
        {
            var expression = VisitChild<RuleExpression>(node, 0);
            if (node.Children.Count == 1)
            {
                return expression;
            }
            if (node.Children.Count == 2)
            {
                switch (node.Children[1].Value)
                {
                    case "^":
                        return new RuleTreeAction(expression, RuleTreeAction.TreeAction.Promote);
                    case "!":
                        return new RuleTreeAction(expression, RuleTreeAction.TreeAction.Drop);
                }
            }

            throw new NotImplementedException();
        }

        protected override object OnVariableRuleRef(ASTNode node)
        {
            return new RuleRef(VisitChild<AtomName>(node, 0));
        }

        protected override object OnVariableRuleText(ASTNode node)
        {
            return new RuleText(VisitChild<LitText>(node, 0));
        }

        protected override object OnVariableRuleVirtual(ASTNode node)
        {
            return new RuleVirtual(VisitChild<LitString>(node, 0));
        }

        // #####################################################################

        protected override object OnTerminalSeparator(ASTNode node)
        {
            throw new NotImplementedException();
        }

        protected override object OnVariableRule(ASTNode node)
        {
            throw new NotImplementedException();
        }

        protected override object OnVariableRuleAction(ASTNode node)
        {
            throw new NotImplementedException();
        }

        protected override object OnVariableRuleArguments(ASTNode node)
        {
            throw new NotImplementedException();
        }

        protected override object OnVariableRuleAtom(ASTNode node)
        {
            throw new NotImplementedException();
        }

        protected override object OnVariableRuleCardinality(ASTNode node)
        {
            throw new NotImplementedException();
        }

        protected override object OnVariableRuleContext(ASTNode node)
        {
            throw new NotImplementedException();
        }

        protected override object OnVariableRuleElement(ASTNode node)
        {
            throw new NotImplementedException();
        }

        protected override object OnVariableRuleRefTemplate(ASTNode node)
        {
            throw new NotImplementedException();
        }

        protected override object OnVariableTerminalContext(ASTNode node)
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

        protected override object OnVariableRuleSub(ASTNode node)
        {
            throw new NotImplementedException();
        }

        protected override object OnVirtualRange(ASTNode node)
        {
            throw new NotImplementedException();
        }
    }
}
