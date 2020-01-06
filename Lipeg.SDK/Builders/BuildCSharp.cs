using System;
using System.Collections.Generic;
using System.Text;

using Lipeg.Runtime.Tools;
using Lipeg.SDK.Checkers;
using Lipeg.SDK.Output;

namespace Lipeg.SDK.Builders
{
    public class BuildCSharp : IBuildPass
    {
        public BuildCSharp(Semantic semantic, FileRef file)
        {
            Semantic = semantic;
            File = file;
        }
        public Semantic Semantic { get; }
        public FileRef File { get; }

        public void Build()
        {
            var writer = new CsWriter();

            writer.Indent("namespace", () => { });

            writer.Persist(File);
        }
    }
}
