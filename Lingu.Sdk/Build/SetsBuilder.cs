using System.Collections.Generic;
using System.Linq;

using Lingu.Grammars;
using Lingu.LR;

namespace Lingu.Build
{
    public class SetsBuilder
    {
        public SetsBuilder(Grammar grammar)
        {
            Grammar = grammar;
        }

        public Grammar Grammar { get; }
        public DottedFactory ItemFactory => Grammar.ItemFactory;

        public void Build()
        {
            ItemFactory.Initialize(Grammar.Nonterminals.SelectMany(n => n.Productions).ToList());

            var start = new LR0(ItemFactory.Get(Grammar.Nonterminals[0].Productions[0]), new Error());

            var startSet = new LR0Set(start);
            startSet.Close();

            var todo = new Stack<LR0Set>();
            todo.Push(startSet);

            while (todo.Count > 0)
            {
                var set = todo.Pop();

                Grammar.LR0Sets.Add(set);

                foreach (var newSet in set.Goto())
                {
                    if (!Grammar.LR0Sets.Contains(newSet))
                    {
                        todo.Push(newSet);
                    }
                }
            }
        }
    }
}
