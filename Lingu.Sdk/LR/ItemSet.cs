using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

using Lingu.Commons;
using Lingu.Grammars;

#nullable enable

namespace Lingu.LR
{
    public abstract class ItemSet<TItem, TSet, TSetSet> : UniqueList<TItem>
        where TItem : Item<TItem>
        where TSet : ItemSet<TItem, TSet, TSetSet>, new()
        where TSetSet : ItemSetSet<TItem, TSet, TSetSet>
    {
        public ItemSet(params TItem[] items)
            : base(new Eq())
        {
            sortedItems = Array.Empty<TItem>();
            AddRange(items);
            Id = -1;
        }

        private class Eq : IEqualityComparer<TItem>
        {
            public bool Equals([AllowNull] TItem x, [AllowNull] TItem y)
            {
                Debug.Assert(x != null && y != null);
                return x.Equals(y);
            }

            public int GetHashCode([DisallowNull] TItem obj)
            {
                var hash = obj.GetHashCode();

                return hash;
            }
        }

        public int Id { get; set; }

        public bool Frozen => sortedItems.Length > 0;

        protected void Freeze()
        {
            sortedItems = this.OrderBy(i => i.Id).ToArray();
            var hash = new HashCode();
            foreach (var id in sortedItems)
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

        public void Patch(TSet set)
        {
            foreach (var item in patches)
            {
                item.ToState = set.Id;
            }
            patches.Clear();
        }

        public abstract TSet Close();

        private readonly List<TItem> patches = new List<TItem>();

        public override string ToString()
        {
            return $"i{Id}.";
        }

        public class Closer
        {
            public Closer(TSetSet sets, TSet set)
            {
                Sets = sets;
                Set0 = set;
                Todo = new Stack<TSet>();
            }

            public TSetSet Sets { get; }
            public TSet Set0 { get; }
            public Stack<TSet> Todo { get; }

            public void Go()
            {
                Todo.Push(Set0);
                Sets.Add(Set0);

                while (Todo.Count > 0)
                {
                    var set = Todo.Pop();

                    foreach (var newSet in Goto(Sets, set))
                    {
                        Todo.Push(newSet);
                    }
                }
            }

            private IEnumerable<TSet> Goto(TSetSet sets, TSet set)
            {
                foreach (var newSet in Goto(set))
                {
                    if (sets.TryGetValue(newSet, out var already))
                    {
                        newSet.Patch(already);
                    }
                    else
                    {
                        sets.Add(newSet);
                        newSet.Patch(newSet);
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
                foreach (var symbol in Items(set).OfType<Nonterminal>())
                {
                    yield return AddAll(set, symbol);
                }
                foreach (var symbol in Items(set).OfType<Terminal>())
                {
                    yield return AddAll(set, symbol);
                }
            }

            private TSet AddAll(TSet set, Symbol symbol)
            {
                var newSet = new TSet();

                foreach (var item in set.Where(i => !i.IsComplete && i.PostDot.Equals(symbol)))
                {
                    newSet.Add(item, item.Next(true));
                }

                newSet.Close();

                return newSet;
            }
        }

        public class Closer2
        {
            public Closer2(TSetSet sets, TSet set)
            {
                Sets = sets;
                Set0 = set;
                Todo = new Queue<TSet>();
            }

            public TSetSet Sets { get; }
            public TSet Set0 { get; }
            public Queue<TSet> Todo { get; }

            public void Go()
            {
                Todo.Enqueue(Set0);

                while (Todo.Count > 0)
                {
                    var set = Todo.Dequeue();

                    if (Complete(set))
                    {
                        Goto(set);
                    }
                }
            }

            private bool Complete(TSet set)
            {
                set.Close();

                if (Sets.TryGetValue(set, out var already))
                {
                    set.Patch(already);
                    return false;
                }
                else
                {
                    Sets.Add(set);
                    set.Patch(set);
                    return true;
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

            private void Goto(TSet set)
            {
                foreach (var symbol in Items(set).OfType<Nonterminal>())
                {
                    AddAll(set, symbol);
                }
                foreach (var symbol in Items(set).OfType<Terminal>())
                {
                    AddAll(set, symbol);
                }
            }

            private void AddAll(TSet set, Symbol symbol)
            {
                Debug.Assert(symbol.IsPid);

                var newSet = new TSet();

                foreach (var item in set.Where(i => !i.IsComplete && i.PostDot.Equals(symbol)))
                {
                    newSet.Add(item, item.Next(true));
                }

                Todo.Enqueue(newSet);
            }
        }

        public bool SetEquals(TSet other) => Frozen && other.Frozen && sortedItems.SequenceEqual(other.sortedItems);
        public override bool Equals(object? obj) => Frozen && obj is TSet other && other.Frozen && SetEquals(other);
        public override int GetHashCode() => hashCode;

        private TItem[] sortedItems;
        private int hashCode;
    }
}
