using Lipeg.Runtime;
using Lipeg.SDK.Tree;

namespace Lipeg.SDK.Checking
{
    public interface ICheckPass
    {
        void Check(Semantic semantic);
    }
}
