using System;
using System.Collections.Generic;
using System.Text;

namespace Lipeg.Runtime
{
    public interface IGrammarAttribute
    {
        IRule Start { get; }
        IRule Spacing { get; }
    }
}
