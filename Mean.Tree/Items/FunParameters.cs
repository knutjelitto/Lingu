using System;
using System.Collections.Generic;
using System.Text;

namespace Mean.Tree.Items
{
    public class FunParameters : Item
    {
        public FunParameters(IEnumerable<Ref<Type>> parameters)
        {
            Parameters = new IdCollection<Ref<Type>>(this, parameters);
        }

        public IdCollection<Ref<Type>> Parameters { get; }
    }
}
