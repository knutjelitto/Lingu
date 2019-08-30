using System.Collections.Generic;
using System.Linq;

namespace Lingu.Tree
{
    public class Rules : Node
    {
        public Rules(IEnumerable<Rule> items)
        {
            Items = items.ToArray();
        }

        public IReadOnlyCollection<Rule> Items { get; }
    }
}
