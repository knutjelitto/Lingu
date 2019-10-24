using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lipeg.Runtime
{
    public class InternalNode : INode
    {
        private InternalNode(string name, params INode[] children)
        {
            Name = name;
            Children = children;
        }

        public string Name { get; set; }
        private IReadOnlyList<INode> Children { get; }
        public static INode From(string name, params INode[] children) => new InternalNode(name, children);
        public IEnumerator<INode> GetEnumerator() => Children.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public int Count => Children.Count;
        public INode this[int index] => Children[index];

        public override string ToString() => $"{Name}[{String.Join(",", Children)}]";
    }
}
