using System.Collections.Generic;
using System.Linq;

namespace Lipeg.SDK.Tree
{
    public class ClassExpression : Expression
    {
        public ClassExpression(IReadOnlyList<CharExpression> ranges, bool negated)
        {
            Ranges = ranges.ToList();
            Negated = negated;
        }

        public static ClassExpression From(IReadOnlyList<CharExpression> ranges, bool negated = false)
        {
            return new ClassExpression(ranges, negated);
        }

        public IReadOnlyList<CharExpression> Ranges { get; }
        public bool Negated { get; }
    }
}
