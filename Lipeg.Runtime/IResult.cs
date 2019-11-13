namespace Lipeg.Runtime
{
    public interface IResult
    {
        ICursor Next { get; }
        bool IsFail { get; }
        bool IsSuccess => !IsFail;
        bool IsDrop { get; }
        bool IsLift { get; }
        bool IsFuse { get; }
        INode Node { get; }

        IResult SetDrop();
        IResult SetLift();
        IResult SetFuse();
    }
}
