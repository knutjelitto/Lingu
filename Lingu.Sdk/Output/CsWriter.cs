using System;

#nullable enable

namespace Lingu.Output
{
    public class CsWriter : IndentWriter
    {
        public CsWriter()
        {
        }

        public void Using(string @namespace)
        {
            WriteLine($"using {@namespace};");
        }

        public void Data(string head, Action body)
        {
            AddLine(head);
            AddLine("{");
            using (Indent())
            {
                body();
            }
            AddLine("};");
        }

        public void Class(string head, Action body)
        {
            AddLine(head);
            AddLine("{");
            using (Indent())
            {
                body();
            }
            AddLine("}");
        }
    }
}
