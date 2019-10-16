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
            var lingu = new Lingu.CC.LinguContext();

            var projectDir = DirRef.ProjectDir();
            var ponyDir = projectDir.Dir("Ponies");

            Environment.CurrentDirectory = ponyDir;

            var file = FileRef.From("./Pony.Grammar");
            var dumps = FileRef.From("./Pony").Add(".Out");

            var source = Source.FromFile(file);

            var parseTree = lingu.Try(source);

            new TreeDumper(dumps.Add(".Tree")).Dump(parseTree);

#if false
            var ast = Timer.Time("ast", () => new TreeBuilder().Visit(parseTree));

            var grammar = Timer.Time("build", () => new GrammarBuilder(ast).Build());

            Timer.Time("dump", () => new Dumper(grammar).Dump(dumps));

            Timer.Time("write", () => new CSharpWriter(grammar, file, ponyDir).Write());
#endif
        }
    }
}
