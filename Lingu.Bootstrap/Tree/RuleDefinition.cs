using System.Collections.Generic;
using System.Linq;

namespace Lingu.Bootstrap.Tree
{
    public class RuleDefinition : RuleExpression
    {
        public RuleDefinition(IEnumerable<RuleExpression> expressions)
        {
            Expressions = expressions.ToList();
        }

        public IReadOnlyList<RuleExpression> Expressions { get; }
    }
}
