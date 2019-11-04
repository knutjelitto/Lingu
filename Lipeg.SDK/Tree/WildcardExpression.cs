namespace Lipeg.SDK.Tree
{
    public class WildcardExpression : Expression
    {
        private WildcardExpression()
        {
        }

        public static WildcardExpression From()
        {
            return new WildcardExpression();
        }
    }
}
