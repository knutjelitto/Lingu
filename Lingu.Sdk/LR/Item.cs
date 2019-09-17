using System;
using System.Collections.Generic;
using System.Text;

namespace Lingu.LR
{
    public abstract class Item
    {
        protected Item(Dotted dotted)
        {
            Dotted = dotted;
        }

        public Dotted Dotted { get; }
    }
}
