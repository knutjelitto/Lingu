using Lipeg.Runtime;
using System;

namespace Lipeg.SDK.Tree
{
    public abstract class Expression : ILocated
    {
        protected internal Expression(ILocated located)
        {
            if (located == null) throw new ArgumentNullException(nameof(located));

            Location = located.Location;
        }

        public ILocation Location { get; }
    }
}
