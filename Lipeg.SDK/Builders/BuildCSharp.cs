using System;
using System.Collections.Generic;
using System.Text;

using Lipeg.Runtime.Tools;
using Lipeg.SDK.Checkers;
using Lipeg.SDK.Output;
using Lipeg.SDK.Tree;

namespace Lipeg.SDK.Builders
{
    public class BuildCSharp : IBuildPass
    {
        private class Config
        {
            public Config(Grammar grammar)
            {
                Grammar = grammar;
            }

            public Grammar Grammar { get; }

            public readonly bool Disable = true;
            public readonly string Namespace = "Lipeg.Generated";
            public string ParserClass => $"{Grammar.Name}Parser";

        }
        public BuildCSharp(Grammar grammar, FileRef outFile)
        {
            Grammar = grammar;
            OutFile = outFile;
            Cfg = new Config(Grammar);
        }

        public Grammar Grammar { get; }
        public FileRef OutFile { get; }
        private Config Cfg { get; }

        public void Build()
        {
            var writer = new CsWriter();

            if (Cfg.Disable) writer.WriteLine("#if false");
            
            writer.Block($"namespace {Cfg.Namespace}",
                         () =>
                         {
                             writer.Block($"public {Cfg.ParserClass}",
                                          () =>
                                          {
                                              // NOP
                                          });
                         });

            if (Cfg.Disable) writer.WriteLine("#endif");

            writer.Persist(OutFile);
        }
    }
}
