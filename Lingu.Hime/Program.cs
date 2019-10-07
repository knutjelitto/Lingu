using Hime.SDK;
using Hime.SDK.Output;
using System;
using System.IO;
using System.Linq;
using Lingu.Commons;

namespace Lingu.Hime
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var program = new Program();

            program.Build();

            Console.Write("(almost) any key ... ");
            Console.ReadKey(true);
        }

        private void Build()
        {
            var options = new HimeTaskOptions
            {
                Public = true,
                Namespace = "Lingu.Bootstrap.Hime",
                //RNGLR = true,
                Debug = true,
                Grammar = "Lingu",
            };

            Environment.CurrentDirectory = $"{ProjectDir}";

            var source = FileRef.From($"{ProjectDir}Lingu.Grammar");
            var parser = FileRef.From($"{ProjectDir}LinguParser.cs");
            var lexer = FileRef.From($"{ProjectDir}LinguLexer.cs");
            var visitor = FileRef.From($"{ProjectDir}LinguVisitor.cs");

            Generate(options, source);

            var tweaker = new Tweaker(parser, visitor);
            Console.WriteLine($"[Info] Tweaking new Visitor at {visitor.FileName} ...");
            tweaker.TweakVisitor();
            tweaker.TweakLexer(lexer);
            tweaker.TweakParser(parser);
        }

        private Report Generate(HimeTaskOptions options, params FileRef[] grammarInputs)
        {
            var task = BuildTask(options);
            foreach (var input in grammarInputs)
            {
                task.AddInputFile(input);
            }

            var report = task.Execute();

            return report;
        }

        private string ProjectDir
        {
            get
            {
                if (projectDir == null)
                {
                    var cwd = Environment.CurrentDirectory;

                    while (Directory.Exists(cwd) && !Directory.EnumerateFiles(cwd, "*.csproj").Any())
                    {
                        cwd = Path.GetDirectoryName(cwd);
                    }

                    projectDir = cwd.Replace(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar) + "/";
                }
                return projectDir;
            }
        }

        private static CompilationTask BuildTask(HimeTaskOptions options)
        {
            CompilationTask task = new CompilationTask();

            if (options.Assembly)
            {
                task.Mode = Mode.SourceAndAssembly;
            }
            if (options.Debug)
            {
                task.Mode = Mode.Debug;
            }
            if (!string.IsNullOrEmpty(options.Grammar))
            {
                task.GrammarName = options.Grammar;
            }
            if (!string.IsNullOrEmpty(options.OutputPath))
            {
                task.OutputPath = options.OutputPath;
            }
            if (!string.IsNullOrEmpty(options.Namespace))
            {
                task.Namespace = options.Namespace;
            }
            if (options.RNGLR)
            {
                task.Method = ParsingMethod.RNGLALR1;
            }
            if (options.Public)
            {
                task.CodeAccess = Modifier.Public;
            }

            return task;
        }

        private static string projectDir;
    }
}
