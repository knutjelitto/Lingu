using System;
using System.Collections.Generic;
using System.Text;

using Lipeg.Runtime;
using Lipeg.SDK.Common;
using Lipeg.SDK.Tree;

namespace Lipeg.SDK.Checking
{
    public class Semantic
    {
        public Semantic(Grammar grammar, ICompileResult results)
        {
            Grammar = grammar;
            Results = results;

            Rules = new UniqueCollection<string, Rule>(r => r.Identifier.Name, StringComparer.OrdinalIgnoreCase);
        }

        public Grammar Grammar { get; }
        public ICompileResult Results { get; }

        public UniqueCollection<string, Rule> Rules { get; }
    }
}
