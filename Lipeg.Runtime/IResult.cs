using System;
using System.Collections.Generic;
using System.Text;

namespace Lipeg.Runtime
{
    public interface IResult
    {
        ICursor Next { get; }
    }
}
