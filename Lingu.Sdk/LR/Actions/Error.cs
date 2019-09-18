using System;
using System.Collections.Generic;
using System.Text;

namespace Lingu.LR
{
    public class Error : Action
    {
        public override string ToString()
        {
            return "err";
        }
    }
}
