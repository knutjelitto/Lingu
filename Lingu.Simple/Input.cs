namespace Lingu.Simple
{
    public struct Input
    {
        public Input(string text)
            : this(text, 0)
        {
        }

        private Input(string text, int offset)
        {
            this.text = text;
            this.offset = offset;
        }

        public Input Next => new Input(text, offset + 1);

        public bool Valid => offset < text.Length;

        public char Value => text[offset];

        public string UpTo(Input next)
        {
            return text.Substring(offset, next.offset - offset);
        }

        public static implicit operator bool(Input input) => input.Valid;

        public static implicit operator char(Input input) => input.Value;

        private readonly int offset;
        private readonly string text;
    }
}