using System.Collections.Generic;
using System.Linq;
using Lingu.Commons;

namespace Lingu.Tree
{
    public class Options : NamedSet<Option>
    {
        public Options()
            : base("options", false)
        {
        }
    }
}
