namespace Lipeg.SDK.Tree
{
    public class DropExpression : Expression
    {
        private DropExpression(Expression expression)
        {
            Expression = expression;
        }
        public Expression Expression { get; }

        public static DropExpression From(Expression expression)
        {
            return new DropExpression(expression);
        }
    }
}
