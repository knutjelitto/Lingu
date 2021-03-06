﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using Lipeg.Runtime;
using Lipeg.SDK.Output;
using Lipeg.SDK.Parsers;
using Pegasus.Common;
using Pegasus.Parser;

#nullable enable

namespace Lipeg.Boot
{
    public partial class LipegParser : SDK.Parsers.ICombiParser
    {
        private ISource source = Source.FromString(String.Empty, String.Empty);

        public string Kind => "lipeg";

        public static SDK.Parsers.ICombiParser From()
        {
            return new LipegParser();
        }

        public IResult Parse(IContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            if (context.Source == null) throw  new InternalNullException();
            this.source = context.Source;

            var node = Parse(context.Source.ToString(), context.Source.Name);

            return Result.Success(node, context, node);
        }

        protected INode N(Cursor start, Cursor end, string name, params INode[] children)
        {
            var loc = Loc(start, end);

            return children.Length == 0
                ? Leaf.From(loc, name)
                : NodeList.From(loc, name, children);
        }

        /// <summary>
        /// Embed children
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="name"></param>
        /// <param name="children"></param>
        /// <returns></returns>
        protected INode NE(Cursor start, Cursor end, string name, params INode[] children)
        {
            var loc = Loc(start, end);

            var childs = children;

            if (children.Length == 1 && (children[0].Name == "*" || children[0].Name == "+"))
            {
                childs = children[0].ToArray();
            }

            return children.Length == 0
                ? Leaf.From(loc, name)
                : NodeList.From(loc, name, childs);
        }

        protected INode N(Cursor start, Cursor end, string name, string value)
        {
            return Leaf.From(Loc(start, end), name, value);
        }

        protected INode NP(Cursor start, Cursor end, IList<INode> children)
        {
            return NodeList.From(Loc(start, end), "+", children.ToArray());
        }

        protected static string Flat(IList<string> children)
        {
            return string.Join(string.Empty, children);
        }

        protected INode NS(Cursor start, Cursor end, IList<INode> children)
        {
            return NodeList.From(Loc(start, end), "*", children.ToArray());
        }

        protected static string NO(IList<string> children)
        {
            return children.FirstOrDefault() ?? string.Empty;
        }

        private ILocation Loc(Cursor start, Cursor end)
        {
            return BootLocation.From(source, start, end);
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
                .Replace("e", "\x1B")
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

        public void Dump(int level, IWriter writer)
        {
            throw new System.NotImplementedException();
        }
    }
}
