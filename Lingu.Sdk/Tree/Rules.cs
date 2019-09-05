using System.Collections.Generic;

namespace Lingu.Sdk.Tree
{
    public sealed class Rules : NamedSet<RuleDefinition>
    {
        public Rules()
            : base("rules", true)
        {
        }
    }
}
