using System;
using System.Collections.Generic;
using System.Text;

namespace Lipeg.Boot.BootTree
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
