using Lipeg.Runtime;

namespace Lipeg.SDK.Tree
{
    public class ChoiceExpression : Expression
    {
        private ChoiceExpression(ILocated located, IPlusList<Expression> choices)
            : base(located)
        {
            Choices = choices;
        }

        public IPlusList<Expression> Choices { get; }

        public static ChoiceExpression From(ILocated located, IPlusList<Expression> choices)
        {
            return new ChoiceExpression(located, choices);
        }
    }
}
