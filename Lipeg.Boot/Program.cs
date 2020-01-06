using System;
using System.Diagnostics;
using Lipeg.Runtime;
using Lipeg.Runtime.Tools;
using Lipeg.SDK.Dump;
using Lipeg.SDK.Checkers;
using System.Linq;

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

            var results = new CompileResult();

            var source = Source.FromFile(results, grammarFile);

            if (!results.HasErrors && source != null)
            {
                var parser = new LipegParser(source);

                var parseTree = parser.Parse(source.ToString(), grammarFile);

                Dumper.Dump(debugDir.File(grammarFile.FileName).Add(".nodes"), new DumpNodes(), Enumerable.Repeat(parseTree, 1));

                var grammarBuilder = new GrammarBuilder();

                var grammar = grammarBuilder.Build(parseTree);

                var semantic = new Semantic(grammar, results);

                AChecker.Check(semantic);

                if (!results.HasErrors)
                {
                    Builder.BuildParser(semantic);

                    Dumper.Dump(debugDir.File(grammarFile.FileName).Add(".ast"), new DumpAst(), semantic);

                    var combiParser = semantic.Grammar.Attr(semantic).Parser;

                    Dumper.Dump(debugDir.File(grammarFile.FileName).Add(".parser"), new DumpParsers(), semantic);

                    source = Source.FromFile(results, testFile);
                    Debug.Assert(source != null);

                    var start = DContext.Start(source);
                    
                    var result = combiParser.Parse(start);

                    Console.WriteLine($"{result}");

                    if (result.IsSuccess)
                    {
                        Builder.BuildAst(results, result.Nodes[0]);
                        Dumper.Dump(debugDir.File(testFile.FileName).Add(".boot.nodes"), new DumpNodes(), result.Nodes);
                    }
                    else
                    {
                        Console.WriteLine($"farthest:{SDK.Parsers.Result.FarthestFail}");
                    }
                }

                if (results.HasAny)
                {
                    results.Report(Console.Out);
                }
            }
        }
    }
}
