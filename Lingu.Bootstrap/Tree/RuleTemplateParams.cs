using System.Collections.Generic;
using System.Linq;

namespace Lingu.Bootstrap.Tree
{
    public class RuleTemplateParams : Node
    {
        public RuleTemplateParams(IEnumerable<AtomName> names)
        {
            Names = names.ToArray();
        }

        public IReadOnlyList<AtomName> Names { get; }

    }
}
