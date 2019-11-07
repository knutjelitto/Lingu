namespace Lipeg.SDK.Tree
{
    public class LiftExpression : Expression
    {
        private LiftExpression(Expression expression)
        {
            Expression = expression;
        }
        public Expression Expression { get; }

        public static LiftExpression From(Expression expression)
        {
            return new LiftExpression(expression);
        }
    }
}
