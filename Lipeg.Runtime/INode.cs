using System;
using System.Collections.Generic;
using System.Text;

namespace Lipeg.Runtime
{
    public interface INode : IReadOnlyList<INode>, ILocated
    { 
        string Name { get; }
        void WithName(string name);
    }
}
