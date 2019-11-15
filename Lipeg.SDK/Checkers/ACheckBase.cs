using Lipeg.Runtime;
using Lipeg.SDK.Tree;

namespace Lipeg.SDK.Checkers
{
    public abstract class ACheckBase
    {
        protected ACheckBase(Semantic semantic)
        {
            Semantic = semantic;
        }

        public Semantic Semantic { get; }

        public Grammar Grammar => Semantic.Grammar;

        public ICompileResult Results => Semantic.Results;
    }
}
