using System;
using System.Collections.Generic;
using System.Text;

namespace Lipeg.Runtime
{
    public interface ILeaf : INode
    { 
        string Value { get; }
    }
}
