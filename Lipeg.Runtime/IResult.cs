namespace Lipeg.Runtime
{
    public interface IResult
    {
        ICursor Next { get; }
        bool IsFail { get; }
        bool IsSuccess => !IsFail;
        bool IsDrop { get; }
        INode Node { get; }

        IResult SetDrop();
    }
}
