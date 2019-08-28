using System.Collections.Generic;
using System.Linq;

namespace Mean.Tree.Items
{
    public class Generics : Item
    {
        public Generics(IEnumerable<TypeId> names, IEnumerable<Ref<TypeId>> defaults)
        {
            Names = new IdCollection<TypeId>(this, names);
            Defaults = new IdCollection<Ref<TypeId>>(this, defaults);
        }

        public IdCollection<TypeId> Names { get; }
        public IdCollection<Ref<TypeId>> Defaults { get; }
    }
}
