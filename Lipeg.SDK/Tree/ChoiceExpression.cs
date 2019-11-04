using Lipeg.Runtime;

namespace Lipeg.SDK.Tree
{
    public class ChoiceExpression : Expression
    {
        private ChoiceExpression(IPlusList<Expression> choices)
        {
            Choices = choices;
        }

        public IPlusList<Expression> Choices { get; }

        public static ChoiceExpression From(IPlusList<Expression> choices)
        {
            return new ChoiceExpression(choices);
        }
    }
}
