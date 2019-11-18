using Lipeg.Runtime;
using Lipeg.SDK.Tree;

namespace Lipeg.SDK.Checkers
{
    public class ExpressionAttributes : AttributesBase, IExpressionAttributes
    {
        private bool? isNullable;
        private bool? isTerminal;

        public bool IsNullable => Get(ref isNullable, nameof(IsNullable));
        public bool IsLexical => Get(ref isTerminal, nameof(IsLexical));

        public bool SetIsNullable(bool value) => Set(ref isNullable, value);
        public bool SetIsLexical(bool value) => Set(ref isTerminal, value);
    }
}
