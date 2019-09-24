namespace Lingu.Runtime.Structures
{
    public interface IProduction
    {
        int Length { get; }
        INonterminal Nonterminal { get; }
    }
}
