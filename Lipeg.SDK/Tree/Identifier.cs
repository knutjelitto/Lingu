using System;

using Lipeg.Runtime;

namespace Lipeg.SDK.Tree
{
    public class Identifier
    {
        private Identifier(ILocation location, string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            Location = location;
            Name = name;
        }

        public ILocation Location { get; }
        public string Name { get; }

        public static Identifier From(ILocation location, string name)
        {
            return new Identifier(location, name);
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return Name;
        }
    }
}
