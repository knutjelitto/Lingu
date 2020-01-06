using Lipeg.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lipeg.Boot
{
    public abstract class ParserBuild
    {
        protected static IParser Sequence(params IParser[] parsers)
        {
            return new SDK.Parsers.Sequence(parsers);
        }
    }
}
