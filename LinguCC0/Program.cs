using System;
using System.Diagnostics;
using Lingu.Build;
using Lingu.Commons;
using Lingu.Dumping;
using Lingu.Runtime.Lexing;
using Lingu.Runtime.Parsing;
using Lingu.Runtime.Sources;
using Lingu.Tree;
using Lingu.Write;

namespace Lingu.CC
{
    class Program
    {
        static void Main(string[] args)
        {
#if true
            BuildCC();
#else
            var bootStrap = DirRef.ProjectDir().Dir("..").Dir("Lingu.Bootstrap");

            var context = Timer.Time("context", LinguContext.CreateContext);

            var file = bootStrap.Dir("Grammar").File("Lingu.Grammar");

            var source = Timer.Time("source", () => Source.FromFile(file));

            var lexer = Timer.Time("lexer", () => new Lexer(context, source));

            var parser = Timer.Time("parser", () => new Parser(context, lexer));

            var parseTree = Timer.Time("parse", () => parser.Parse());

            var dumpFile = bootStrap.Dir("Grammar").Dir("Out").File("Lingu.Out.NewTree");
            var dumper = new TreeDumper(dumpFile);
            dumper.Dump(parseTree);

            var rawGrammar = Timer.Time("ast", () => new TreeBuilder().Visit(parseTree));

            var builder = new Builder(rawGrammar);

            var grammar = Timer.Time("build", builder.Build);
#endif
#if false
            Console.Write("press (almost) any key ... ");
            Console.ReadKey(true);
#endif
        }


        private static void BuildCC()
        {
            var projectDir = DirRef.ProjectDir();
            var linguCC = projectDir.Dir("..").Dir("LinguCC");
            var genDir = linguCC.Dir("Gen");

            Environment.CurrentDirectory = genDir;

            var file = FileRef.From("./Lingu.Grammar");
            var outs = FileRef.From("./Lingu").Add(".Out");

            var context = Timer.Time("context", LinguContext.CreateContext);

            var source = Timer.Time("source", () => Source.FromFile(file));

            var lexer = Timer.Time("lexer", () => new Lexer(context, source));

            var parser = Timer.Time("parser", () => new Parser(context, lexer));

            var parseTree = Timer.Time("parse", () => parser.Parse());

            new TreeDumper(outs.Add(".Tree")).Dump(parseTree);
            
            var ast = Timer.Time("ast", () => new TreeBuilder().Visit(parseTree));

            var grammar = Timer.Time("build", () => new GrammarBuilder(ast).Build());

            new Dumper(grammar).Dump(outs);

            Timer.Time("write", () => new CSharpWriter(grammar, genDir).Write());
        }

    }
}
