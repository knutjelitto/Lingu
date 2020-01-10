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
    }
}
