using System.Collections.Generic;
using System.Linq;

namespace Lingu.Bootstrap.Tree
{
    public class Rules : Node
    {
        public Rules(IEnumerable<RuleItem> items)
        {
            Items = items.ToArray();
        }

        public IReadOnlyCollection<RuleItem> Items { get; }
    }
}
