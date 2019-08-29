using System.Collections.Generic;
using System.Linq;

namespace Lingu.Tree
{
    public class RuleArguments : Node
    {
        public RuleArguments(IEnumerable<RuleExpression> items)
        {
            Items = items.ToArray();
        }

        public IReadOnlyList<RuleExpression> Items { get; }
    }
}
