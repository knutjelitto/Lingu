using Lingu.Runtime.Parsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lingu.Runtime.Structures
{
    public interface IStateItem
    {
        TableItem Action { get; }
        int Number { get; }
    }
}
