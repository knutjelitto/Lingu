using System;
using System.Diagnostics;
using Lipeg.Runtime;
using Lipeg.Runtime.Tools;
using Lipeg.SDK.Dump;
using Lipeg.SDK.Checkers;
using System.Linq;
using Lipeg.SDK.Tree;
using Lipeg.SDK;

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
            DirRef debugDir = projectDir.Dir("DebugOut");

            var grammarFile = grammarDir.File(grammarFilename);
            var testFile = grammarDir.File(testFilename);

            Environment.CurrentDirectory = debugDir;

            var results = new CompileResult();

            var source = Source.FromFile(results, grammarFile);

            if (!results.HasErrors && source != null)
            {
                IParser parser = new LipegParser(source);

                var start = DContext.Start(source);

                IResult parseTree = parser.Parse(start);

                Dumper.Dump(debugDir.File(grammarFile.FileName).Add(".nodes"), new DumpNodes(), parseTree.Nodes);

                IGrammarBuilder grammarBuilder = new GrammarBuilder();

                Grammar grammar = grammarBuilder.Build(parseTree.Nodes[0]);

                var semantic = new Semantic(grammar, results);

                AChecker.Check(semantic);

                if (!results.HasErrors)
                {
                    Dumper.Dump(debugDir.File(grammarFile.FileName).Add(".lpg"), new DumpPpGrammar(), semantic);

                    Builder.BuildParser(semantic);

                    parser = semantic.Grammar.Attr(semantic).Parser;

                    Dumper.Dump(debugDir.File(grammarFile.FileName).Add(".parser"), new DumpParsers(), semantic);
                    
                    results = new CompileResult();

                    source = Source.FromFile(results, testFile);

                    Debug.Assert(source != null);

                    start = DContext.Start(source);
                    
                    var result = parser.Parse(start);

                    Console.WriteLine($"{result}");

                    if (result.IsSuccess)
                    {
                        Dumper.Dump(debugDir.File(testFile.FileName).Add(".boot.nodes"), new DumpNodes(), result.Nodes);

                        grammar = Builder.BuildAst(results, result.Nodes[0]);

                        semantic = new Semantic(grammar, results);

                        AChecker.Check(semantic);

                        Dumper.Dump(debugDir.File(grammarFile.FileName).Add(".boot.lpg"), new DumpPpGrammar(), semantic);

                        Builder.BuildParser(semantic);

                        Dumper.Dump(debugDir.File(grammarFile.FileName).Add(".boot.parser"), new DumpParsers(), semantic);
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
