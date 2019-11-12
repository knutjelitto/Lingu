using Lipeg.Runtime;
using Lipeg.SDK.Tree;

namespace Lipeg.SDK.Checkers
{
    public interface ICheckPass
    {
        Semantic Semantic { get; }
        void Check();
    }
}
