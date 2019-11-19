namespace Lipeg.SDK.Tree
{
    public class Rule
    {
        private Rule(Identifier identifier, Expression expression)
        {
            Identifier = identifier;
            Expression = expression;
        }
        public Identifier Identifier { get; private set; }
        public Expression Expression { get; }
        public void Rename(Identifier identifier) => Identifier = identifier;
        public static Rule From(Identifier identifier, Expression expression) => new Rule(identifier, expression);
    }
}
