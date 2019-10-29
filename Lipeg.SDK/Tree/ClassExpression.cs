using System.Collections.Generic;
using System.Linq;

namespace Lipeg.SDK.Tree
{
    public class ClassExpression : Expression
    {
        public ClassExpression(bool negated, params CharExpression[] ranges)
        {
            Negated = negated;
            Ranges = ranges;
        }

        public IReadOnlyList<CharExpression> Ranges { get; }
        public bool Negated { get; }

        public static ClassExpression From(bool negated, params CharExpression[] ranges)
        {
            return new ClassExpression(negated,  ranges);
        }
    }
}
