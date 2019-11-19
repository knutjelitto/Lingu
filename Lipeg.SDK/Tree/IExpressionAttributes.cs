using System;
using System.Collections.Generic;
using System.Text;

namespace Lipeg.SDK.Tree
{
    public interface IExpressionAttributes
    {
        bool IsNullable { get; }
        bool SetIsNullable(bool value);
        bool IsLexical { get; }
        bool SetIsLexical(bool value);

        Rule Rule { get; }
        void SetRule(Rule rule);
    }
}
