using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Lingu.Commons;
using Lingu.Dumping;
using Lingu.Runtime.Concretes;
using Lingu.Runtime.Lexing;
using Lingu.Runtime.Sources;
using Lingu.Write;

namespace Lingu.Bootstrap
{
    public class Program
    {
        static void Main(string[] args)
        {
            var program = new Program();

#if true
            program.BuildCC0();
#else
            //program.BuildTree("S1", "1+2");
            //program.BuildTree("S2", "grammar s2 { }");
            //program.BuildTree("S3", "grammar s3 { a = b, b = c, c = d, d = a}");
            //program.BuildTree("S4", @"'\\'");
            //program.BuildTree("S5", @"aaa");
            //program.BuildTree("Lingu", "grammar x {}");
            //program.BuildTree("Lingu", FileRef.Source($"./S4.Grammar"));
            program.BuildTree("Lingu", FileRef.From($"./Lingu.Grammar"));
            //program.BuildTree("Lingu", "grammar x {}");
            //program.BuildTree("G1");
            //program.BuildTree("Wiki");
            //program.BuildTree("Expression", "(1+2)*3");
            //program.BuildTree("Expr", "(1+2)*3");
#endif

#if true
            Console.Write("(almost) any key ... ");
            Console.ReadKey(true);
#endif
        }


        private void BuildCC0()
        {
            var projectDir = DirRef.ProjectDir();
            var cc0 = projectDir.Dir("..").Dir("LinguCC0");
            var genDir = cc0.Dir("Gen");

            Environment.CurrentDirectory = genDir;

            var grammarSource = FileRef.From($"./Lingu.Grammar");

            var outs = FileRef.From("./Lingu").Add(".Out");

            var raw = Parser.Parse(grammarSource);

            var builder = new Build.GrammarBuilder(raw);

            var grammar = builder.Build();
            new Dumper(grammar).Dump(outs);

            var csharp = new CSharpWriter(grammar, genDir);
            csharp.Write();
        }

        private void BuildTree(string stem, string content)
        {
            Environment.CurrentDirectory = DirRef.ProjectDir().Dir("Grammar");

            var grammarSource = FileRef.From($"./{stem}.Grammar");

            var dests = FileRef.From(grammarSource.Directory + "/Out/" + grammarSource.BaseName).With(".Out");

            var raw = Parser.Parse(grammarSource);

            if (raw != null)
            {
                var builder = new Build.GrammarBuilder(raw);

                var grammar = builder.Build();
                new Dumper(grammar).Dump(dests);

                var ccOut = DirRef.ProjectDir().Dir("..").Dir("Lingu.CC").Dir("Gen");

                var csharp = new CSharpWriter(grammar, ccOut);
                csharp.Write();

                Debug.Assert(grammar.Eof != null);
                Debug.Assert(grammar.SpacingDfa != null);
                Debug.Assert(grammar.Dfas != null);
                Debug.Assert(grammar.StateToDfa != null);

                var dfaSet = new DfaSet(grammar.Dfas.Select(dfa => dfa.Convert()).ToArray(), grammar.StateToDfa, grammar.SpacingDfa.Convert());

                var context = new LinguContext(
                    grammar.Symbols,
                    grammar.Productions,
                    grammar.ParseTable,
                    dfaSet);

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
    }
}
