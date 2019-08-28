using System;
using System.Collections.Generic;
using System.Text;

namespace Mean.Tree.Items
{
    public class Unit : Item
    {
        public Unit(Item container, IEnumerable<IdItem> unitItems)
        {
            Container = container;
            Items = new IdCollection<IdItem>(this, unitItems);
        }

        public IdCollection<IdItem> Items { get; }
    }
}
