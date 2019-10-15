using System;
using Lingu.Build;
using Lingu.Commons;
using Lingu.CSharpWrite;
using Lingu.Dumping;
using Lingu.Runtime.Lexing;
using Lingu.Runtime.Parsing;
using Lingu.Runtime.Sources;

#nullable enable

namespace Lingu.CC
{
    class Program
    {
        static void Main(/*string[] args*/)
        {
            Timer.Time("ALL",  BuildCC);
#if true
            Console.Write("press (almost) any key ... ");
            Console.ReadKey(true);
#endif
        }


        private static void BuildCC()
        {
            var projectDir = DirRef.ProjectDir();
            var linguCC = projectDir.Up.Dir("LinguCC");
            var genDir = linguCC.Dir("Gen");

            Environment.CurrentDirectory = genDir;

            var file = FileRef.From("./Lingu.Grammar");
            var dumps = FileRef.From("./Lingu").Add(".Out");

            var context = Timer.Time("context", () => new LinguContext());

            var source = Timer.Time("source", () => Source.FromFile(file));

            var lexer = Timer.Time("lexer", () => new Lexer(context, source));

            var parser = Timer.Time("parser", () => new Parser(context, lexer));

            var parseTree = Timer.Time("parse", () => parser.Parse());

            Timer.Time("tree-dump", () => new TreeDumper(dumps.Add(".Tree")).Dump(parseTree));
            
            var ast = Timer.Time("ast", () => new TreeBuilder().Visit(parseTree));

            var grammar = Timer.Time("build", () => new GrammarBuilder(ast).Build());

            Timer.Time("dump", () => new Dumper(grammar).Dump(dumps));

            Timer.Time("write", () => new CSharpWriter(grammar, file, genDir).Write());
        }

    }
}
