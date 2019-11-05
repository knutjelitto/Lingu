using Lipeg.Runtime;

namespace Lipeg.SDK.Checks
{
    internal class RuleAttribute : IRuleAttribute
    {
        public void Use()
        {
            UseCount += 1;
        }
        public int UseCount { get; private set; }

    }
}
