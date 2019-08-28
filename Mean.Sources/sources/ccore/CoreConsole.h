#pragma once

#include "CoreString.h"

Commons(Console);

typedef struct Console_
{

    const Console_VTable* _vtable;
}
Console;

typedef struct Console_VTable_
{
    struct Object_VTable_;
    void (*Write)(const String*);
}
Console_VTable;

typedef struct Console_Static_
{
    const Console* (*New)(void);
    void (*Write)(const String*);
}
Console_Static;

typedef struct Console_Type_
{
    const int ObjectSize;
    const String* const Name;
}
Console_Type;

extern void Core_Console_Write(const String* string);
extern const Console ConsoleInstance;
