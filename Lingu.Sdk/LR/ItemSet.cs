using System;
using System.Collections.Generic;
using System.Linq;

using Lingu.Commons;
using Lingu.Grammars;

#nullable enable

namespace Lingu.LR
{
    public abstract class ItemSet<TItem, TSet, TSetSet> : UniqueList<TItem>
        where TItem : Item<TItem>
        where TSet : ItemSet<TItem, TSet, TSetSet>, new()
        where TSetSet : ItemSetSet<TItem, TSet, TSetSet>, new()
    {
        public ItemSet(params TItem[] items)
        {
            ids = Array.Empty<int>();
            AddRange(items);
            Id = -1;
        }

        public int Id { get; set; }

        public bool Frozen => ids.Length > 0;

        protected void Freeze()
        {
            ids = this.Select(i => i.Id).OrderBy(i => i).ToArray();
            var hash = new HashCode();
            foreach (var id in ids)
            {
                hash.Add(id);
            }

            hashCode = hash.ToHashCode();
        }

        public void Add(TItem itemToPatch, TItem newItem)
        {
            patches.Add(itemToPatch);
            Add(newItem);
        }

        public void Patch(int num)
        {
            foreach (var item in patches)
            {
                item.Num = num;
            }
            patches.Clear();
        }

        public abstract TSet Close();

        private List<TItem> patches = new List<TItem>();

        public class Goner
        {
            public Goner(TSetSet sets, TSet set)
            {
                Sets = sets;
                StartSet = set;
            }

            public TSetSet Sets { get; }
            public TSet StartSet { get; }

            public void Go()
            {
                var todo = new Queue<TSet>();

                todo.Enqueue(StartSet);
                Sets.Add(StartSet);

                while (todo.Count > 0)
                {
                    var set = todo.Dequeue();

                    foreach (var newSet in Goto(Sets, set))
                    {
                        todo.Enqueue(newSet);
                    }
                }
            }

            public IEnumerable<TSet> Goto(TSetSet sets, TSet set)
            {
                foreach (var newSet in Goto(set))
                {
                    if (sets.TryGetValue(newSet, out var already))
                    {
                        newSet.Patch(already.Id);
                    }
                    else
                    {
                        sets.Add(newSet);
                        newSet.Patch(newSet.Id);
                        yield return newSet;
                    }
                }
            }

            private IEnumerable<Symbol> Items(TSet set)
            {
                return set
                    .Select(item => item.Core)
                    .Where(i => !i.IsComplete)
                    .Select(t => t.PostDot)
                    .Distinct()
                    .OrderBy(t => t.Id);
            }

            private IEnumerable<TSet> Goto(TSet set)
            {
                foreach (var symbol in Items(set))
                {
                    yield return AddAll(set, symbol);
                }
            }

            private TSet AddAll(TSet set, Symbol symbol)
            {
                var newSet = new TSet();

                foreach (var item in set.Where(i => !i.IsComplete && i.PostDot.Equals(symbol)))
                {
                    newSet.Add(item, item.Next());
                }

                newSet.Close();

                return newSet;
            }
        }

        public bool SetEquals(TSet other) => Frozen && other.Frozen && ids.SequenceEqual(other.ids);
        public override bool Equals(object? obj) => obj is TSet other && SetEquals(other);
        public override int GetHashCode() => hashCode;

        private int[] ids;
        private int hashCode;
    }
}
