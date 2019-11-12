using System;
using System.Threading;
using Lipeg.Runtime;
using Lipeg.SDK.Tree;

namespace Lipeg.SDK.Checkers
{
    /// <summary>
    /// Create all rules
    /// </summary>
    internal class CheckCreateRules : Check, ICheckPass
    {
        public CheckCreateRules(Semantic semantic)
            : base(semantic)
        {
        }

        public void Check()
        {
            foreach (var rule in Grammar.Rules)
            {
                if (Semantic.Rules.TryGetValue(rule.Identifier.Name, out var already))
                {
                    if (already == null) throw  new InternalErrorException($"{nameof(already)} really shouldn't be NULL");

                    Results.AddError(new CheckError(ErrorCode.AlreadyDefinedRule, already.Identifier));
                    Results.AddError(new CheckError(ErrorCode.RedefinedRule, rule.Identifier));
                    continue;
                }
                Semantic.Rules.Add(rule);
            }
        }
    }
}
