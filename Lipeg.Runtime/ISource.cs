﻿using System;

namespace Lipeg.Runtime
{
    public interface ISource
    {
        string Name { get; }
        int this[int index] { get; }
        (int lineNo, int colNo) GetLineCol(int index);
        string GetText(int start, int length);
        bool AtEnd(int offset);

        bool StartsWith(int offset, string start);

        IContext Start();
    }
}
