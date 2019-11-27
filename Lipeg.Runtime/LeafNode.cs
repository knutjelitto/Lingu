using System.Collections;
using System.Collections.Generic;

namespace Lipeg.Runtime
{
    public class LeafNode : ILeafNode
    {
        private static readonly List<LeafNode> Empty = new List<LeafNode>();

        private LeafNode(ILocated located, string name)
        {
            Location = located.Location;
            Name = name;
            Value = string.Empty;
        }

        private LeafNode(ILocated located, string name, string value)
        {
            Location = located.Location;
            Name = name;
            Value = value;
        }

        public ILocation Location { get; }
        public string Name { get; private set; }
        public string Value { get; }

        public static INode From(ILocated located, string name) => new LeafNode(located, name);
        public static INode From(ILocated located, string name, string value) => new LeafNode(located, name, value);
        
        public IEnumerator<INode> GetEnumerator() => Empty.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public int Count => 0;
        public INode this[int index] => Empty[0];

        public override string ToString()
        {
            if (string.IsNullOrEmpty(Value))
            {
                return Name;
            }

            return $"{Name}={Value}";
        }

        public void WithName(string name)
        {
            Name = name;
        }

        public string Fuse()
        {
            return Value;
        }
    }
}
