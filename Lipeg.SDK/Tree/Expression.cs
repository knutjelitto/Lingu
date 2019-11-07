using Lipeg.Runtime;
using Lipeg.SDK.Checks;

namespace Lipeg.SDK.Tree
{
    public class Expression
    {
        public IExpressionAttribute Attributes { get; } = new ExpressionAttribute();
    }
}
