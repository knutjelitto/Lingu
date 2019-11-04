using System.Collections.Generic;

namespace Lipeg.Runtime
{
    public interface ICompileResult
    {
        void SetSource(Source source);
        Source GetSource();

        void AddError(ICompileError error);
        void AddFatal(ICompileError error);
        IReadOnlyList<ICompileError> Errors { get; }
        bool HasErrors { get; }
        bool ShouldStop { get; }
        bool IsFatal { get; }
    }
}
