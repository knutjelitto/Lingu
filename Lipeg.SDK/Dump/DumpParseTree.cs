using System;
using System.Collections.Generic;
using System.Linq;

using Lipeg.SDK.Output;
using Lipeg.Runtime;
using Lipeg.SDK.Common;

namespace Lipeg.SDK.Dump
{
    public class DumpNodes : IDump<INode>
    {
        public void Dump(IWriter writer, INode node)
        {
            if (node == null) throw new ArgumentNullException(nameof(node));

            writer.Indent($"{Head(node)}", () =>
            {
                foreach (var child in node)
                {
                    Dump(writer, child);
                }
            });
        }

        private string Head(INode node)
        {
            if (node is ILeafNode leaf)
            {
                return $"{leaf.Name}='{CharRep.InText(leaf.Value)}'";
            }
            return $"{node.Name} [{string.Join(", ", node.Select(c => c.Name))}]";
        }
    }
}
