using System.Collections.Generic;
using System.Linq;

namespace Lingu.Tree
{
    public class RuleAlternative : RuleExpression
    {
        public RuleAlternative(IEnumerable<RuleExpression> expressions)
        {
            Expressions = expressions.ToList();
        }

        public IReadOnlyList<RuleExpression> Expressions { get; }
    }
}
