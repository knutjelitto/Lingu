namespace Lipeg.SDK.Tree
{
    public class FuseExpression : Expression
    {
        private FuseExpression(Expression expression)
        {
            Expression = expression;
        }
        public Expression Expression { get; }

        public static FuseExpression From(Expression expression)
        {
            return new FuseExpression(expression);
        }
    }
}
