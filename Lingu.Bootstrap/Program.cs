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

            program.Run();
            Console.Write("(almost) any key ... ");
            Console.ReadKey(true);
        }

        private void Run()
        {
            var options = new TaskOptions
            {
                Public = true,
                Namespace = "Lingu.Bootstrap",
                //RNGLR = true,
                Debug = true,
            };

            Environment.CurrentDirectory = $"{ProjectDir}Grammar";

            var source = FileRef.Source($"{ProjectDir}Grammar/Lingu.Grammar");

            Generate(options, source);

            var grammar = FileRef.Source($"{ProjectDir}Grammar/");
            var parser = FileRef.Source($"{ProjectDir}Grammar/LinguParser.cs");
            var visitor = FileRef.Source($"{ProjectDir}Grammar/LinguVisitor.cs");

            var tweaker = new Tweaker(parser, visitor);
            Console.WriteLine($"[Info] Tweaking new Visitor at {visitor.ToString().Substring(grammar.ToString().Length)} ...");
            tweaker.Tweak();
        }

        private Report Generate(TaskOptions options, params string[] grammarInputs)
        {
            var task = BuildTask(options);
            foreach (var input in grammarInputs)
            {
                AddInput(task, input);
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

        private static CompilationTask BuildTask(TaskOptions options)
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

        /// <summary>
        /// Adds an input to a compilation task
        /// </summary>
        /// <param name="task">The compilation task</param>
        /// <param name="inputFile">The input as a parsed data in the command line</param>
        private static void AddInput(CompilationTask task, string inputFile)
        {
            if (inputFile == null)
                return;
            if (inputFile.StartsWith("\""))
                inputFile = inputFile.Substring(1, inputFile.Length - 2);
            task.AddInputFile(inputFile);
        }
    }
}
