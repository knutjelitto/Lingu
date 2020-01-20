namespace Lipeg.SDK.Tree
{
    public interface IExpressionAttributes
    {
        bool IsNullable { get; }
        bool SetIsNullable(bool value);
        bool IsLexical { get; }
        bool SetIsLexical(bool value);
        bool IsWithSpacing { get; }
        bool SetIsWithSpacing(bool value);
        IRule Rule { get; }
        void SetRule(IRule rule);
        string RealStart { get; }
        bool SetRealStart(string value);
    }
}
