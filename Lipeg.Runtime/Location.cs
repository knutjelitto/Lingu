﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Lipeg.Runtime
{
    public class Location : ILocation
    {
        public static readonly ILocation NoLocation = new Location(Runtime.Source.NoSource, 0, 0);
        private Location(ISource source, int start, int end)
        {
            Source = source;
            Start = start;
            End = end;
        }

        public ISource Source { get; }
        public int Start { get; }
        public int End { get; }
        ILocation ILocated.Location => this;

        public static ILocation From(ILocation start, ILocation end)
        {
            return new Location(start.Source, start.Start, end.End);
        }

        public static ILocation From(IContext start, IContext end)
        {
            Debug.Assert(start.Source == end.Source);
            return new Location(start.Source, start.Offset, end.Offset);
        }

        public static ILocation From(IContext both)
        {
            return new Location(both.Source, both.Offset, both.Offset);
        }

        public override string ToString()
        {
            var start = Source.GetLineCol(Start);
            var end = Source.GetLineCol(End);
            var text = Source.GetText(Start, End - Start);
            return $"({start.lineNo}-{start.colNo})-({end.lineNo}-{end.colNo})<{text}>";
        }
    }
}
