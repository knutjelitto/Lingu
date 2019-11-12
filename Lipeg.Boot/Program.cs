using System;

using Lipeg.SDK.Common;
using Lipeg.Runtime;
using Lipeg.Runtime.Tools;
using Lipeg.SDK.Dump;
using Lipeg.SDK.Checkers;

namespace Lipeg.Boot
{
    internal class Program
    {
        internal static void Main()
        {
            Console.WriteLine("Hello World!");

            Build("lipeg.lpg");
            GC.Collect(3, GCCollectionMode.Forced);

            Console.Write("(almost) any key ... ");
            Console.ReadKey(true);
        }

        private static void Build(string grammarFile)
        {
            var projectDir = DirRef.ProjectDir();
            var grammarDir = projectDir.Dir("Grammars");
            var debugOut = projectDir.Dir("DebugOut");

            var lpgGrammar = grammarDir.File(grammarFile);


            Environment.CurrentDirectory = debugOut;

            var results = new CompileResult();

            var source = Source.FromFile(results, lpgGrammar);

            if (!results.HasErrors && source != null)
            {
                var parser = new LipegParser(source);

                var parseTree = Timer.TimeColdWarm(4, 5, "parse", () => parser.Parse(source.ToString(), lpgGrammar));

                Dumper.Dump(debugOut.File(lpgGrammar.FileName).Add(".nodes"), new DumpNodes(), parseTree);

                var grammarBuilder = new GrammarBuilder();

                var grammar = Timer.TimeColdWarm(4, 5, "build tree", () => grammarBuilder.Build(parseTree));

                Semantic semantic;

                semantic = Timer.TimeColdWarm(4, 5, "check tree", () =>
                {
                    var results = new CompileResult();
                    var semantic = new Semantic(grammar, results);
                    Checker.Check(semantic);
                    return semantic;
                });

                if (!semantic.Results.HasErrors)
                {

                    semantic = Timer.TimeColdWarm(4, 5, "build outcome", () =>
                    {
                        var results = new CompileResult();
                        var semantic = new Semantic(grammar, results);
                        Builder.Build(semantic);
                        return semantic;
                    });

                    Dumper.Dump(debugOut.File(lpgGrammar.FileName).Add(".tree"), new DumpTree(), semantic);
                }

                if (semantic.Results.HasErrors)
                {
                    semantic.Results.Report(Console.Out);
                }
            }
        }
    }
}
