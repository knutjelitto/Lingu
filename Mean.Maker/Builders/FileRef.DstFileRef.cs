using System.Diagnostics;

namespace Mean.Maker.Builders
{
    public partial class FileRef
    {
        public class DstFileRef : FileRef
        {
            public DstFileRef(string path)
                : base(path)
            {
                Debug.Assert(path.StartsWith(DstPrefix));
                EnsureDirectory();
            }

            public override FileRef Dst => this;

            public override FileRef Src => new SrcFileRef(Path.Substring(DstPrefix.Length));

            protected override FileRef ForceChangeExtension(string newExtension)
            {
                return new DstFileRef(System.IO.Path.ChangeExtension(Path, newExtension));
            }
        }
    }
}
