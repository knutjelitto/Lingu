using Lipeg.SDK.Checkers;

namespace Lipeg.SDK.Tree
{
    public interface IRule
    {
        Identifier Identifier { get; }
        Expression Expression { get; }
        IRuleAttributes Attr { get; }
    }
}