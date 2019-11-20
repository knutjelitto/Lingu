namespace Lipeg.SDK.Tree
{
    public interface IRule
    {
        Expression Expression { get; }
        Identifier Identifier { get; }
    }
}