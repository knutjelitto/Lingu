using System;
using System.Collections.Generic;
using System.Text;

namespace Lipeg.Boot.Tree
{
    public class ChoiceExpression : Expression
    {
        private ChoiceExpression(IEnumerable<Expression> choices)
        {
            Choices = choices;
        }
        public IEnumerable<Expression> Choices { get; }

        public static ChoiceExpression From(IEnumerable<Expression> choices)
        {
            return new ChoiceExpression(choices);
        }
    }
}
