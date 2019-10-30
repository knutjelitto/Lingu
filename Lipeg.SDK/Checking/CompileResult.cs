using System;
using System.Collections.Generic;

using Lipeg.Runtime;

namespace Lipeg.SDK.Checking
{
    public class CompileResult : ICompileResult
    {
        private List<ICompileError> errors = new List<ICompileError>();

        public void AddError(ICompileError error)
        {
            errors.Add(error);
        }

        public void AddFatal(ICompileError error)
        {
            IsFatal = true;
            AddError(error);
        }

        public IReadOnlyList<ICompileError> Errors => errors;

        public bool HasErrors => errors.Count > 0;
        public bool IsFatal { get; private set; }
        public bool ShouldStop => IsFatal || errors.Count > 4;
    }
}
