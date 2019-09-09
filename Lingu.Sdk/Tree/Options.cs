using System.Collections.Generic;
using System.Linq;
using Lingu.Commons;

namespace Lingu.Tree
{
    public class Options : NamedSet<TreeOption>
    {
        public Options()
            : base("options", false)
        {
        }
    }
}
