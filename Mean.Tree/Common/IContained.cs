using Mean.Tree.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mean.Tree
{
    public interface IContained
    {
        Item Container { get; set; }
    }
}
