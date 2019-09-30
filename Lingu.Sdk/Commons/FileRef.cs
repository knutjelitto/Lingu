using System.Diagnostics;

namespace Lingu.Commons
{
    public class FileRef
    {
        private FileRef(string path)
        {
            Path = path;
            EnsureDirectory();
        }

        public string Path { get; }

        public bool NewerThan(FileRef dst)
        {
            Debug.Assert(System.IO.File.Exists(this));

            return !System.IO.File.Exists(dst) || System.IO.File.GetLastWriteTime(this) > System.IO.File.GetLastWriteTime(dst);
        }

        public FileRef ForceAddExtension(string newExtension)
        {
            return new FileRef(Path + newExtension);
        }

        public FileRef ForceChangeExtension(string newExtension)
        {
            return new FileRef(System.IO.Path.ChangeExtension(Path, newExtension));
        }

        public static FileRef From(string name)
        {
            return new FileRef(name);
        }

        public FileRef AddExtension(string newExtension)
        {
            newExtension = newExtension.StartsWith(".") ? newExtension : "." + newExtension;

            return ForceAddExtension(newExtension);
        }

        protected FileRef ChangeExtension(string newExtension)
        {
            newExtension = newExtension.StartsWith(".") ? newExtension : "." + newExtension;

            if (System.IO.Path.GetExtension(Path) != newExtension)
            {
                return ForceChangeExtension(newExtension);
            }

            return this;
        }

        public FileRef With(string extension)
        {
            return ChangeExtension(extension);
        }

        public FileRef Add(string extension)
        {
            return AddExtension(extension);
        }

        public string BaseName => System.IO.Path.GetFileNameWithoutExtension(Path);
        public string FileName => System.IO.Path.GetFileName(Path);
        public string Directory => System.IO.Path.GetDirectoryName(Path);


        public static implicit operator string(FileRef file)
        {
            return file.Path;
        }

        public override string ToString()
        {
            return Path;
        }

        private FileRef EnsureDirectory()
        {
            var dirPath = System.IO.Path.GetDirectoryName(Path);
            if (!string.IsNullOrEmpty(dirPath) && !System.IO.Directory.Exists(dirPath))
            {
                System.IO.Directory.CreateDirectory(dirPath);
            }
            return this;
        }
    }
}
