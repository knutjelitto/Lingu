using Lingu.Grammars;

namespace Lingu.Tree
{
    public sealed class Rules : NamedSet<Symbol, RuleDefinition>
    {
        public Rules()
            : base("rules", true, rule => rule)
        {
        }
    }
}
