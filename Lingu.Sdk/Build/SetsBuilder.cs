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
        public ItemFactory ItemFactory => Grammar.ItemFactory;

        public void Build()
        {
            Grammar.ItemFactory.Initialize(Grammar.Nonterminals.SelectMany(n => n.Productions).ToList());

            var start = ItemFactory.Get(Grammar.Nonterminals[0].Productions[0]);

            var set0 = new ItemSet(start).Close();

            var todo = new Stack<ItemSet>();
            todo.Push(set0);

            while (todo.Count > 0)
            {
                var set = todo.Pop();

                Grammar.ItemSets.Add(set);

                foreach (var newSet in set.Goto())
                {
                    bool already = false;
                    for (var i = 0; i < Grammar.ItemSets.Count; ++i)
                    {
                        if (newSet.SetEquals(Grammar.ItemSets[i]))
                        {
                            already = true;
                            break;
                        }
                    }
                    if (!already)
                    {
                        todo.Push(newSet);
                    }
                }
            }
        }
    }
}
