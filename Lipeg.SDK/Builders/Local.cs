using System;
using System.Collections.Generic;
using System.Text;

namespace Lipeg.SDK.Builders
{
    public class Local
    {
        private readonly string stem;
        private readonly int num;

        public Local(string stem, int num)
        {
            this.stem = stem;
            this.num = num;
        }

        public string Name
        {
            get
            {
                if (this.num == 1)
                {
                    return this.stem;
                }
                return this.stem + this.num;
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
