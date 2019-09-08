using Hime.SDK;
using Hime.SDK.Output;
using Mean.Maker.Builders;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Lingu.Bootstrap
{
    public class Program
    {
        private static string projectDir;

        static void Main(string[] args)
        {
            var program = new Program();

            program.Check();
            program.BuildTree("Expression");

            Console.Write("(almost) any key ... ");
            Console.ReadKey(true);
        }

        private void Check()
        {
            var xxx = Assembly.GetExecutingAssembly().GetManifestResourceNames();
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
    }
}
