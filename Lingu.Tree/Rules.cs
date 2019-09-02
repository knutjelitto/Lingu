using System.Collections.Generic;

namespace Lingu.Tree
{
    public sealed class Rules : NamedSet<RuleDefinition>
    {
        public Rules()
            : base("rules", true)
        {
        }
    }
}
