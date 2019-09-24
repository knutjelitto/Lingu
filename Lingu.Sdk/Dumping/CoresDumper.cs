using Lingu.Grammars;
using Lingu.Writers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lingu.Dumping
{
    public class CoresDumper
    {
        public CoresDumper(Grammar grammar)
        {
            Grammar = grammar;
        }

        public Grammar Grammar { get; }

        public void Dump(IWriter writer)
        {
            foreach (var core in Grammar.CoreFactory)
            {
                writer.WriteLine($"{core}");
            }
        }

    }
}
