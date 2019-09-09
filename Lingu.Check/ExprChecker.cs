using System;
using System.Diagnostics;
using Lingu.Earley;
using Lingu.GrammarsOld;
using Lingu.Samples.Expr;

namespace Lingu.Check
{
    public class ExprChecker
    {
        public void Check()
        {
            var grammar = ExprGrammar.Create();
            var plumber = new GrammarPlumber(grammar);
            plumber.Dump(Console.Out);

            var engine = new EarleyEngine(grammar);
            var driver = new EarleyDriver(engine, "1+(2*3-4)");

            while (driver.Next())
            {
                Debug.Assert(true);
            }
        }
    }
}