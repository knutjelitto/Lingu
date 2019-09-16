using System.Collections.Generic;
using Lingu.LR;
using Lingu.Tree;
using Lingu.Writers;

namespace Lingu.Grammars
{
    public class Grammar : Symbol
    {
        public Grammar(string name)
            : base(name)
        {
            Options = new OptionList();
            Optionator = new Optionator(this);

            Terminals = new TerminalList();
            Nonterminals = new NonterminalList();
            Productions = new List<Production>();
            ItemSets = new List<ItemSet>();


        }


        public Nonterminal Start => Optionator.Start;
        public Terminal Separator => Optionator.Separator;
        public Terminal Newline => Optionator.Newline;
        public Terminal Keywords => Optionator.Keywords;

        public OptionList Options { get; }
        public Optionator Optionator { get; } 
        public TerminalList Terminals { get; }
        public NonterminalList Nonterminals { get; }
        public List<Production> Productions { get; }
        public List<ItemSet> ItemSets { get; }

        public override void Dump(IndentWriter output)
        {
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
