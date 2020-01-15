using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Lipeg.Runtime
{
    public class Leaf : ILeaf
    {
        private static IReadOnlyList<INode> Empty = new INode[] { };

        private Leaf(ILocated located, string name)
        {
            Location = located.Location;
            Name = name;
            Value = string.Empty;
        }

        private Leaf(ILocated located, string name, string value)
        {
            Location = located.Location;
            Name = name;
            Value = value;
        }

        public ILocation Location { get; }
        public string Name { get; private set; }
        public string Value { get; }

        public INode this[int index] => Children.ElementAt(index);
        public IReadOnlyList<INode> Children => Empty;
        public int Count => 0;

        public static INode From(ILocated located, string name) => new Leaf(located, name);
        public static INode From(ILocated located, string name, string value) => new Leaf(located, name, value);

        public override string ToString()
        {
            if (string.IsNullOrEmpty(Value))
            {
                return Name;
            }

            return $"{Name}='{Value}'";
        }

        public string Fuse()
        {
            return Value;
        }

        public INode Rename(string newName)
        {
            Name = newName;
            return this;
        }
    }
}
