﻿using System.Collections.Generic;

namespace Lingu.Runtime.Parsing
{
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

        public int State => top == 0 ? 0 : items[top - 1].State;
    }
}
