using System.Collections.Generic;
using System.IO;
using System.Linq;
using Lipeg.Runtime;

namespace Lipeg.SDK.Checkers
{
    public class CompileResult : ICompileResult
    {
        private List<IMessage> errors = new List<IMessage>();

        public CompileResult()
        {
        }

        public IReadOnlyList<IMessage> Errors => errors;

        public bool HasErrors => errors.Any(e => e.Severity == MessageSeverity.Error || e.Severity == MessageSeverity.Fatal);
        public bool HasAny => this.errors.Count > 0;
        public bool IsFatal { get; private set; }
        public bool ShouldStop => IsFatal || errors.Count > 4;

        public void AddError(IMessage error)
        {
            errors.Add(error);
        }

        public void AddFatal(IMessage error)
        {
            IsFatal = true;
            AddError(error);
        }

        public bool Report(TextWriter writer)
        {
            foreach (var error in Errors)
            {
                error.Report(writer);
            }

            return HasErrors;
        }
    }
}
