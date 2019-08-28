using System;
using System.Collections.Generic;
using System.Text;

namespace Mean.Tree.Items
{
    public class IdItem : Item, IIdentified
    {
        public IdItem(Identifier identifier)
        {
            Identifier = identifier;
        }

        public Identifier Identifier { get; }
    }
}
