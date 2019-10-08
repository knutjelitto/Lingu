using System.Diagnostics;

using IOPath = System.IO.Path;

namespace Lingu.Commons
{
    public class DirRef
    {
        private DirRef(string path)
        {
            Path = path;
            EnsureDirectory();
        }

        public string Path { get; }
        public string BaseName => IOPath.GetFileNameWithoutExtension(Path);
        public string FileName => IOPath.GetFileName(Path);
        public string Directory => IOPath.GetDirectoryName(Path);

        public FileRef File(string fileName)
        {
            return FileRef.From(IOPath.Combine(Path, fileName).Replace("\\", "/"));
        }

        public DirRef Dir(string dirName)
        {
            return From(IOPath.Combine(Path, dirName).Replace("\\", "/"));
        }


        public static DirRef From(string name)
        {
            return new DirRef(name);
        }

        public static implicit operator string(DirRef dir)
        {
            return dir.Path;
        }

        public override string ToString()
        {
            return Path;
        }

        private void EnsureDirectory()
        {
            var dirPath = Path;
            if (!string.IsNullOrEmpty(dirPath) && !System.IO.Directory.Exists(dirPath))
            {
                System.IO.Directory.CreateDirectory(dirPath);
            }
        }
    }
}
