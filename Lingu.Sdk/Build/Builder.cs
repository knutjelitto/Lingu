using System;
using System.Collections.Generic;
using System.Text;

using Lingu.Sdk.Tree;

namespace Lingu.Sdk.Build
{
    public class Builder
    {
        public Builder(Grammar grammar)
        {
            Grammar = grammar;
        }

        public Grammar Grammar { get; }

        public void CheckTermials()
        {
        }

        private void CheckTerminal()
        {

        }
    }
}
