using System;
using System.Collections.Generic;
using System.Text;

namespace Lingu.LR
{
    public abstract class Cell
    {
    }

    public class Accept : Cell
    {
    }

    public class Error : Cell
    {
    }

    public class Shift : Cell 
    {
        public Shift(int state)
        {
            State = state;
        }

        public int State { get; }
    }

    public class Reduce : Cell
    {
        public Reduce(int production)
        {
            Production = production;
        }

        public int Production { get; }
    }
}
