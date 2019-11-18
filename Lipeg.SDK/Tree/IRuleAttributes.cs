using Lipeg.Runtime;

namespace Lipeg.SDK.Tree
{
    public interface IRuleAttributes
    {
        bool IsUsed { get; }
        bool SetIsUsed(bool value);
        bool IsReachable { get; }
        bool SetIsReachable(bool value);
        bool IsNullable { get; }
        bool SetIsNullable(bool value);
        bool IsLexical { get; }
        bool SetIsLexical(bool value);

        IParser Parser { get; }
        bool SetParser(IParser parser);
    }
}
