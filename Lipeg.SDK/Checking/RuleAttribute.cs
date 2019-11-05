using Lipeg.Runtime;

namespace Lipeg.SDK.Checking
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
