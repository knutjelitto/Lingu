using System;
using System.Diagnostics;
using Lipeg.Runtime;
using Lipeg.SDK.Tree;

namespace Lipeg.SDK.Checking
{
    public class CheckOptions : Check, ICheckPass
    {
        public CheckOptions(Semantic semantic)
            : base(semantic)
        {
        }

        public void Check()
        {
            new CheckOptionsVisitor(Semantic).VisitGrammarOptions();
        }

        private class CheckOptionsVisitor : CheckVisitor
        {
            public CheckOptionsVisitor(Semantic semantic) : base(semantic) { }

            protected override void VisitOption(Option option)
            {
                switch (option.Identifier.Name.ToUpperInvariant())
                {
                    case "START":
                        if (option.QualifiedIdentifier.Identifiers.Count == 1)
                        {
                            if (Semantic.Rules.TryGetValue(option.QualifiedIdentifier.Identifiers[0].Name, out var rule))
                            {

                            }
                        }
                        break;
                }
            }
        }
    }
}
