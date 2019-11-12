using System;
using Lipeg.Runtime;
using Lipeg.SDK.Tree;


namespace Lipeg.SDK.Checkers
{
    internal class RuleAttribute : IRuleAttributes
    {
        private IParser? parser;

        public bool Nullable { get; private set; }
        public bool Used { get; private set; }
        public bool Reachable { get; private set; }
        public IParser Parser
        {
            get => parser ?? throw new InvalidOperationException();
            private set => parser = value;
        }

        public bool SetNullable()
        {
            if (!Nullable)
            {
                return Nullable = true;
            }
            return false;
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

        public bool SetReachable()
        {
            if (!Reachable)
            {
                return Reachable = true;
            }
            return false;
        }

        public bool SetUsed()
        {
            if (!Used)
            {
                return Used = true;
            }
            return false;
        }
    }
}
