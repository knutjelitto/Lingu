using System.Collections.Generic;
using System.Diagnostics;

using Lingu.Runtime.Structures;

namespace Lingu.Runtime.Parsing
{
    [DebuggerDisplay("{DD()}")]
    internal class ParseStack
    {
        private readonly List<StackItem> items = new List<StackItem>();
        private int top = 0;
        private int capacity = 0;

        public void Push(StackItem item)
        {
            if (top == capacity)
            {
                items.Add(item);
                capacity += 1;
            }
            else
            {
                items[top] = item;
            }
            top += 1;
        }

        public StackItem Pop()
        {
            top -= 1;
            return items[top];
        }

        public IEnumerable<IToken> Pop(int n)
        {
            top -= n;

            for (var i = top; i < top + n; ++i)
            {
                yield return items[i].Token;
            }
        }

        public int State => top == 0 ? 0 : items[top - 1].State;

        public string DD()
        {
            return $"[0,{string.Join(",",DDD())}]";

            IEnumerable<string> DDD()
            {
                for (var i = 0; i < top; ++i)
                {
                    yield return items[i].DD();
                }
            }
        }
    }
}
