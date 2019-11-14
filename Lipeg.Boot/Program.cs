using System;

using Lipeg.SDK.Common;
using Lipeg.Runtime;
using Lipeg.Runtime.Tools;
using Lipeg.SDK.Dump;
using Lipeg.SDK.Checkers;
using System.Diagnostics;

namespace Lipeg.Boot
{
    internal class Program
    {
        internal static void Main()
        {
            Build("lipeg.lpg");
            GC.Collect(2, GCCollectionMode.Forced);

            Console.Write("(almost) any key ... ");
            Console.ReadKey(true);
        }

        private static void Build(string grammarFilename)
        {
            var projectDir = DirRef.ProjectDir();
            var grammarDir = projectDir.Dir("Grammars");
            var debugDir = projectDir.Dir("DebugOut");

            var grammarFile = grammarDir.File(grammarFilename);

            Environment.CurrentDirectory = debugDir;

            var results = new CompileResult();

            var source = Source.FromFile(results, grammarFile);

            if (!results.HasErrors && source != null)
            {
                var parser = new LipegParser(source);

                var parseTree = parser.Parse(source.ToString(), grammarFile);

                Dumper.Dump(debugDir.File(grammarFile.FileName).Add(".nodes"), new DumpNodes(), parseTree);

                var grammarBuilder = new GrammarBuilder();

                var grammar = grammarBuilder.Build(parseTree);

                var semantic = new Semantic(grammar, results);

                Checker.Check(semantic);

                if (!results.HasErrors)
                {
                    Builder.Build(semantic);

                    Dumper.Dump(debugDir.File(grammarFile.FileName).Add(".tree"), new DumpTree(), semantic);
                }

                if (results.HasErrors)
                {
                    results.Report(Console.Out);
                }
            }
        }
    }
}
