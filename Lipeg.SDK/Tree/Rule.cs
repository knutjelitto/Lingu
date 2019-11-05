using Lipeg.Runtime;
using Lipeg.SDK.Checking;

namespace Lipeg.SDK.Tree
{
    public class Rule
    {
        private Rule(Identifier identifier, IStarList<Identifier> flags, Expression expression)
        {
            Identifier = identifier;
            Flags = flags;
            Expression = expression;
        }
        public Identifier Identifier { get; }
        public Expression Expression { get; }
        public IStarList<Identifier> Flags { get; }

        public IRuleAttribute Attributes { get; } = new RuleAttribute();

        public static Rule From(Identifier identifier, IStarList<Identifier> flags, Expression expression)
        {
            return new Rule(identifier, flags, expression);
        }
    }
}
