using System;
using System.Diagnostics;
using System.Linq;

using Lingu.Grammars;
using Lingu.LR;
using Lingu.Runtime.Parsing;

#nullable enable

namespace Lingu.Build
{
    public class SetsBuilder
    {
        public SetsBuilder(Grammar grammar)
        {
            Grammar = grammar;
        }

        public Grammar Grammar { get; }
        public CoreFactory CoreFactory => Grammar.ItemFactory;

        public void Build()
        {
            CoreFactory.Initialize(Grammar.Nonterminals.SelectMany(n => n.Productions).ToList());

            BuildFirstSets();
            BuildCoreFirstSets();

            BuildLR1Sets();
            BuildLR1Table();
            BuildSimpleParseTable();
        }

        private void BuildFirstSets()
        {
            foreach (var terminal in Grammar.Terminals)
            {
                terminal.First.Add(terminal);
            }
            foreach (var nonterminal in Grammar.Nonterminals)
            {
                foreach (var production in nonterminal.Productions)
                {
                    if (production.IsEpsilon)
                    {
                        nonterminal.First.WithEpsilon = true;
                    }
                }
            }

            var changed = true;
            while (changed)
            {
                changed = false;
                foreach (var nonterminal in Grammar.Nonterminals)
                {
                    foreach (var production in nonterminal.Productions)
                    {
                        var epsilons = 0;
                        foreach (var symbol in production.Symbols)
                        {
                            foreach (var terminal in symbol.First.ToList())
                            {
                                changed = changed || nonterminal.First.Add(terminal);
                            }
                            if (!symbol.First.WithEpsilon)
                            {
                                break;
                            }
                            epsilons += 1;
                        }
                        if (epsilons == production.Symbols.Count && !nonterminal.First.WithEpsilon)
                        {
                            nonterminal.First.WithEpsilon = true;
                            changed = true;
                        }
                    }
                }
            }
        }

        private void BuildCoreFirstSets()
        {
            foreach (var core in CoreFactory)
            {
                Debug.Assert(core.First.IsEmpty);
            }
            foreach (var core in CoreFactory)
            {
                var dot = core.Dot;
                for (; dot < core.Count; dot += 1)
                {
                    foreach (var terminal in core[dot].First)
                    {
                        core.First.Add(terminal);
                    }
                    if (!core[dot].First.WithEpsilon)
                    {
                        break;
                    }
                }

                if (dot == core.Count)
                {
                    core.First.WithEpsilon = true;
                }
            }
            foreach (var core in CoreFactory)
            {
                Debug.Assert(!core.First.IsEmpty);
            }
        }

        private void BuildLR0Sets()
        {
            Debug.Assert(Grammar.Accept != null);

            var start = new LR0(CoreFactory.Get(Grammar.Accept.Productions[0]), true);
            var startSet = new LR0Set(start);

            var goner = new LR0Set.Closer2(Grammar.LR0Sets, startSet);

            goner.Go();
        }

        private void BuildLR1Sets()
        {
            Debug.Assert(Grammar.Accept != null);
            Debug.Assert(Grammar.Eof != null);

            var start = new LR1(CoreFactory.Get(Grammar.Accept.Productions[0]), true, Grammar.Eof.First);
            var startSet = new LR1Set(start);

            var closer = new LR1Set.Closer2(Grammar.LR1Sets, startSet);
            closer.Go();
        }

        private void BuildLR1Table()
        {
            int states = Grammar.LR1Sets.Count;
            int symbols = Grammar.PSymbols.Count;

            var table = new Cell[states, symbols];

            foreach (var state in Grammar.LR1Sets)
            {
                foreach (LR1 item in state)
                {
                    if (item.IsComplete)
                    {
                        var prodId = item.Core.Production.Id;

                        foreach (var terminal in item.Lookahead)
                        {
                            if (ReferenceEquals(terminal, Grammar.Eof) && prodId == 0)
                            {
                                table[state.Id, terminal.Pid] = new Accept();
                            }
                            else
                            {
                                table[state.Id, terminal.Pid] = new Reduce(item.Core.Production.Id);
                            }
                        }
                    }
                    else if (item.PostDot is Terminal terminal)
                    {
                        table[state.Id, terminal.Pid] = new Shift(item.ToState);
                    }
                    else if (item.PostDot is Nonterminal nonterminal)
                    {
                        table[state.Id, nonterminal.Pid] = new Shift(item.ToState);
                    }
                }
            }

            Grammar.Table = table;
        }

        private SimpleParseTable BuildSimpleParseTable()
        {
            var fullTable = Grammar.Table ?? throw new ArgumentNullException(nameof(Grammar.Table));
            var numberOfStates = Grammar.LR1Sets.Count;
            var numberOfTerminals = Grammar.PSymbols.Where(s => s is Terminal).Count();
            var numberOfSymbols = Grammar.PSymbols.Count;

            Debug.Assert(fullTable.GetLength(0) == numberOfStates);
            Debug.Assert(fullTable.GetLength(1) == numberOfSymbols);

            var table = new TableItem[numberOfStates, numberOfSymbols];

            for (var stateNo = 0; stateNo < numberOfStates; ++stateNo)
            {
                for (var symNo = 0; symNo < numberOfSymbols; ++symNo)
                {
                    TableItem entry;
                    switch (fullTable[stateNo, symNo])
                    {
                        case Accept _:
                            entry = TableItem.Accept;
                            break;
                        case Shift shift:
                            entry = (TableItem)(shift.State << 2) | TableItem.Shift;
                            break;
                        case Reduce reduce:
                            entry = (TableItem)(reduce.Production << 2) | TableItem.Reduce;
                            break;
                        default:
                            entry = TableItem.Error;
                            break;
                    }
                    table[stateNo, symNo] = entry;
                }
            }

            return new SimpleParseTable(table, numberOfTerminals);
        }
    }
}
