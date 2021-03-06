﻿using Lipeg.Runtime;
using Lipeg.SDK.Common;

namespace Lipeg.SDK.Tree
{
    public interface IGrammarAttributes
    {
        IRule Start { get; }
        bool SetStart(IRule rule);
        IRule Spacing { get; }
        bool SetSpacing(IRule rule);

        IParser Parser { get; }
        bool SetParser(IParser parser);

        UniqueCollection<string, IRule> Rules { get; }

    }
}
