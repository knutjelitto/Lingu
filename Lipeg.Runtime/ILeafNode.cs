using System;
using System.Collections.Generic;
using System.Text;

namespace Lipeg.Runtime
{
    public interface ILeafNode : INode
    { 
        string Value { get; }
    }
}
