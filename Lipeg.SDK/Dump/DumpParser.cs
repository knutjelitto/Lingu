using System;
using System.Collections.Generic;
using System.Linq;

using Lipeg.SDK.Output;
using Lipeg.Runtime;
using Lipeg.SDK.Checkers;
using System.Diagnostics;

namespace Lipeg.SDK.Dump
{
    public class DumpParser : IDump<Semantic>
    {
        public void Dump(IWriter writer, Semantic semantic)
        {
            if (semantic == null) throw new ArgumentNullException(nameof(semantic));

            var parser = semantic.Grammar.Attr(semantic).Parser;
            Debug.Assert(parser != null);

            Dump(writer, parser);
        }

        private void Dump(IWriter writer, IParser parser)
        {
            writer.Indent($"{parser.Name}", () =>
            {
                foreach (var child in parser)
                {
                    Dump(writer, parser);
                }
            });
        }
    }
}
