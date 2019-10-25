using System;
using System.Collections.Generic;
using System.Text;

namespace Lipeg.SDK.Tree
{
    public class ChoiceExpression : Expression
    {
        private ChoiceExpression(IReadOnlyList<Expression> choices)
        {
            Choices = choices;
        }

        public IReadOnlyList<Expression> Choices { get; }

        public static ChoiceExpression From(IReadOnlyList<Expression> choices)
        {
            return new ChoiceExpression(choices);
        }
    }
}
