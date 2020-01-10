using Lipeg.Runtime;
using Lipeg.SDK.Tree;

namespace Lipeg.SDK.Checkers
{
    public abstract class CheckBase
    {
        protected CheckBase(Grammar grammar)
        {
            Grammar = grammar;
        }

        public Grammar Grammar { get; }

        public ICompileResult Results => Grammar.Results;
    }
}
