using System.Diagnostics;
using System.Linq;

using Lingu.Grammars;
using Lingu.LR;

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

            BuildLR1();
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

        private void BuildLR0()
        {
            var start = new LR0(CoreFactory.Get(Grammar.Accept.Productions[0]), true);
            var startSet = new LR0Set(null, start).Close();

            var goner = new LR0Set.Goner(Grammar.LR0Sets, startSet);

            goner.Go();
        }

        private void BuildLR1()
        {
            var start = new LR1(CoreFactory.Get(Grammar.Accept.Productions[0]), true, Grammar.Eof.First);
            var startSet = new LR1Set(null, start).Close();

#if false
            Grammar.LR1Sets.Add(startSet);
#else
            var goner = new LR1Set.Goner(Grammar.LR1Sets, startSet);
            goner.Go();
#endif
        }
    }
}
