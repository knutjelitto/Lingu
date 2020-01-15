using System.Collections.Generic;
using System.Linq;

namespace Lipeg.Runtime
{
    public class NodeList : INodeList
    {
        private readonly IReadOnlyList<INode> children;

        private NodeList(ILocated located, string name, IReadOnlyList<INode> children)
        {
            Location = located.Location;
            Name = name;
            this.children = children;
        }

        public ILocation Location { get; }
        public string Name { get; private set; }
        public INode this[int index] => children[index];
        public IReadOnlyList<INode> Children => children;
        public int Count => children.Count;


        public static INodeList From(ILocated located, string name, params INode[] children) => new NodeList(located, name, children);
        public static INodeList From(ILocated located, string name, IReadOnlyList<INode> children) => new NodeList(located, name, children);

        public override string ToString() => $"{Name}[{string.Join(",", Children)}]";

        public string Fuse()
        {
            return string.Join(string.Empty, Children.Select(c => c.Fuse()));
        }

        public INode Rename(string newName)
        {
            Name = newName;
            return this;
        }
    }
}
