using Lipeg.SDK.Output;
using System;
using System.Collections.Generic;
using System.Text;
using Lipeg.SDK.Tree;

namespace Lipeg.SDK.Dump
{
    public interface IDump<T>
    {
        void Dump(Grammar grammar, IWriter writer, T subject);
    }
}
