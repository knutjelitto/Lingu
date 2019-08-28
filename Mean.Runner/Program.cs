using System;
using System.IO;
using Clean.Sources;
using Mean.Language;

using Mean.Maker;
using Mean.Maker.Builders;
using Mean.Tree;
using Mean.Tree.Items;

namespace Mean.Runner
{
    public static class Program
    {
        static void Main(string[] args)
        {
            new SourceProvider().Provide(Builder.BuildTop);
            Directory.SetCurrentDirectory(Builder.BuildTop);

            CompileTest(FileRef.Source("test.mean"));

            //CheckPackage();
            //CheckExpression();
            //DumpTree();
            //Dump();

            Console.Write("(almost) any key ...");
            Console.ReadKey(true);
        }

        private static void CompileTest(FileRef source)
        {
            var result = Parser.Unit(source);

            if (!result.IsSuccess)
            {
                foreach (var error in result.Errors)
                {
                    Console.WriteLine($"{error}");
                }
            }
            else
            {
                var global = new Global();
                var builder = new UnitBuilder(global);
                var unit = builder.Visit(result);
            }
        }

        private static void Dump()
        {
            Checker.Dump("namespace test {  }", Parser.Unit);
        }

        private static void DumpTree()
        {
            Checker.DumpTree("namespace test {  }", Parser.Unit);
        }

        private static void CheckPackage()
        {
            Checker.Check("scope test {  }", Parser.Unit);
        }

        private static void CheckExpression()
        {
            Checker.Check("22", Parser.Expression);
            Checker.Check("22.0", Parser.Expression);
            Checker.Check("x.2_0", Parser.Expression);
            Checker.Check("a<b>.x<y,a=b>.z.0.u<v>(x)", Parser.Expression);
            Checker.Check("a<x>[b].c<z>", Parser.Expression);
            Checker.Check("a[b][c].f(x) > 2", Parser.Expression);
            Checker.Check("1 < 2 < 3", Parser.Expression);
            Checker.Check("2 + 3 * 4", Parser.Expression);
            Checker.Check("2 * 3 + 4", Parser.Expression);
            Checker.Check("2 * 3 * 4", Parser.Expression);
            Checker.Check("2 + 3 + 4", Parser.Expression);
        }
    }
}
