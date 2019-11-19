using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Lipeg.Runtime;

namespace Lipeg.SDK.Checkers
{
    public class CompileResult : ICompileResult
    {
        private List<ICompileError> errors = new List<ICompileError>();
        private Source? source;

        public CompileResult()
        {
        }

        public IReadOnlyList<ICompileError> Errors => errors;

        public bool HasErrors => errors.Any(e => e.Severity == ErrorSeverity.Error || e.Severity == ErrorSeverity.Fatal);
        public bool HasAny => this.errors.Count > 0;
        public bool IsFatal { get; private set; }
        public bool ShouldStop => IsFatal || errors.Count > 4;

        public void AddError(ICompileError error)
        {
            errors.Add(error);
        }

        public void AddFatal(ICompileError error)
        {
            IsFatal = true;
            AddError(error);
        }

        public void SetSource(Source source) => this.source = source;
        public Source GetSource() => this.source ?? throw new NullReferenceException();

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
