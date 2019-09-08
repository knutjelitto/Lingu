using System;
using System.Collections.Generic;
using System.Text;

namespace Lingu.Hime
{
    public class HimeTaskOptions
    {
        public bool Assembly { get; set; }
        public bool Debug { get; set; }
        public string Grammar { get; set; }
        public string OutputPath { get; set; }
        public string Namespace { get; set; }
        public bool RNGLR { get; set; }
        public bool Public { get; set; }
    }
}
