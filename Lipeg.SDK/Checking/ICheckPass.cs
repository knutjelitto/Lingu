using Lipeg.Runtime;
using Lipeg.SDK.Tree;

namespace Lipeg.SDK.Checking
{
    public interface ICheckPass
    {
        Semantic Semantic { get; }
        void Check();
    }
}
