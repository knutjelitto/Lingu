using System.Collections.Generic;
using System.Linq;

namespace Lingu.Tree
{
    public class Terminals : Node
    {
        public Terminals(IEnumerable<TerminalItem> items)
        {
            Items = items.ToArray(); ;
        }

        public IReadOnlyList<TerminalItem> Items { get; }
    }
}
