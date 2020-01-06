using System;
using System.Collections.Generic;
using System.Linq;

using Lipeg.Runtime;

namespace Lipeg.SDK.Parsers
{
    public class Result : IResult
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1051:Do not declare visible instance fields", Justification = "<Pending>")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2211:Non-constant fields should not be visible", Justification = "<Pending>")]
        public static Result? FarthestFail = null;

        private Result(ILocated located, IContext next, bool isSuccess, IEnumerable<INode> nodes)
        {
            Location = located.Location;
            Next = next;
            IsSuccess = isSuccess;
            Nodes = nodes.ToList();
        }

        public ILocation Location { get; }
        public IContext Next { get; }
        public bool IsSuccess { get; }

        public IReadOnlyList<INode> Nodes { get; }


        public static IResult Fail(ILocated located, IContext next)
        {
            if (located == null) throw new InternalNullException();
            return new FailResult(located, next);
        }

        public static IResult Fail(IContext context)
        {
            return new FailResult(Runtime.Location.From(context, context), context);
        }

        public static IResult Success(ILocated located, IContext next, params INode[] nodes)
        {
            return new SuccessResult(located, next, nodes);
        }

        private class FailResult : Result, IFail
        {
            private static IEnumerable<INode> Empty = Enumerable.Empty<INode>();

            public FailResult(ILocated located, IContext next)
                : base(located, next, false, Empty)
            {
                if (FarthestFail == null || located.Location.Start > FarthestFail.Location.Start)
                {
                    FarthestFail = this;
                }
            }

            public override string ToString()
            {
                return $"[FAIL//{Next}]";
            }
        }

        private class SuccessResult : Result, ISuccess
        {
            public SuccessResult(ILocated located, IContext next, IEnumerable<INode> nodes)
                : base(located, next, true, nodes)
            {
            }
            public override string ToString()
            {
                var nodes = string.Join(",", Nodes);
                return $"[OK/({nodes})/{Next}]";
            }
        }
    }
}
