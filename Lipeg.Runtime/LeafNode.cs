using System.Collections;
using System.Collections.Generic;

namespace Lipeg.Runtime
{
    public class LeafNode : ILeafNode
    {
        private static readonly List<LeafNode> Empty = new List<LeafNode>();

        private LeafNode(ILocation location, string name)
        {
            Location = location;
            Name = name;
            Value = string.Empty;
        }

        private LeafNode(ILocation location, string name, string value)
        {
            Location = location;
            Name = name;
            Value = value;
        }

        public ILocation Location { get; }
        public string Name { get; private set; }
        public string Value { get; }

        public static INode From(ILocation location, string name) => new LeafNode(location, name);
        public static INode From(ILocation location, string name, string value) => new LeafNode(location, name, value);
        
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
    }
}
