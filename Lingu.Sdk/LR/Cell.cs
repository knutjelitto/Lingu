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
    }

    public class Error : TableAction
    {
    }

    public class Shift : TableAction 
    {
        public Shift(int state)
        {
            State = state;
        }

        public int State { get; }
    }

    public class Reduce : TableAction
    {
        public Reduce(int production)
        {
            Production = production;
        }

        public int Production { get; }
    }
}
