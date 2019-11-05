using Lipeg.Runtime;
using Lipeg.SDK.Tree;

namespace Lipeg.SDK.Checks
{
    public interface ICheckPass
    {
        Semantic Semantic { get; }
        void Check();
    }
}
