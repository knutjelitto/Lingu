using LinParseTests.Builders;
using Lipeg.Runtime.Tools;
using System;
using System.IO;

namespace LinParseTests
{
    class Program
    {
        static void Main(string[] args)
        {
            var runner = new Runner();

            var thisProject = DirRef.ProjectDir();
            var temp = thisProject.Up.Up.Dir("Temp");

            if (!temp.Exists)
            {
                throw new InvalidOperationException();
            }

            Environment.CurrentDirectory = temp;

            var jsonTestSuite = "JSONTestSuite";

            if (!temp.Dir(jsonTestSuite).Dir(".git").Exists)
            {
                runner.Run("git", "git", "clone https://github.com/nst/JSONTestSuite.git --progress");
                Environment.CurrentDirectory = temp.Dir(jsonTestSuite);
            }
            else
            {
                Environment.CurrentDirectory = temp.Dir("JSONTestSuite");
                runner.Run("git", "git", "pull --progress");
            }

            var cases = temp.Dir(jsonTestSuite).Dir("test_parsing");
            foreach (var testCase in cases.Files())
            {
                if (testCase.FileName.StartsWith("i_"))
                {
                    Test(testCase, LinParse.JsonCheck.Outcome.Indifferent);
                }
                if (testCase.FileName.StartsWith("n_"))
                {
                    Test(testCase, LinParse.JsonCheck.Outcome.Fail);
                }
                if (testCase.FileName.StartsWith("y_"))
                {
                    Test(testCase, LinParse.JsonCheck.Outcome.Succeed);
                }
            }

            void Test(FileRef testCase, LinParse.JsonCheck.Outcome outcome)
            {
                Console.Write($"{testCase.FileName}");
                var ok = LinParse.JsonCheck.Run(testCase, outcome);
                var indication = ok ? "OK" : "FAIL";
                Console.WriteLine($"\r{indication} {testCase.FileName}");
            }

            Console.Write("(almost) any key ... ");
            Console.ReadKey(true);
        }
    }
}
