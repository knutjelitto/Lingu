using System;

using Lipeg.Runtime;

namespace Lipeg.SDK.Tree
{
    public class IdPart : ILocated
    {
        public IdPart(ILocated located, string name)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));
            if (located == null) throw new ArgumentNullException(nameof(located));

            Location = located.Location;
            Name = name;
        }

        public string Name { get; }

        public ILocation Location { get; }

        /// <inheritdoc />
        public override string ToString() => Name;
    }
}
