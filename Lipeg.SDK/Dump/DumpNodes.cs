using System;
using System.Collections.Generic;
using System.Linq;

using Lipeg.Runtime;
using Lipeg.SDK.Common;
using Lipeg.SDK.Output;
using Lipeg.SDK.Tree;

namespace Lipeg.SDK.Dump
{
    public class DumpNodes : IDump<IEnumerable<INode>>
    {
        public void Dump(IWriter writer, IEnumerable<INode> nodes)
        {
            if (nodes == null) throw new ArgumentNullException(nameof(nodes));

            foreach (var node in nodes)
            {
                writer.Indent($"{Head(node)}", () =>
                {
                    Dump(writer, node.Children);
                });
            }
        }

        public void Dump(Grammar grammar, IWriter writer, IEnumerable<INode> nodes)
        {
            if (nodes == null) throw new ArgumentNullException(nameof(nodes));

            foreach (var node in nodes)
            {
                writer.Indent($"{Head(node)}", () =>
                {
                    Dump(grammar, writer, node.Children);
                });
            }
        }

        private static string Head(INode node)
        {
            if (node is ILeaf leaf)
            {
                return $"{leaf.Name}='{CharRep.InText(leaf.Value)}'";
            }
            return $"{node.Name} [{string.Join(", ", node.Children.Select(c => c.Name))}]";
        }
    }
}
