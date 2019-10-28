using Lipeg.SDK.Output;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lipeg.SDK.Dump
{
    public interface IDump<T>
    {
        void Dump(IWriter writer, T subject);
    }
}
