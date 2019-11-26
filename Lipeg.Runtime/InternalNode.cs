using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lipeg.Runtime
{
    public class InternalNode : INode
    {
        private InternalNode(ILocated located, string name, IReadOnlyList<INode> children)
        {
            Location = located.Location;
            Name = name;
            Children = children;
        }

        public ILocation Location { get; }
        public string Name { get; private set; }
        private IReadOnlyList<INode> Children { get; }
        public static INode From(ILocated located, string name, params INode[] children) => new InternalNode(located, name, children);
        public static INode From(ILocated located, string name, IReadOnlyList<INode> children) => new InternalNode(located, name, children);
        public IEnumerator<INode> GetEnumerator() => Children.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public int Count => Children.Count;
        public INode this[int index] => Children[index];

        public override string ToString() => $"{Name}[{string.Join(",", Children)}]";

        public void WithName(string name)
        {
            Name = name;
        }
    }
}
