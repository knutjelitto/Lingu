using System;
using System.Collections.Generic;
using System.Text;

namespace Mean.Tree.Items
{
    public class Item : IContained
    {
        public Item Container { get; set; }
    }
}
