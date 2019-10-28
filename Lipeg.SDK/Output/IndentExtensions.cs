using System;

#nullable enable

namespace Lipeg.SDK.Output
{
    public static class IndentExtensions
    {
        public static void Block(this IWriter writer, string head, Action body)
        {
            writer.WriteLine(head);
            writer.WriteLine("{");
            writer.Indent(body);
            writer.WriteLine("}");
        }

        public static void Indent(this IWriter writer, string head, Action body)
        {
            writer.WriteLine(head);
            writer.Indent(body);
        }
    }
}
