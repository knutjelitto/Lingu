using System;
using System.Collections.Generic;
using System.Text;

namespace LinParse.Common
{
    public class Source
    {
        public Source(string name, string content)
        {
            Name = name;
            Content = content;
        }

        public string Name { get; }
        public string Content { get; }
    }
}
