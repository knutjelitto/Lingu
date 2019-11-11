using Lipeg.SDK.Tree;

namespace Lipeg.SDK.Checks
{
    internal class RuleAttribute : IRuleAttributes
    {
        public bool Nullable { get; private set; }
        public bool Used { get; private set; }
        public bool Reachable { get; private set; }

        public bool SetNullable()
        {
            if (!Nullable)
            {
                return Nullable = true;
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
