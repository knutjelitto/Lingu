using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lipeg.Runtime
{
    public class InternalNode : INode
    {
        private InternalNode(ILocation location, string name, IReadOnlyList<INode> children)
        {
            Location = location;
            Name = name;
            Children = children;
        }

        public ILocation Location { get; }
        public string Name { get; set; }
        private IReadOnlyList<INode> Children { get; }
        public static INode From(ILocation location, string name, params INode[] children) => new InternalNode(location, name, children);
        public static INode From(ILocation location, string name, IReadOnlyList<INode> children) => new InternalNode(location, name, children);
        public IEnumerator<INode> GetEnumerator() => Children.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public int Count => Children.Count;
        public INode this[int index] => Children[index];

        public override string ToString() => $"{Name}[{String.Join(",", Children)}]";
    }
}
