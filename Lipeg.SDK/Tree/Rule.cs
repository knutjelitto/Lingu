namespace Lipeg.SDK.Tree
{
    public class Rule
    {
        private Rule(Identifier identifier, Expression expression)
        {
            Identifier = identifier;
            Expression = expression;
        }
        public Identifier Identifier { get; }
        public Expression Expression { get; }

        public static Rule From(Identifier identifier, Expression expression)
        {
            return new Rule(identifier, expression);
        }
    }
}
