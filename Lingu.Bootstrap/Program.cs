using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

using Lingu.Dumping;
using Lingu.Runtime.Concretes;
using Mean.Maker.Builders;

namespace Lingu.Bootstrap
{
    public class Program
    {
        private static string projectDir;

        static void Main(string[] args)
        {
            var program = new Program();

            program.Check();
            //program.BuildTree("S1");
            //program.BuildTree("Lingu");
            //program.BuildTree("G1");
            //program.BuildTree("Wiki");
            program.BuildTree("Expression");
            //program.BuildTree("Boot");
            //program.BuildTree("Expr");

            Console.Write("(almost) any key ... ");
            Console.ReadKey(true);
        }

        private void Check()
        {
        }

        private void BuildTree(string stem)
        {
            Environment.CurrentDirectory = $"{ProjectDir}Grammar";

            var source = FileRef.Source($"{ProjectDir}Grammar/{stem}.Grammar");

            var dests = source.With(".Out");

            var raw = Parser.Parse(source);

            if (raw != null)
            {
                var builder = new Build.Builder(raw);

                var grammar = builder.Build();
                new Dumper(grammar).Dump(dests);

                var context = new LinguContext(
                    grammar.Symbols,
                    grammar.Productions,
                    grammar.ParseTable,
                    grammar.CommonDfa ?? throw new ArgumentNullException(nameof(grammar.CommonDfa)),
                    grammar.WhitespaceDfa ?? throw new ArgumentNullException(nameof(grammar.WhitespaceDfa)));

                context.Try("   a+b");
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
