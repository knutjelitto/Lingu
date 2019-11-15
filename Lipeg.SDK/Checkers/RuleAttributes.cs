using System;
using System.Security;
using Lipeg.Runtime;
using Lipeg.SDK.Tree;

namespace Lipeg.SDK.Checkers
{
    internal class RuleAttributes : AttributesBase, IRuleAttributes
    {
        private IParser? parser;
        private bool? isNullable;
        private bool? isUsed;
        private bool? isReachable;
        private bool? isTerminal;
        private bool? isLexical;

        public bool IsNullable => Get(ref isNullable, nameof(IsNullable));
        public bool IsUsed => Get(ref isUsed, nameof(IsUsed));
        public bool IsReachable => Get(ref isReachable, nameof(IsReachable));
        public bool IsTerminal => Get(ref isTerminal, nameof(IsTerminal));
        public bool IsLexical => Get(ref isLexical, nameof(IsLexical));

        public IParser Parser
        {
            get => parser ?? throw new InvalidOperationException();
            private set => parser = value;
        }


        public bool SetParser(IParser parser)
        {
            if (this.parser == null && parser != null)
            {
                this.parser = parser;
                return true;
            }
            return false;
        }

        public bool SetIsNullable(bool value) => Set(ref isNullable, value);
        public bool SetIsReachable(bool value) => Set(ref isReachable, value);
        public bool SetIsUsed(bool value) => Set(ref isUsed, value);
        public bool SetIsTerminal(bool value) => Set(ref isTerminal, value);
        public bool SetIsLexical(bool value) => Set(ref isLexical, value);
    }
}
