using System.Collections.Generic;
using System.Linq;

namespace Lipeg.SDK.Tree
{
    public class CharacterClassExpression : Expression
    {
        public CharacterClassExpression(bool negated, params Expression[] ranges)
        {
            Negated = negated;
            Ranges = ranges;
        }

        public IReadOnlyList<Expression> Ranges { get; }
        public bool Negated { get; }

        public static CharacterClassExpression From(bool negated, params Expression[] ranges)
        {
            return new CharacterClassExpression(negated,  ranges);
        }
    }
}
