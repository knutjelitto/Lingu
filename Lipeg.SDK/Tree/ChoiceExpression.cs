using System.Collections.Generic;
using System.Linq;
using Lipeg.Runtime;

namespace Lipeg.SDK.Tree
{
    public class ChoiceExpression : Expression
    {
        private ChoiceExpression(ILocated located, IList<Expression> choices)
            : base(located)
        {
            Choices = choices;
        }

        public IList<Expression> Choices { get; }

        public static ChoiceExpression From(ILocated located, IEnumerable<Expression> choices)
        {
            return new ChoiceExpression(located, choices.ToList());
        }
    }
}
