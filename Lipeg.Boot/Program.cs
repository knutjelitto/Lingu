using System;

using Lipeg.SDK.Common;
using Lipeg.Runtime;
using Lipeg.Runtime.Tools;
using Lipeg.SDK.Dump;
using Lipeg.SDK.Checking;

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


            if (!results.ShouldStop && source != null)
            {

                var parser = new LipegParser(source);

                var parseTree = Timer.TimeBoth(16, "parse", () => parser.Parse(source.ToString(), lpgGrammar));

                var parseTreeFile = debugOut.File(lpgGrammar.FileName).Add(".tree");
                Dumper.Dump(parseTreeFile, new DumpParseTree(), parseTree);

                var grammarBuilder = new GrammarBuilder();

                var grammar = Timer.TimeBoth(16, "build tree", () => grammarBuilder.Build(parseTree));

                var semantic = new Semantic(grammar, results);

                Checker.Check(semantic);
            }

            if (results.HasErrors)
            {
                foreach (var error in results.Errors)
                {
                    Console.WriteLine($"{error.Code}: {error.Message}");
                }
            }

        }
    }
}
