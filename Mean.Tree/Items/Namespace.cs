using System;
using System.Collections.Generic;
using System.Text;

namespace Mean.Tree.Items
{
    public class Namespace : IdItem
    {
        public Namespace(Identifier identifier, IEnumerable<IdItem> items)
            : base(identifier)
        {
            Items = new IdCollection<IdItem>(this, items);
        }

        public IdCollection<IdItem> Items { get; }

    }
}
