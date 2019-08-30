using System.Collections.Generic;
using System.Linq;

namespace Lingu.Tree
{
    public class RuleSequence : RuleExpression
    {

        public RuleSequence(IEnumerable<RuleExpression> expressions)
        {
            Expressions = expressions.ToArray();
        }

        public IReadOnlyList<RuleExpression> Expressions { get; }
    }
}
