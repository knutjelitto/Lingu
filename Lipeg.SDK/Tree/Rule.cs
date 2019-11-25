namespace Lipeg.SDK.Tree
{
    public class Rule : IRule
    {
        private Rule(Identifier identifier, Expression expression)
        {
            Identifier = identifier;
            Expression = expression;
        }
        public Identifier Identifier { get; private set; }
        public Expression Expression { get; }
        public static IRule From(Identifier identifier, Expression expression) => new Rule(identifier, expression);

        public override string ToString()
        {
            return Identifier.Name;
        }
    }
}
