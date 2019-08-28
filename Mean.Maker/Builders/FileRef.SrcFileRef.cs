using System.Diagnostics;

namespace Mean.Maker.Builders
{
    public partial class FileRef
    {
        public class SrcFileRef : FileRef
        {
            public SrcFileRef(string path)
                : base(path)
            {
                Debug.Assert(!path.StartsWith(DstPrefix));
            }

            public override FileRef Dst => new DstFileRef(DstPrefix + Path);
            public override FileRef Src => this;

            protected override FileRef ForceChangeExtension(string newExtension)
            {
                return new SrcFileRef(System.IO.Path.ChangeExtension(Path, newExtension));
            }
        }
    }
}
