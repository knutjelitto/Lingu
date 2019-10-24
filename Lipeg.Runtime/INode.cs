using System;
using System.Collections.Generic;
using System.Text;

namespace Lipeg.Runtime
{
    public interface INode : IReadOnlyList<INode>
    { 
        string Name { get; }
    }
}
