using System;
using System.Collections.Generic;
using System.Text;

namespace Mean.Tree.Items
{
    public class Ref<T> : IdItem where T : Item
    {
        public Ref(Identifier identifier, T referenced)
            : base(identifier)
        {
            Referenced = referenced;
        }

        public T Referenced { get; }
    }
}
