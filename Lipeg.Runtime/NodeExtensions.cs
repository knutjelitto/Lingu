using System.Linq;

namespace Lipeg.Runtime
{
    public static class NodeExtensions
    {
        public static INode[] ToArray(this INode node)
        {
            if (node is INodeList nodes)
            {
                return nodes.Children.ToArray();
            }
            throw new InternalErrorException("can't enumerate leaf node");
        }

        public static INode At(this INode node, int index)
        {
            if (node is INodeList nodes)
            {
                return nodes.Children.ElementAt(index);
            }
            throw new InternalErrorException("can't enumerate leaf node");
        }
    }
}
