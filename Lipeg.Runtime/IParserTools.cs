using System;
using System.Collections.Generic;
using System.Text;

namespace Lipeg.Runtime
{
    public interface IParserTools
    {
        void __ClearCache();
        IResult __FinishRule(IResult result, string name);
        IResult __MatchPredicate(IContext current, Func<int, bool> predicate);
        IResult __MatchString(IContext current, string str);
        IResult __Parse(Func<IContext, IResult> parser, IContext context);
        IContext __SkipSpace(IContext context);
    }
}
