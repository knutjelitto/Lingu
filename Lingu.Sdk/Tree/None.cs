using Lingu.Automata;
using Lingu.Output;

namespace Lingu.Tree
{
    public class None : Atom
    {
        public None(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public override void Dump(IndentWriter writer)
        {
            writer.Write(Name);
        }

        public override FA GetFA()
        {
            return FA.None();
        }
    }
}
