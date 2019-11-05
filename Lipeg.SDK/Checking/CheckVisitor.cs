using Lipeg.Runtime;
using Lipeg.SDK.Tree;
using System.Diagnostics;

namespace Lipeg.SDK.Checking
{
    internal abstract class CheckVisitor
    {
        public CheckVisitor(Semantic semantic)
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
            foreach (var rule in Grammar.Rules)
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

        protected void VisitExpression(Expression expression)
        {
            switch (expression)
            {
                case AndExpression andExpression:
                    VisitAndExpression(andExpression);
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
                case ClassExpression classExpression:
                    VisitClassExpression(classExpression);
                    break;
                case LabeledExpression labeledExpression:
                    VisitLabeledExpression(labeledExpression);
                    break;
                case LiteralExpression literalExpression:
                    VisitLiteralExpression(literalExpression);
                    break;
                case NameExpression nameExpression:
                    VisitNameExpression(nameExpression);
                    break;
                case NotExpression notExpression:
                    VisitNotExpression(notExpression);
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
            }
        }

        protected virtual void VisitAndExpression(AndExpression expression)
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

        protected virtual void VisitClassExpression(ClassExpression expression)
        {
        }

        protected virtual void VisitLabeledExpression(LabeledExpression expression)
        {
            VisitExpression(expression.Expression);
        }

        protected virtual void VisitLiteralExpression(LiteralExpression expression)
        {
        }

        protected virtual void VisitNameExpression(NameExpression expression)
        {
        }

        protected virtual void VisitNotExpression(NotExpression expression)
        {
            VisitExpression(expression.Expression);
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
