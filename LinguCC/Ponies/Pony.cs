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

namespace Lingu.CC.Ponies
{
    public class Pony
    {
        public void Build()
        {
            var lingu = new LinguContext();

            var projectDir = DirRef.ProjectDir();
            var ponyDir = projectDir.Dir("Ponies");

            Environment.CurrentDirectory = ponyDir;

            var file = FileRef.From("./Pony.Grammar");
            var dumps = FileRef.From("./Pony").Add(".Out");

            var source = Source.FromFile(file);

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

                        new CSharpWriter(grammar, file, ponyDir).Write();
                    }
                }
            }
        }
    }
}
