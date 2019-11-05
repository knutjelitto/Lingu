namespace Lipeg.SDK.Tree
{
    public class PromoteExpression : Expression
    {
        private PromoteExpression(Expression expression)
        {
            Expression = expression;
        }
        public Expression Expression { get; }

        public static PromoteExpression From(Expression expression)
        {
            return new PromoteExpression(expression);
        }
    }
}
