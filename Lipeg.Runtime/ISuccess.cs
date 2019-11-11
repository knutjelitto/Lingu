using System;
using System.Collections.Generic;
using System.Text;

namespace Lipeg.Runtime
{
    public interface ISuccess : IResult
    {
        INode Node { get; }
    }
}
