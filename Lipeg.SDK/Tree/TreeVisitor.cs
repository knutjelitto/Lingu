using Lipeg.Runtime;
using Lipeg.SDK.Checkers;

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
            VisitGrammarSyntaxRules();
            VisitGrammarLexicalRules();
        }

        protected virtual void VisitGrammarSyntaxRules()
        {
            foreach (var rule in Grammar.SyntaxRules)
            {
                VisitRule(rule);
            }
        }

        protected virtual void VisitGrammarLexicalRules()
        {
            foreach (var rule in Grammar.LexicalRules)
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

        public virtual void VisitExpression(Expression expression)
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
                case ClassCharExpression character:
                    VisitClassCharExpression(character);
                    break;
                case ClassRangeExpression characterRange:
                    VisitClassRangeExpression(characterRange);
                    break;
                case ChoiceExpression choiceExpression:
                    VisitChoiceExpression(choiceExpression);
                    break;
                case ClassExpression classExpression:
                    VisitClassExpression(classExpression);
                    break;
                case NameExpression nameExpression:
                    VisitNameExpression(nameExpression);
                    break;
                case SequenceExpression sequenceExpression:
                    VisitSequenceExpression(sequenceExpression);
                    break;
                case StringLiteralExpression stringLiteral:
                    VisitStringLiteralExpression(stringLiteral);
                    break;
                case AnyExpression anyExpression:
                    VisitAnyExpression(anyExpression);
                    break;
                case AliasExpression aliasExpression:
                    VisitAliasExpression(aliasExpression);
                    break;
                case OptionalExpression optionalExpression:
                    VisitOptionalExpression(optionalExpression);
                    break;
                case PlusExpression plusExpression:
                    VisitPlusExpression(plusExpression);
                    break;
                case StarExpression starExpression:
                    VisitStarExpression(starExpression);
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

        protected virtual void VisitClassCharExpression(ClassCharExpression expression)
        {
        }

        protected virtual void VisitClassRangeExpression(ClassRangeExpression expression)
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
            foreach (var choice in expression.Choices)
            {
                VisitExpression(choice);
            }
        }

        protected virtual void VisitNameExpression(NameExpression expression)
        {
        }

        protected virtual void VisitSequenceExpression(SequenceExpression expression)
        {
            foreach (var element in expression.Sequence)
            {
                VisitExpression(element);
            }
        }

        protected virtual void VisitStringLiteralExpression(StringLiteralExpression expression)
        {
        }

        protected virtual void VisitAnyExpression(AnyExpression expression)
        {
        }

        protected virtual void VisitAliasExpression(AliasExpression expression)
        {
            VisitExpression(expression.Expression);
        }

        protected virtual void VisitRule(Rule rule)
        {
            VisitExpression(rule.Expression);
        }

        protected virtual void VisitOption(Option option)
        {
        }

        protected virtual void VisitOptionalExpression(OptionalExpression expression)
        {
            VisitExpression(expression.Expression);
        }

        protected virtual void VisitStarExpression(StarExpression expression)
        {
            VisitExpression(expression.Expression);
        }

        protected virtual void VisitPlusExpression(PlusExpression expression)
        {
            VisitExpression(expression.Expression);
        }
    }
}
