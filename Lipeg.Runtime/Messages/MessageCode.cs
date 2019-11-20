using System;
using System.Collections.Generic;
using System.Text;

namespace Lipeg.Runtime
{
    public enum MessageCode
    {
        SourceFileNotFound = 1,
        AlreadyDefinedOption = 101,
        UndefinedOptionValue,
        IllegalOptionValue,
        UnknownOption,
        AlreadyDefinedRule = 201,
        RedefinedRule,
        UndefinedRule,
        UnusedRule,
        UnreachableRule,
        NullableManyContent,
    }
}
