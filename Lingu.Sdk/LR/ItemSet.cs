using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using Lingu.Commons;
using Lingu.Grammars;

#nullable enable

namespace Lingu.LR
{
    public abstract class ItemSet<TItem, TSet> : UniqueList<TItem>
        where TItem : Item
        where TSet : ItemSet<TItem, TSet>, new()
    {
        public ItemSet(params TItem[] items)
        {
            Ids = Array.Empty<int>();
            AddRange(items);
            Id = -1;
        }

        public int Id { get; set; }

        public bool Frozen => Ids.Length > 0;

        public void Freeze()
        {
            Ids = this.Select(i => i.Dotted.Id).OrderBy(i => i).ToArray();
            var hash = new HashCode();
            foreach (var id in Ids)
            {
                hash.Add(id);
            }

            hashCode = hash.ToHashCode();
        }

        public abstract void Add(Core dotted);

        public void AddNext(TItem item)
        {
            Add(item.Dotted.Next);
        }

        public void Close()
        {
            for (int i = 0; i < Count; ++i)
            {
                var from = this[i];

                if (!from.Dotted.IsComplete && from.Dotted.PostDot is Nonterminal nonterminal)
                {
                    foreach (var production in nonterminal.Productions)
                    {
                        Add(production.Initial);
                    }
                }
            }

            Freeze();
        }

        private IEnumerable<TSym> Items<TSym>()
            where TSym : Symbol
        {
            return this
                .Select(item => item.Dotted)
                .Where(i => !i.IsComplete)
                .Select(t => t.PostDot)
                .OfType<TSym>()
                .Distinct()
                .OrderBy(t => t.Id);
        }

        private TSet Goto(Symbol symbol)
        {
            var newSet = new TSet();
            foreach (var item in this.Where(i => !i.Dotted.IsComplete))
            {
                if (item.Dotted.PostDot.Equals(symbol))
                {
                    newSet.Add(item.Dotted.Next);
                }
            }

            newSet.Close();

            return newSet;
        }

        public IEnumerable<TSet> Goto()
        {
            foreach (var terminal in this.Items<Terminal>())
            {
                yield return Goto(terminal);
            }
            foreach (var nonterminal in this.Items<Nonterminal>())
            {
                yield return Goto(nonterminal);
            }
        }

        public IEnumerable<TSet> Goto(ItemSets<TItem, TSet> sets)
        {
            foreach (var newSet in Goto())
            {
                if (sets.TryGetValue(newSet, out var already))
                {

                }
                else
                {
                    sets.Add(newSet);
                    yield return newSet;
                }
            }
        }



        private int[] Ids { get; set; }

        public bool SetEquals(TSet other) => Frozen && other.Frozen && Ids.SequenceEqual(other.Ids);
        public override bool Equals(object? obj) => obj is TSet other && SetEquals(other);
        public override int GetHashCode() => hashCode;

        private int hashCode;
    }
}
