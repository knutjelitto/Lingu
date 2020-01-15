using System;
using System.Collections.Generic;
using System.Text;

namespace Lipeg.Runtime
{
    public interface IParser
    {
        IResult Parse(IContext context);
    }
}
