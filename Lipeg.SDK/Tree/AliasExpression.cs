using Lipeg.Runtime;

namespace Lipeg.SDK.Tree
{
    public class AliasExpression : WithInnerExpression
    {
        private AliasExpression(ILocated located, Expression expression, Identifier alias)
            : base(located, expression)
        {
            Alias = alias;
        }

        public Identifier Alias { get; }

        public static AliasExpression From(ILocated located, Expression expression, Identifier alias)
        {
            return new AliasExpression(located, expression, alias);
        }
    }
}
