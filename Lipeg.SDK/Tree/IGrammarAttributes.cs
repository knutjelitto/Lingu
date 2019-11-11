using System;
using System.Collections.Generic;
using System.Text;

namespace Lipeg.SDK.Tree
{
    public interface IGrammarAttributes
    {
        Rule Start { get; }
        Rule Spacing { get; }

        bool SetStart(Rule rule);
        bool SetSpacing(Rule rule);
    }
}
