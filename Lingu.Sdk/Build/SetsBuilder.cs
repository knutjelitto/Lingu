using System.Collections.Generic;
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

            var start = new LR0(CoreFactory.Get(Grammar.Nonterminals[0].Productions[0]), true);
            var startSet = new LR0Set(null, start).Close();

            var goner = new LR0Set.Goner(Grammar.LR0Sets, startSet);

            goner.Go();
        }
    }
}
