using System;
using System.Collections.Generic;
using System.Text;

using Lingu.Build;
using Lingu.Commons;
using Lingu.CSharpWrite;
using Lingu.Dumping;
using Lingu.Runtime.Lexing;
using Lingu.Runtime.Parsing;
using Lingu.Runtime.Sources;

#nullable enable

namespace Lingu.CC.Ucds
{
    public class Ucd
    {
        public void Build()
        {
            var lingu = new LinguContext();

            var projectDir = DirRef.ProjectDir();
            var ucdDir = projectDir.Up.Dir("LinguUcd");

            Environment.CurrentDirectory = ucdDir;

            var sourceFile = ucdDir.File("Ucd.lug");
            var outputDir = ucdDir.Dir("Generated");
            var dumps = outputDir.File("Ucd.Out");

            var source = Source.FromFile(sourceFile);

            var parseTree = lingu.Try(source);

            if (parseTree != null)
            {
                new TreeDumper(dumps.Add(".Tree")).Dump(parseTree);

                var ast = new TreeBuilder().Visit(parseTree);

                if (ast != null)
                {
                    var grammar = new GrammarBuilder(ast).Build();

                    if (grammar != null)
                    {
                        new Dumper(grammar).Dump(dumps);

                        new CSharpWriter(grammar, sourceFile, outputDir).Write();
                    }
                }
            }
        }
    }
}
