using Lipeg.Runtime;
using Lipeg.SDK.Checks;

namespace Lipeg.SDK.Tree
{
    public class Rule : IRule
    {
        private Rule(Identifier identifier, Expression expression)
        {
            Identifier = identifier;
            Expression = expression;
        }
        public Identifier Identifier { get; }
        public Expression Expression { get; }

        public IRuleAttribute Attributes { get; } = new RuleAttribute();

        public static Rule From(Identifier identifier, Expression expression)
        {
            return new Rule(identifier, expression);
        }
    }
}
