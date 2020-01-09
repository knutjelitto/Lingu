using Lipeg.Runtime;
using Lipeg.SDK.Tree;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lipeg.SDK
{
    public interface IGrammarBuilder
    {
        Grammar Build(INode node);
    }

}
