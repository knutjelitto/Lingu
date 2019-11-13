using System;
using System.Collections.Generic;
using System.Text;

using Lipeg.Runtime;

namespace Lipeg.SDK.Parsers
{
    public class Result : IResult
    {
        private Result(ICursor next, bool isFail)
        {
            Next = next;
            IsFail = isFail;
        }

        public ICursor Next { get; }

        public bool IsFail { get; }
        public bool IsDrop { get; private set; }
        public bool IsLift { get; private set; }
        public bool IsFuse { get; private set; }

        public virtual INode Node => throw new InvalidOperationException();


        public static IResult Fail(ICursor next)
        {
            return new FailResult(next);
        }

        public static IResult Success(ICursor next, INode node)
        {
            return new SuccessResult(next, node);
        }

        public IResult SetDrop()
        {
            IsDrop = true;
            return this;
        }

        public IResult SetFuse()
        {
            IsFuse = true;
            return this;
        }

        public IResult SetLift()
        {
            IsLift = true;
            return this;
        }

        private class FailResult : Result, IFail
        {
            public FailResult(ICursor next)
                : base(next, true)
            {
            }
        }

        private class SuccessResult : Result, ISuccess
        {
            public SuccessResult(ICursor next, INode node)
                : base(next, false)
            {
                Node = node;
            }

            public override INode Node { get; }
        }
    }
}
