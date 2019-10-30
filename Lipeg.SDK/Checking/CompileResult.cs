using System;
using System.Collections.Generic;

using Lipeg.Runtime;

namespace Lipeg.SDK.Checking
{
    public class CompileResult : ICompileResult
    {
        private List<ICompileError> errors = new List<ICompileError>();

        public IReadOnlyList<ICompileError> Errors => errors;

        public bool HasError => errors.Count > 0;

        public bool IsExhausted => errors.Count > 4;
    }
}
