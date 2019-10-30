using System;

#nullable enable

#pragma warning disable CA1303 // Do not pass literals as localized parameters

namespace Lipeg.SDK.Output
{
    public static class IndentExtensions
    {
        public static void Block(this IWriter writer, string head, Action body)
        {
            if (writer == null) throw new ArgumentNullException(nameof(writer));

            writer.WriteLine(head);
            writer.WriteLine("{");
            writer.Indent(body);
            writer.WriteLine("}");
        }

        public static void Indent(this IWriter writer, string head, Action body)
        {
            if (writer == null) throw new ArgumentNullException(nameof(writer));

            writer.WriteLine(head);
            writer.Indent(body);
        }
    }
}
