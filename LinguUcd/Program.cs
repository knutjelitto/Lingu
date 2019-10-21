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

            AquireData(ucdDir);

            var blocksFile = ucdDir.File("Blocks.txt");
            new UcdBlocksParser().Parse(blocksFile);

            var scriptsFile = ucdDir.File("Scripts.txt");
            new UcdScriptsParser().Parse(scriptsFile);

            Console.Write("press (almost) any key ... ");
            Console.ReadKey(true);
        }

        internal static void AquireData(DirRef ucdDir)
        {
            using (var client = new WebClient())
            {
                foreach (var fileName in unicodeFiles)
                {
                    var localFile = ucdDir.File(fileName);
                    var tmpFile = ucdDir.File(fileName).Add(".tmp");

                    if (!localFile.OnPladde)
                    {
                        Console.WriteLine($"download {localFile.FileName}");

                        client.DownloadFile(@"https://www.unicode.org/Public/12.1.0/ucd/" + fileName, tmpFile);

                        if (localFile.OnPladde)
                        {
                            File.Delete(localFile);
                        }

                        Console.WriteLine($"extract {localFile.FileName}");

                        ZipFile.ExtractToDirectory(tmpFile, ucdDir, true);

                        File.Move(tmpFile, localFile);
                    }
                }
            }
        }
    }
}
