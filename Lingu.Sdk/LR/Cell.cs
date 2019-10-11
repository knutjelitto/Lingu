using System;
using System.Collections;
using System.Collections.Generic;

#nullable enable

namespace Lingu.LR
{
    public class TableCell : IEnumerable<TableAction>
    {
        public readonly List<TableAction> Actions = new List<TableAction>();

        public void Add(TableAction action)
        {
            Actions.Add(action);
        }

        public IEnumerator<TableAction> GetEnumerator()
        {
            return ((IEnumerable<TableAction>)this.Actions).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<TableAction>)this.Actions).GetEnumerator();
        }
    }

    public abstract class TableAction
    {
    }

    public class Accept : TableAction
    {
        public override bool Equals(object? obj)
        {
            return obj is Accept;
        }

        public override int GetHashCode() => 2;
    }

    public class Error : TableAction
    {
        public override bool Equals(object? obj)
        {
            return obj is Error;
        }

        public override int GetHashCode() => 1;
    }

    public class Shift : TableAction 
    {
        public Shift(int state)
        {
            State = state;
        }

        public int State { get; }

        public override bool Equals(object? obj)
        {
            return obj is Shift other && State == other.State;
        }

        public override int GetHashCode()
        {
            return State.GetHashCode();
        }
    }

    public class Reduce : TableAction
    {
        public Reduce(int production)
        {
            Production = production;
        }

        public int Production { get; }

        public override bool Equals(object? obj)
        {
            return obj is Reduce other && Production == other.Production;
        }

        public override int GetHashCode()
        {
            return Production.GetHashCode();
        }
    }
}
