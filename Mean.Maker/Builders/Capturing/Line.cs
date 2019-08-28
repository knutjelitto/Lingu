namespace Mean.Maker.Builders
{
    public class Line
    {
        public Line(Std std, string text)
        {
            Std = std;
            Text = text;
        }

        public Std Std { get; }
        public string Text { get; }

        public static Line Out(string text)
        {
            return new Line(Std.Out, text);
        }
        public static Line Err(string text)
        {
            return new Line(Std.Err, text);
        }

        public override string ToString()
        {
            return $"{Std}: {Text}";
        }
    }
}
