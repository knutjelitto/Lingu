using System.Collections.Generic;
using System.IO;

namespace Lipeg.Runtime
{
    public interface ICompileResult
    {
        void SetSource(Source source);
        Source GetSource();

        bool HasErrors { get; }
        bool ShouldStop { get; }
        bool IsFatal { get; }

        void AddError(ICompileError error);
        void AddFatal(ICompileError error);
        IReadOnlyList<ICompileError> Errors { get; }

        bool Report(TextWriter writer);
    }
}
