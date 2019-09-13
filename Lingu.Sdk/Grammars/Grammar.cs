using System.Collections.Generic;

using Lingu.Tree;
using Lingu.Writers;

namespace Lingu.Grammars
{
    public class Grammar : Symbol
    {
        public Grammar(string name)
            : base(name)
        {
            Options = new Options();
            Optionator = new Optionator(this);

            Terminals = new Terminals();
            Nonterminals = new Nonterminals();
            Productions = new List<Production>();
        }


        public Nonterminal Start => Optionator.Start;
        public Terminal Separator => Optionator.Separator;
        public Terminal Newline => Optionator.Newline;
        public Terminal Keywords => Optionator.Keywords;

        public Options Options { get; }
        public Optionator Optionator { get; } 
        public Terminals Terminals { get; }
        public Nonterminals Nonterminals { get; }
        public List<Production> Productions { get; }

        public override void Dump(IndentWriter output, bool top)
        {
            throw new System.NotImplementedException();
        }

        public string NextTerminalName()
        {
            return $"__T{nextTerminalId++}";
        }

        public string NextNonterminalName()
        {
            return $"__N{nextNonterminalId++}";
        }

        private int nextTerminalId = 1;
        private int nextNonterminalId = 1;
    }
}
