using System;
using System.Diagnostics;

using Lipeg.Runtime;
using Lipeg.Runtime.Tools;
using Lipeg.SDK;
using Lipeg.SDK.Builders;
using Lipeg.SDK.Dump;
using Lipeg.SDK.Checkers;
using Lipeg.SDK.Tree;

namespace Lipeg.Boot
{
    internal class Program
    {
        internal static void Main()
        {
            RamboBuild("lipeg.lpg", "lipeg.lpg");
            GC.Collect(2, GCCollectionMode.Forced);

            Console.Write("(almost) any key ... ");
            Console.ReadKey(true);
        }

        private static void RamboBuild(string grammarFilename, string testFilename)
        {
            var projectDir = DirRef.ProjectDir();
            var grammarDir = projectDir.Dir("Grammars");
            var debugDir = projectDir.Dir("DebugOut");

            var grammarFile = grammarDir.File(grammarFilename);
            var testFile = grammarDir.File(testFilename);

            Environment.CurrentDirectory = debugDir;

            try
            {
                var outFile = debugDir.File(grammarFile.FileName);

                var parser = Parse(grammarFile, outFile, LipegParser.From(), root => new GrammarBuilder().Build(root));

                for (var i = 0; i < 1; ++i)
                {
                    Debug.Assert(parser != null);

                    outFile = outFile.Add(".boot");

                    parser = Timer.Time("p-a-p", () => Parse(testFile, outFile, parser, Builder.BuildAst));
                }

            }
            catch (MessageException e)
            {
                var results = new CompileResult();
                results.AddError(e.Msg);
                results.Report(Console.Out);
            }
        }

        private static IParser? Parse(FileRef sourceFile, FileRef debugFile, IParser parser, Func<INode, Grammar> aster)
        {
            if (debugFile == null) throw new ArgumentNullException(nameof(debugFile));
            var source = Source.FromFile(sourceFile);

            var parseTree = parser.Parse(source.Start());

            //Console.WriteLine($"{parseTree.IsSuccess}");
            //Console.WriteLine($"{parseTree}");

            if (parseTree.IsSuccess)
            {
                Dumper.Nodes(debugFile.Add(".nodes"), parseTree.Nodes);

                var grammar = aster(parseTree.Nodes[0]);

                Checker.Check(grammar);

                if (!grammar.Results.HasAny)
                {

                    Dumper.Pretty(debugFile.Add(".lpg"), grammar);

                    parser = Builder.BuildParser(grammar);

                    Builder.BuildSource(grammar, debugFile.Add(".g.cs"));

                    Dumper.Parsers(debugFile.Add(".parser"), grammar);

                    return parser;
                }

                grammar.Results.Report(Console.Out);
            }
            else
            {
                Console.WriteLine($"farthest:{SDK.Parsers.Result.FarthestFail}");
            }

            return null;
        }
    }
}
