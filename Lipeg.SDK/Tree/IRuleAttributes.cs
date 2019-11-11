namespace Lipeg.SDK.Tree
{
    public interface IRuleAttributes
    {
        bool Used { get; }
        bool SetUsed();
        bool Reachable { get; }
        bool SetReachable();
        bool Nullable { get; }
        bool SetNullable();

    }
}
