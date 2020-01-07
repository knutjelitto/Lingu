using Lipeg.Runtime;
using System.Collections.Generic;
using System.Linq;

namespace Lipeg.SDK.Tree
{
    public class ClassExpression : Expression
    {
        private ClassExpression(ILocated located, bool negated, IReadOnlyList<ClassPartExpression> choices)
            : base(located)
        {
            Negated = negated;
            Choices = choices;
        }

        public IReadOnlyList<ClassPartExpression> Choices { get; }
        public bool Negated { get; }

        public static ClassExpression From(ILocated located, bool negated, IEnumerable<ClassPartExpression> parts)
        {
            return new ClassExpression(located, negated,  parts.ToList());
        }
    }
}
