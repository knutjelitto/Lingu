using System;

namespace Lingu.Writers
{
    public static class IndentExtensions
    {
        public static void Block(this IndentWriter writer, string head, Action body)
        {
            writer.AddLine(head);
            writer.AddLine("{");
            using (writer.Indent())
            {
                body();
            }
            writer.AddLine("}");
        }
    }
}
