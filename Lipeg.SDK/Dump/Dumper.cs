using System.IO;

using Lipeg.Runtime.Tools;
using Lipeg.SDK.Output;

namespace Lipeg.SDK.Dump
{
    public static class Dumper
    {
        public static void Dump<T>(FileRef file, IDump<T> dump, T subject )
        {
            var writer = new IndentWriter();
            dump.Dump(writer, subject);
            writer.Persist(file);
        }
    }
}
