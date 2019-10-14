using System;
using System.Collections.Generic;
using System.Text;
using Lingu.Runtime.Structures;

namespace Lingu.Runtime.Commons
{
    public class CompactParseTable : IParseTable
    {
        public IState this[int stateNo]
        {
            get { throw new NotImplementedException(); }
        }

        public IStateItem this[int stateNo, int symNo]
        {
            get { throw new NotImplementedException(); }
        }

        public Int32 NumberOfStates { get; set; }
        public Int32 NumberOfTerminals { get; set; }
        public Int32 NumberOfSymbols { get; set; }
    }
}
