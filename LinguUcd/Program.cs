using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using Lingu.Commons;

namespace Lingu.Ucd
{
    internal static class Program
    {
        public static readonly string[] unicodeFiles =
        {
            "UCD.zip",
            "Unihan.zip",
        };

        internal static void Main()
        {
            var projectDir = DirRef.ProjectDir();
            var dataDir = projectDir.Dir("Data");
            var ucdDir = dataDir.Dir("ucd");

            using (var client = new WebClient())
            {
                foreach (var fileName in unicodeFiles)
                {
                    var localFile = ucdDir.File(fileName);
                    var tmpFile = ucdDir.File(fileName).Add(".tmp");

                    if (!localFile.OnPladde)
                    {
                        Console.WriteLine($"{localFile.FileName}");

                        client.DownloadFile(@"https://www.unicode.org/Public/12.1.0/ucd/" + fileName, tmpFile);

                        if (localFile.OnPladde)
                        {
                            File.Delete(localFile);
                        }

                        File.Move(tmpFile, localFile);
                    }
                }
            }

            foreach (var fileName in unicodeFiles)
            {
                var localFile = ucdDir.File(fileName);

                Console.WriteLine($"{localFile.FileName}");

                ZipFile.ExtractToDirectory(localFile, ucdDir, true);
            }

            Console.Write("press (almost) any key ... ");
            Console.ReadKey(true);
        }
    }
}
