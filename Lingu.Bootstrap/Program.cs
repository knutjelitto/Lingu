using Hime.SDK;
using Hime.SDK.Output;
using Mean.Maker.Builders;
using System;
using System.IO;
using System.Linq;

namespace Lingu.Bootstrap
{
    public class Program
    {
        private static string projectDir;

        static void Main(string[] args)
        {
            var program = new Program();

            program.Build();
            program.BuildTree("Expression");

            Console.Write("(almost) any key ... ");
            Console.ReadKey(true);
        }

        private void BuildTree(string stem)
        {
            Environment.CurrentDirectory = $"{ProjectDir}Grammar";

            var source = FileRef.Source($"{ProjectDir}Grammar/{stem}.Grammar");

            var dests = source.With(".Out");

            var grammar = Parser.Parse(source);

            if (grammar != null)
            {
                var builder = new Build.Builder(grammar);

                builder.Check();
                builder.Build();
                builder.Dump(dests);
            }
        }

        private void Build()
        {
            var options = new HimeTaskOptions
            {
                Public = true,
                Namespace = "Lingu.Bootstrap",
                //RNGLR = true,
                Debug = true,
                Grammar = "Lingu",
            };

            Environment.CurrentDirectory = $"{ProjectDir}Grammar";

            var source = FileRef.Source($"{ProjectDir}Grammar/Lingu.HimeGrammar");
            var parser = FileRef.Source($"{ProjectDir}Grammar/LinguParser.cs");
            var visitor = FileRef.Source($"{ProjectDir}Grammar/LinguVisitor.cs");

            if (source.NewerThan(parser))
            {
                Generate(options, source);

                var grammar = FileRef.Source($"{ProjectDir}Grammar/");

                var tweaker = new Tweaker(parser, visitor);
                Console.WriteLine($"[Info] Tweaking new Visitor at {visitor.File} ...");
                tweaker.Tweak();
            }
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
    }
}
