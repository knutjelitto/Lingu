using System;
using System.Diagnostics;
using Lingu.Earley;
using Lingu.GrammarsOld;
using Lingu.Samples.Expr;

namespace Lingu.Check
{
    public class AmbiChecker
    {
        public void Check()
        {
            var grammar = AmbiGrammar.Create();
            var plumber = new GrammarPlumber(grammar);
            plumber.Dump(Console.Out);

            var engine = new EarleyEngine(grammar);
            var driver = new EarleyDriver(engine, "......");

            while (driver.Next())
            {
                Debug.Assert(true);
            }
        }
    }
}