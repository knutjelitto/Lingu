using System;
using System.Collections.Generic;
using System.Text;

namespace Lipeg.Boot.Tree
{
    public class WildcardExpression : Expression
    {
        private WildcardExpression()
        {
        }

        public static WildcardExpression From()
        {
            return new WildcardExpression();
        }
    }
}
