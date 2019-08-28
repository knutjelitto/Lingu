using System.Collections.Generic;
using System.Linq;

namespace Lingu.Bootstrap.Tree
{
    public class Options : Node
    {
        public Options(IEnumerable<Option> items)
        {
            Items = items.ToArray(); ;
        }

        public IReadOnlyList<Option> Items { get; }
    }
}
