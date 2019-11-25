using Lipeg.Runtime;
using Lipeg.SDK.Tree;
using System;

namespace Lipeg.SDK.Parsers
{
    public class Name : Reference
    {
        public Name(Func<IParser> parser, Identifier identifier)
            : base(OpSymbols.Ref, identifier, parser)
        {
        }
    }
}
