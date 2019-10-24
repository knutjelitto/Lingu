using System;
using System.Collections;
using System.Collections.Generic;

namespace Lipeg.Runtime
{
    public class LeafNode : INode
    {
        private static readonly List<LeafNode> Empty = new List<LeafNode>();

        private LeafNode(string name)
        {
            Name = name;
            Value = string.Empty;
        }

        private LeafNode(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; }
        public string Value { get; }

        public static INode From(string name) => new LeafNode(name);
        public static INode From(string name, string value) => new LeafNode(name, value);
        
        public IEnumerator<INode> GetEnumerator() => Empty.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public int Count => 0;
        public INode this[int index] => Empty[0];

        public override string ToString() => Name;
    }
}
