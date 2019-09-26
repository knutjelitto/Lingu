using System;
using System.Collections.Generic;
using System.Text;

namespace Lingu.Runtime.Structures
{
    public interface INonleafToken : IToken
    {
        IReadOnlyList<IToken> Children { get; }
    }
}
