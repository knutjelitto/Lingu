using System.Diagnostics;
using System.IO;

namespace Mean.Maker.Builders
{
    public abstract partial class FileRef
    {
        public const string DstPrefix = "obj/";

        public FileRef(string path)
        {
            Path = path;
        }

        public string Path { get; }

        public abstract FileRef Dst { get; }
        public abstract FileRef Src { get; }

        public bool NewerThan(FileRef dst)
        {
            Debug.Assert(System.IO.File.Exists(this));

            return !System.IO.File.Exists(dst) || System.IO.File.GetLastWriteTime(this) > System.IO.File.GetLastWriteTime(dst);
        }

        protected abstract FileRef ForceChangeExtension(string newExtension);

        protected abstract FileRef ForceAddExtension(string newExtension);

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

        public FileRef C => ChangeExtension(".c");
        public FileRef H => ChangeExtension(".h");
        public FileRef Obj => ChangeExtension(".o");
        public FileRef Exe => ChangeExtension(".exe");
        public FileRef Asm => ChangeExtension(".s");
        public FileRef DisAsm => ChangeExtension(".nasm");
        public FileRef LL => ChangeExtension(".ll");
        public FileRef CL => ChangeExtension(".cl");

        public FileRef With(string extension)
        {
            return ChangeExtension(extension);
        }

        public FileRef Add(string extension)
        {
            return AddExtension(extension);
        }

        public string BaseName => System.IO.Path.GetFileNameWithoutExtension(Path);
        public string File => System.IO.Path.GetFileName(Path);
        public string Directory => System.IO.Path.GetDirectoryName(Path);

        public static FileRef Source(string name)
        {
            return new SrcFileRef(name);
        }

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
