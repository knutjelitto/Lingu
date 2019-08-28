#include <windows.h>

#include "CoreConsole.h"

void Core_Console_Write(const String* string)
{
    HANDLE handle = GetStdHandle(STD_OUTPUT_HANDLE);
    unsigned long written;
    WriteFile(handle, string->Bytes, string->Length, &written, NULL);
}

const Console ConsoleInstance =
{
    &_Console_VTable
};

static const Console* New(void)
{
    return &ConsoleInstance;
}

const Console_VTable _Console_VTable =
{
    BaseType(Console, Object),
    &Object_GetHashCode,
    &Object_ToString,
    &Core_Console_Write
};

const Console_Static _Console_Static =
{
    &New,
    &Core_Console_Write
};

static const String _name = STRING("Core.Console");

const Console_Type _Console_Type =
{
    sizeof(Console),
    &_name
};
