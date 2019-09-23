using System.Collections.Generic;
using Lingu.LR;

#nullable enable

namespace Lingu.Grammars
{
    public class Grammar : Symbol
    {
        public Grammar(string name)
            : base(name)
        {
            OptionList = new OptionList();
            Options = new OptionsMaker(this);

            Terminals = new TerminalList();
            Nonterminals = new NonterminalList();

            Productions = new List<Production>();
            PSymbols = new List<Symbol>();

            LR0Sets = new LR0SetSet();
            LR1Sets = new LR1SetSet();

            ItemFactory = new CoreFactory();
        }

        public OptionList OptionList { get; }
        public OptionsMaker Options { get; } 
        public TerminalList Terminals { get; }
        public NonterminalList Nonterminals { get; }
        public List<Production> Productions { get; }
        public List<Symbol> PSymbols { get; }

        public Nonterminal? Accept { get; set; }
        public Terminal? Eof { get; set; }
        public LR0SetSet LR0Sets { get; }
        public LR1SetSet LR1Sets { get; }
        public CoreFactory ItemFactory { get; }
        public Cell[,]? Table { get; set; }

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
