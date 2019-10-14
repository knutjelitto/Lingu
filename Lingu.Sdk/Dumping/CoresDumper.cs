using Lingu.Grammars;
using Lingu.Output;

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
