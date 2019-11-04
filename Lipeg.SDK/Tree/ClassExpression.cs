using System.Collections.Generic;
using System.Linq;

namespace Lipeg.SDK.Tree
{
    public class ClassExpression : Expression
    {
        public ClassExpression(bool negated, params Expression[] ranges)
        {
            Negated = negated;
            Ranges = ranges;
        }

        public IReadOnlyList<Expression> Ranges { get; }
        public bool Negated { get; }

        public static ClassExpression From(bool negated, params Expression[] ranges)
        {
            return new ClassExpression(negated,  ranges);
        }
    }
}
