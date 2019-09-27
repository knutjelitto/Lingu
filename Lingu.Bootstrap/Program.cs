using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

using Lingu.Dumping;
using Lingu.Runtime.Concretes;
using Lingu.Runtime.Sources;
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
            //program.BuildTree("S1", "1+2");
            //program.BuildTree("S2", "grammar s2 { }");
            //program.BuildTree("S3", "grammar s3 { a = b, b = c, c = d, d = a}");
            //program.BuildTree("S4", "' '");
            //program.BuildTree("Lingu", "grammar x {}");
            program.BuildTree("Lingu", FileRef.Source($"./S4.Grammar"));
            //program.BuildTree("Lingu", "grammar x {}");
            //program.BuildTree("G1");
            //program.BuildTree("Wiki");
            //program.BuildTree("Expression", "(1+2)*3");
            //program.BuildTree("Expr", "(1+2)*3");

            Console.Write("(almost) any key ... ");
            Console.ReadKey(true);
        }

        private void Check()
        {
        }

        private void BuildTree(string stem, string content)
        {
            Environment.CurrentDirectory = $"{ProjectDir}Grammar";

            var grammarSource = FileRef.Source($"./{stem}.Grammar");

            var dests = FileRef.Source(grammarSource.Directory + "/Out/" + grammarSource.BaseName).With(".Out");

            var raw = Parser.Parse(grammarSource);

            if (raw != null)
            {
                var builder = new Build.Builder(raw);

                var grammar = builder.Build();
                new Dumper(grammar).Dump(dests);

                Debug.Assert(grammar.Eof != null);

                var context = new LinguContext(
                    grammar.Symbols,
                    grammar.Eof,
                    grammar.Productions,
                    grammar.ParseTable,
                    grammar.CommonDfa ?? throw new ArgumentNullException(nameof(grammar.CommonDfa)),
                    grammar.WhitespaceDfa ?? throw new ArgumentNullException(nameof(grammar.WhitespaceDfa)));

                Source source;

                if (File.Exists(content))
                {
                    source = Source.FromFile(content);
                }
                else
                {
                    source = Source.FromString(content);
                }

                var tree = context.Try(source);

                new TreeDumper(dests.Add(".Tree")).Dump(tree);
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
