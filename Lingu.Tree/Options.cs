using System.Collections.Generic;
using System.Linq;
using Lingu.Commons;

namespace Lingu.Tree
{
    public class Options : Node
    {
        public Options(IEnumerable<Option> items)
        {
            Items = items.ToArray(); ;
        }

        public IReadOnlyList<Option> Items { get; }

        public override void Dump(Indentable output, bool top)
        {
            output.Block("options", () =>
            {
                foreach (var option in Items)
                {
                    option.Dump(output, top);
                }
            });
        }
    }
}
