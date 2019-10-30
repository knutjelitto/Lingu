using System.Collections.Generic;

namespace Lipeg.Runtime
{
    public interface ICompileResult
    {
        void AddError(ICompileError error);

        IReadOnlyList<ICompileError> Errors { get; }
        bool HasError { get; }
        bool IsExhausted { get; }
    }
}
