using Lipeg.SDK.Checkers;

namespace Lipeg.SDK.Builders
{
    public interface IBuildPass
    {
        Semantic Semantic { get; }
        void Build();
    }
}
