using Lipeg.Runtime;
using Lipeg.SDK.Tree;

namespace Lipeg.SDK.Checkers
{
    public class ExpressionAttributes : AttributesBase, IExpressionAttributes
    {
        private bool? isNullable;
        private bool? isTerminal;

        public bool IsNullable => Get(ref isNullable, nameof(IsNullable));
        public bool IsTerminal => Get(ref isTerminal, nameof(IsTerminal));

        public bool SetIsNullable()
        {
            if (!IsNullable)
            {
                this.isNullable = true;
                return true;
            }
            return false;
        }

        public bool SetIsTerminal()
        {
            if (!IsTerminal)
            {
                this.isTerminal = true;
                return true;
            }
            return false;
        }
    }
}
