using System;
using System.Collections.Generic;
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
            Ids = this.Select(i => i.Id).OrderBy(i => i).ToArray();
            var hash = new HashCode();
            foreach (var id in Ids)
            {
                hash.Add(id);
            }

            hashCode = hash.ToHashCode();
        }

        public abstract Item.Patch Add(Core dotted);
        public void Close()
        {
            for (int i = 0; i < Count; ++i)
            {
                var from = this[i];

                if (!from.IsComplete && from.PostDot is Nonterminal nonterminal)
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
                .Select(item => item.Core)
                .Where(i => !i.IsComplete)
                .Select(t => t.PostDot)
                .OfType<TSym>()
                .Distinct()
                .OrderBy(t => t.Id);
        }

        private (TSet, IEnumerable<Item.Patch>) ShiftTerminal(Terminal terminal)
        {
            var newSet = new TSet();
            var patches = new List<Item.Patch>();

            foreach (var item in this.Where(i => !i.IsComplete && i.PostDot.Equals(terminal)))
            {
                var patch = newSet.Add(item.Next);
                patches.Add(patch);
            }

            newSet.Close();

            return (newSet, patches);
        }

        private (TSet, IEnumerable<Item.Patch>) ReduceNonterminal(Symbol symbol)
        {
            var newSet = new TSet();
            var patches = new List<Item.Patch>();

            foreach (var item in this.Where(i => !i.IsComplete))
            {
                if (item.PostDot.Equals(symbol))
                {
                    var patch = newSet.Add(item.Next);
                    patches.Add(patch);
                }
            }

            newSet.Close();

            return (newSet, patches);
        }

        public IEnumerable<(TSet, IEnumerable<Item.Patch>)> Goto()
        {
            foreach (var terminal in this.Items<Terminal>())
            {
                yield return ShiftTerminal(terminal);
            }
            foreach (var nonterminal in this.Items<Nonterminal>())
            {
                yield return ReduceNonterminal(nonterminal);
            }
        }

        public IEnumerable<TSet> Goto(ItemSets<TItem, TSet> sets)
        {
            foreach (var (newSet, patches) in Goto())
            {
                if (sets.TryGetValue(newSet, out var already))
                {
                    foreach (var patch in patches)
                    {
                        patch.Do(already.Id);
                    }
                }
                else
                {
                    sets.Add(newSet);
                    foreach (var patch in patches)
                    {
                        patch.Do(newSet.Id);
                    }
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
