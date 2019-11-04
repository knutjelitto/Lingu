using System;
using System.Collections.Generic;
using System.Text;
using Lipeg.Runtime;
using Lipeg.SDK.Tree;

namespace Lipeg.SDK.Checking
{
    public abstract class Check
    {
        protected Check(Semantic semantic)
        {
            Semantic = semantic;
        }

        public Semantic Semantic { get; }

        public Grammar Grammar => Semantic.Grammar;

        public ICompileResult Results => Semantic.Results;
    }
}
