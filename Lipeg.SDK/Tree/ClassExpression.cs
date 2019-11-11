using Lipeg.Runtime;
using System.Collections.Generic;
using System.Linq;

namespace Lipeg.SDK.Tree
{
    public class ClassExpression : Expression
    {
        private ClassExpression(ILocated located, bool negated, params ClassPartExpression[] parts)
            : base(located)
        {
            Negated = negated;
            Parts = parts;
        }

        public IReadOnlyList<ClassPartExpression> Parts { get; }
        public bool Negated { get; }

        public static ClassExpression From(ILocated located, bool negated, params ClassPartExpression[] parts)
        {
            return new ClassExpression(located, negated,  parts);
        }
    }
}
