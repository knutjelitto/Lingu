using Lipeg.SDK.Tree;

namespace Lipeg.SDK.Checks
{
    public class ExpressionAttribute : IExpressionAttributes
    {
        public bool Nullable { get; private set; }

        public bool SetNullable()
        {
            if (!Nullable)
            {
                return Nullable = true;
            }
            return false;
        }
    }
}
