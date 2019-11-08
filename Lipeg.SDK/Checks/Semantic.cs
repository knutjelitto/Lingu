using System;
using System.Collections.Generic;
using System.Text;

using Lipeg.Runtime;
using Lipeg.SDK.Common;
using Lipeg.SDK.Tree;

namespace Lipeg.SDK.Checks
{
    public class Semantic
    {
        private Dictionary<Grammar, IGrammarAttribute> grammarAttributes = new Dictionary<Grammar, IGrammarAttribute>();

        public Semantic(Grammar grammar, ICompileResult results)
        {
            Grammar = grammar;
            Results = results;

            Rules = new UniqueCollection<string, Rule>(r => r.Identifier.Name, StringComparer.OrdinalIgnoreCase);
        }

        public Grammar Grammar { get; }
        public ICompileResult Results { get; }

        public UniqueCollection<string, Rule> Rules { get; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1043:Use Integral Or String Argument For Indexers", Justification = "<Pending>")]
        public IGrammarAttribute this[Grammar grammar]
        {
            get
            {
                if (!grammarAttributes.TryGetValue(Grammar, out var attributes))
                {
                    attributes = new GrammarAttribute();
                    grammarAttributes.Add(Grammar, attributes);
                }

                return attributes;
            }
        }
    }
}
