using System;
using System.Collections.Generic;
using System.Text;

namespace Lipeg.Runtime
{
    public interface IGrammarAttribute
    {
        IRule Start { get; }
        IRule Spacing { get; }

        bool SetStart(IRule rule);
        bool SetSpacing(IRule rule);
    }
}
