using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Mean.Maker.Builders
{
    public sealed class Capture
    {
        private readonly bool verbose = true;

        public static readonly Capture Ok = new Capture(null, 0);

        public Capture()
            : this(new Process(), -1)
        {
        }

        private Capture(Process process, int exitCode)
        {
            Process = process;
            ExitCode = exitCode;
        }

        public Process Process { get; private set; }
        public int ExitCode { get; set; }
        public List<Line> StdOut { get; private set; } = new List<Line>();
        public List<Line> StdErr { get; } = new List<Line>();

        public void AddOut(string text)
        {
            Add(StdOut, Line.Out(text));
        }

        public void AddErr(string text)
        {
            Add(StdErr, Line.Err(text));
        }

        private void Add(List<Line> lines, Line line)
        {
            if (lines.Count > 0 || !string.IsNullOrEmpty(line.Text))
            {
                if (verbose) Console.WriteLine(line.ToString());
                lines.Add(line);
            }
        }

        public bool IsOk => ExitCode == 0;

        //public static implicit operator bool(Capture capture) => capture.Ok;

        public void Done()
        {
            ExitCode = Process.ExitCode;
            Process.Close();
        }
    }
}
