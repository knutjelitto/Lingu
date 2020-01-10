using System;
using System.Diagnostics;
using Lipeg.Runtime;
using Lipeg.SDK.Tree;

namespace Lipeg.SDK.Checkers
{
    public class CheckOptions : CheckBase, ICheckPass
    {
        public CheckOptions(Grammar grammar)
            : base(grammar)
        {
        }

        public void Check()
        {
            new Visitor(Grammar).VisitGrammarOptions();
        }

        private class Visitor : TreeVisitor
        {
            public Visitor(Grammar grammar) : base(grammar) { }

            protected override void VisitOption(Option option)
            {
                switch (option.Identifier.Name.ToUpperInvariant())
                {
                    case "START":
                        FindRule(option, rule => Grammar.Attr.SetStart(rule));
                        break;
                    case "SPACING":
                        FindRule(option, rule => Grammar.Attr.SetSpacing(rule));
                        break;
                    default:
                        Results.AddError(new MessageError(MessageCode.UnknownOption, option.Identifier));
                        break;
                }
            }

            private void FindRule(Option option, Func<IRule, bool> setter)
            {
                if (option.OptionValue.QualifiedIdentifier.Parts.Count == 1)
                {
                    var identifier = option.OptionValue.QualifiedIdentifier.Parts[0];

                    if (Grammar.Attr.Rules.TryGetValue(identifier.Name, out var rule))
                    {
                        if (rule == null) throw new InternalNullException();

                        if (!setter(rule))
                        {
                            Results.AddError(new MessageError(MessageCode.AlreadyDefinedOption, identifier));
                        }
                        else
                        {
                            rule.Attr.SetIsUsed(true);
                            return;
                        }
                    }
                    Results.AddError(new MessageError(MessageCode.UndefinedOptionValue, identifier));
                    return;
                }
                Results.AddError(new MessageError(MessageCode.IllegalOptionValue, option.OptionValue.QualifiedIdentifier));
            }
        }
    }
}
