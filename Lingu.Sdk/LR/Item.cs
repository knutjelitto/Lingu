using System;
using System.Collections.Generic;
using System.Text;

namespace Lingu.LR
{
    public abstract class Item
    {
        protected Item(Core dotted)
        {
            Dotted = dotted;
        }

        public Core Dotted { get; }
    }
}
