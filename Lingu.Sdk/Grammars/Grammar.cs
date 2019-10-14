using System.Collections.Generic;
using System.Linq;
using Lingu.Automata;
using Lingu.LR;
using Lingu.Runtime.Lexing;
using Lingu.Runtime.Parsing;

#nullable enable

namespace Lingu.Grammars
{
    public class Grammar : Symbol
    {
        public static readonly string GeneratedTerminalPrefix = "__T";
        public static readonly string GeneratedNonterminalPrefix = "__N";

        public Grammar(string name)
            : base(name)
        {
            OptionList = new OptionList();
            Options = new OptionsMaker(this);

            Terminals = new TerminalList();
            Nonterminals = new NonterminalList();

            Productions = new List<Production>();

            LR0Sets = new LR0SetSet();
            LR1Sets = new LR1SetSet();

            CoreFactory = new CoreFactory();
        }

        public OptionList OptionList { get; }
        public OptionsMaker Options { get; } 
        public TerminalList Terminals { get; }
        public NonterminalList Nonterminals { get; }
        public List<Production> Productions { get; }

        public IReadOnlyList<Symbol>? Symbols { get; set; }
        public IReadOnlyList<Symbol>? PSymbols { get; set; }

        public Nonterminal? Accept { get; set; }
        public FA? SpacingDfa { get; set; }

        public IReadOnlyList<int>? StateToDfa { get; set; }
        public IReadOnlyList<FA>? Dfas { get; set; }
        public Terminal? Eof { get; set; }
        public LR0SetSet LR0Sets { get; }
        public LR1SetSet LR1Sets { get; }
        public CoreFactory CoreFactory { get; }
        public TableCell[,]? Table { get; set; }
        public U16ParseTable? ParseTable { get; set; }

        public string NextTerminalName()
        {
            return $"{GeneratedTerminalPrefix}{nextTerminalId++}";
        }

        public string NextNonterminalName()
        {
            return $"{GeneratedNonterminalPrefix}{nextNonterminalId++}";
        }

        private int nextTerminalId = 1;
        private int nextNonterminalId = 1;
    }
}
