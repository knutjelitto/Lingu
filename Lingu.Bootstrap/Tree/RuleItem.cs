using System;
using System.Collections.Generic;
using System.Text;

namespace Lingu.Bootstrap.Tree
{
    public abstract class RuleItem : NamedNode
    {
        protected RuleItem(AtomName name)
            : base(name)
        {
        }
    }
}
