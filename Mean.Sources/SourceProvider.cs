using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Clean.Sources
{
    public class SourceProvider
    {
        private static readonly bool verbose = true;

        public void Provide(string top)
        {
            var assembly = Assembly.GetExecutingAssembly();

            var prefix = assembly.GetName().Name + ".sources.";

            foreach (var source in assembly.GetManifestResourceNames())
            {
                var name = source.Substring(prefix.Length);
                name = top + "/" + Path.GetFileNameWithoutExtension(name).Replace('.', '/') + Path.GetExtension(name);

                using (var stream = assembly.GetManifestResourceStream(source))
                using (var reader = new StreamReader(stream, Encoding.UTF8))
                {
                    var content = reader.ReadToEnd();
                    Directory.CreateDirectory(Path.GetDirectoryName(name));
                    if (File.Exists(name))
                    {
                        var oldContent = File.ReadAllText(name, Encoding.UTF8);
                        if (content == oldContent)
                        {
                            //if (verbose) Console.WriteLine($"SKIP source: {name}");
                            continue;
                        }
                    }
                    if (verbose) Console.WriteLine($"source: {source} => {name}");
                    File.WriteAllText(name, content, Encoding.UTF8);
                }
            }
        }
    }
}
