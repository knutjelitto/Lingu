using System.Diagnostics;

using Lipeg.Runtime;
using Lipeg.SDK.Checks;

namespace Lipeg.SDK.Tree
{
    internal abstract class TreeVisitor
    {
        public TreeVisitor(Semantic semantic)
        {
            Semantic = semantic;
        }
        public Semantic Semantic { get; }
        public Grammar Grammar => Semantic.Grammar;
        public ICompileResult Results => Semantic.Results;

        public virtual void VisitGrammar()
        {
            VisitGrammarOptions();
            VisitGrammarRules();
        }

        public virtual void VisitGrammarRules()
        {
            VisitGrammarSyntax();
            VisitGrammarLexical();
        }

        protected virtual void VisitGrammarSyntax()
        {
            foreach (var rule in Grammar.Syntax)
            {
                VisitRule(rule);
            }
        }

        protected virtual void VisitGrammarLexical()
        {
            foreach (var rule in Grammar.Lexical)
            {
                VisitRule(rule);
            }
        }

        public virtual void VisitGrammarOptions()
        {
            foreach (var option in Grammar.Options)
            {
                VisitOption(option);
            }
        }

        protected virtual void VisitExpression(Expression expression)
        {
            switch (expression)
            {
                case AndExpression andExpression:
                    VisitAndExpression(andExpression);
                    break;
                case NotExpression notExpression:
                    VisitNotExpression(notExpression);
                    break;
                case LiftExpression promoteExpression:
                    VisitLiftExpression(promoteExpression);
                    break;
                case DropExpression dropExpression:
                    VisitDropExpression(dropExpression);
                    break;
                case FuseExpression fuseExpression:
                    VisitFuseExpression(fuseExpression);
                    break;
                case CharacterExpression character:
                    VisitCharacter(character);
                    break;
                case CharacterRangeExpression characterRange:
                    VisitCharacterRange(characterRange);
                    break;
                case ChoiceExpression choiceExpression:
                    VisitChoiceExpression(choiceExpression);
                    break;
                case CharacterClassExpression classExpression:
                    VisitCharacterClassExpression(classExpression);
                    break;
                case LiteralExpression literalExpression:
                    VisitLiteralExpression(literalExpression);
                    break;
                case NameExpression nameExpression:
                    VisitNameExpression(nameExpression);
                    break;
                case QuantifiedExpression quantifiedExpression:
                    VisitQuantifiedExpression(quantifiedExpression);
                    break;
                case SequenceExpression sequenceExpression:
                    VisitSequenceExpression(sequenceExpression);
                    break;
                case StringLiteralExpression stringLiteral:
                    VisitStringLiteral(stringLiteral);
                    break;
                case WildcardExpression wildcardExpression:
                    VisitWildcardExpression(wildcardExpression);
                    break;
                default:
                    throw new InternalErrorException($"expression of type '{expression.GetType().Name}' not implemented");
            }
        }

        protected virtual void VisitAndExpression(AndExpression expression)
        {
            VisitExpression(expression.Expression);
        }

        protected virtual void VisitNotExpression(NotExpression expression)
        {
            VisitExpression(expression.Expression);
        }

        protected virtual void VisitLiftExpression(LiftExpression expression)
        {
            VisitExpression(expression.Expression);
        }

        protected virtual void VisitDropExpression(DropExpression expression)
        {
            VisitExpression(expression.Expression);
        }

        protected virtual void VisitFuseExpression(FuseExpression expression)
        {
            VisitExpression(expression.Expression);
        }

        protected virtual void VisitCharacter(CharacterExpression expression)
        {
        }

        protected virtual void VisitCharacterRange(CharacterRangeExpression expression)
        {
        }

        protected virtual void VisitChoiceExpression(ChoiceExpression expression)
        {
            foreach (var choice in expression.Choices)
            {
                VisitExpression(choice);
            }
        }

        protected virtual void VisitCharacterClassExpression(CharacterClassExpression expression)
        {
        }

        protected virtual void VisitLiteralExpression(LiteralExpression expression)
        {
        }

        protected virtual void VisitNameExpression(NameExpression expression)
        {
        }

        protected virtual void VisitQuantifiedExpression(QuantifiedExpression expression)
        {
            VisitExpression(expression.Expression);
        }

        protected virtual void VisitSequenceExpression(SequenceExpression expression)
        {
            foreach (var element in expression.Sequence)
            {
                VisitExpression(element);
            }
        }

        protected virtual void VisitStringLiteral(StringLiteralExpression expression)
        {
        }

        protected virtual void VisitWildcardExpression(WildcardExpression expression)
        {
        }

        protected virtual void VisitRule(Rule rule)
        {
            VisitExpression(rule.Expression);
        }

        protected virtual void VisitOption(Option option)
        {
        }
    }
}
