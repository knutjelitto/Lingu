using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Lingu.Automata;
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
        public CoreFactory CoreFactory => Grammar.CoreFactory;

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
            Debug.Assert(Grammar.PSymbols != null);

            int states = Grammar.LR1Sets.Count;
            int symbols = Grammar.PSymbols.Count;

            var table = new TableCell[states, symbols];
            for (var i = 0; i < states; ++i)
            {
                for (var j = 0; j < symbols; ++j)
                {
                    table[i, j] = new TableCell();
                }
            }

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
                                table[state.Id, terminal.Pid].Add(new Accept());
                            }
                            else
                            {
                                table[state.Id, terminal.Pid].Add(new Reduce(item.Core.Production.Id));
                            }
                        }
                    }
                    else if (item.PostDot is Terminal terminal)
                    {
                        table[state.Id, terminal.Pid].Add(new Shift(item.ToState));
                    }
                    else if (item.PostDot is Nonterminal nonterminal)
                    {
                        table[state.Id, nonterminal.Pid].Add(new Shift(item.ToState));
                    }
                }
            }

            Grammar.Table = table;
        }

        private void BuildSimpleParseTable()
        {
            Debug.Assert(Grammar.PSymbols != null);
            Debug.Assert(Grammar.Table != null);

            var fullTable = Grammar.Table;
            var numberOfStates = Grammar.LR1Sets.Count;
            var numberOfTerminals = Grammar.PSymbols.Where(s => s is Terminal).Count();
            var numberOfSymbols = Grammar.PSymbols.Count;

            Debug.Assert(fullTable.GetLength(0) == numberOfStates);
            Debug.Assert(fullTable.GetLength(1) == numberOfSymbols);

            var table = new TableItem[numberOfStates, numberOfSymbols];
            var terminalSets = new List<Integers>();

            for (var stateNo = 0; stateNo < numberOfStates; ++stateNo)
            {
                var terminalSet = new Integers();

                for (var symNo = 0; symNo < numberOfSymbols; ++symNo)
                {
                    TableItem entry;
                    switch (fullTable[stateNo, symNo].LastOrDefault())
                    {
                        case Accept _:
                            entry = TableItem.Accept;
                            if (symNo < numberOfTerminals)
                            {
                                terminalSet.Add(symNo);
                            }
                            break;
                        case Shift shift:
                            entry = (TableItem)(shift.State << 2) | TableItem.Shift;
                            if (symNo < numberOfTerminals)
                            {
                                terminalSet.Add(symNo);
                            }
                            break;
                        case Reduce reduce:
                            entry = (TableItem)(reduce.Production << 2) | TableItem.Reduce;
                            if (symNo < numberOfTerminals)
                            {
                                terminalSet.Add(symNo);
                            }
                            break;
                        default:
                            entry = TableItem.Error;
                            break;
                    }
                    table[stateNo, symNo] = entry;
                }

                Debug.Assert(!terminalSet.IsEmpty);
                terminalSets.Add(terminalSet);
            }

            Grammar.ParseTable = U16ParseTable.From(table, numberOfTerminals);

            BuildDfaSets(terminalSets);
        }

        private void BuildDfaSets(IEnumerable<Integers> terminalSets)
        {
            var terminals = Grammar.Terminals.Where(t => t.IsPid).ToList();
            var terminalDfas = new List<FA>();
            for (var i = 0; i < terminals.Count; ++i)
            {
                var terminal = terminals[i];
                var fa = terminal.Raw.Expression.GetFA();
                fa = fa.ToDfa();
                fa = fa.Minimize();
                fa = fa.RemoveDead();

                foreach (var state in fa.Finals)
                {
                    state.SetPayload(terminal.Id);
                }

                terminalDfas.Add(fa);
            }

            var already = new Dictionary<Integers, int>();
            var dfas = new List<FA>();
            var stateDfas = new List<int>();

            foreach (var terminalSet in terminalSets)
            {
                Debug.Assert(!terminalSet.IsEmpty);
                
                if (!already.TryGetValue(terminalSet, out var index))
                {
                    index = dfas.Count;

                    already.Add(terminalSet, dfas.Count);

                    FA dfa;
                    if (terminalSet.Cardinality == 1)
                    {
                        dfa = terminalDfas[terminalSet.Single()].RemoveDead().Clone();
                    }
                    else
                    {
                        dfa = Combine(terminalSet.Select(i => terminalDfas[i]));
                    }

                    var finals = dfa.Finals.Select(s => s.Payload).Distinct().OrderBy(p => p).ToList();
                    var numbers = terminalSet.Distinct().OrderBy(p => p).ToList();
                    Debug.Assert(finals.SequenceEqual(numbers));
                    
                    dfas.Add(dfa);
                }

                stateDfas.Add(index);
            }

            FA Combine(IEnumerable<FA> fas)
            {
                FA combined = fas.First().Clone();
                foreach (var fa in fas.Skip(1))
                {
                    combined = combined.Union(fa, true);
                }
                return combined;
            }

            Debug.Assert(Grammar.Table != null);
            Debug.Assert(stateDfas.Count == Grammar.Table.GetLength(0));
            Grammar.Dfas = dfas;
            Grammar.StateToDfa = stateDfas;
        }
    }
}
