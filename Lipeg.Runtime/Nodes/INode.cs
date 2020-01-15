using System;
using System.Collections.Generic;
using System.Text;

namespace Lipeg.Runtime
{
    public interface INode : ILocated
    { 
        string Name { get; }
        string Fuse();

        INode this[int index] { get; }
        IReadOnlyList<INode> Children { get; }
        int Count { get; }

        INode Rename(string newName);
    }
}
