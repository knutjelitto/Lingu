using System;
using System.Diagnostics;
using Lipeg.Runtime;
using Lipeg.SDK.Tree;

namespace Lipeg.SDK.Checkers
{
    public class CheckOptions : Check, ICheckPass
    {
        public CheckOptions(Semantic semantic)
            : base(semantic)
        {
        }

        public void Check()
        {
            new Visitor(Semantic).VisitGrammarOptions();
        }

        private class Visitor : TreeVisitor
        {
            public Visitor(Semantic semantic) : base(semantic) { }

            protected override void VisitOption(Option option)
            {
                switch (option.Identifier.Name.ToUpperInvariant())
                {
                    case "START":
                        FindRule(option, rule => Semantic[Grammar].SetStart(rule));
                        break;
                    case "SPACING":
                        FindRule(option, rule => Semantic[Grammar].SetSpacing(rule));
                        break;
                    default:
                        Results.AddError(new CheckError(ErrorCode.UnknownOption, option.Identifier));
                        break;
                }
            }

            private void FindRule(Option option, Func<Rule, bool> setter)
            {
                if (option.QualifiedIdentifier.Identifiers.Count == 1)
                {
                    var identifier = option.QualifiedIdentifier.Identifiers[0];

                    if (Semantic.Rules.TryGetValue(identifier.Name, out var rule))
                    {
                        if (rule == null) throw new InternalErrorException($"{nameof(rule)} really shouldn't be NULL");

                        if (!setter(rule))
                        {
                            Results.AddError(new CheckError(ErrorCode.AlreadyDefinedOption, identifier));
                        }
                        else
                        {
                            Semantic[rule].SetUsed();
                            return;
                        }
                    }
                    Results.AddError(new CheckError(ErrorCode.UndefinedOptionValue, identifier));
                    return;
                }
                Results.AddError(new CheckError(ErrorCode.IllegalOptionValue, option.QualifiedIdentifier));
            }
        }
    }
}
