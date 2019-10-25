using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using Lipeg.Runtime;
using Lipeg.SDK.Tree;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Pegasus.Common;
using Pegasus.Parser;

#nullable enable

namespace Lipeg.Boot
{
    public partial class LipegParser
    {
        internal readonly CSharpParser cSharpParser = new CSharpParser();
        private readonly ISource source;

        public LipegParser(ISource source)
        {
            this.source = source;
        }

        protected INode N(Cursor start, Cursor end, string name, params INode[] children)
        {
            return children.Length == 0
                ? LeafNode.From(Loc(start, end), name) 
                : InternalNode.From(Loc(start, end), name, children);
        }

        protected INode N(Cursor start, Cursor end, string name, string value)
        {
            return LeafNode.From(Loc(start, end), name, value);
        }

        protected INode NP(Cursor start, Cursor end, IList<INode> children)
        {
            return InternalNode.From(Loc(start, end), "+", children.ToArray());
        }

        protected static string Flat(IList<string> children)
        {
            return string.Join(string.Empty, children);
        }

        protected INode NS(Cursor start, Cursor end, IList<INode> children)
        {
            return InternalNode.From(Loc(start, end), "*", children.ToArray());
        }

        protected static string NO(IList<string> children)
        {
            return children.FirstOrDefault() ?? string.Empty;
        }

        private ILocation Loc(Cursor start, Cursor end)
        {
            return Location.From(source, start, end);
        }

        private ILocation Loc(INode start, INode end)
        {
            return Location.From(source, start.Location.Start, end.Location.End);
        }

        protected static string SimpleEsc(string c)
        {
            Debug.Assert(c != null);
#pragma warning disable CA1062 // Validate arguments of public methods
            Debug.Assert(c.Length == 1);
#pragma warning restore CA1062 // Validate arguments of public methods

#pragma warning disable CA1307 // Specify StringComparison
            return c
                .Replace("0", "\0")
                .Replace("a", "\a")
                .Replace("b", "\b")
                .Replace("f", "\f")
                .Replace("n", "\n")
                .Replace("r", "\r")
                .Replace("t", "\t")
                .Replace("v", "\v");
#pragma warning restore CA1307 // Specify StringComparison
        }

        protected static string HexChar(string hexDigits)
        {
            return ((char)int.Parse(hexDigits, NumberStyles.HexNumber, CultureInfo.InvariantCulture)).ToString(CultureInfo.InvariantCulture);
        }
    }
}
