#pragma once

#include "CoreObject.h"

#define STRING(s) { &_String_VTable, STRLEN(s), s}

Commons(String);

typedef struct String_
{
    const String_VTable* _vtable;
    const int   Length;
    const char* const Bytes;
}
String;

typedef struct String_VTable_
{
    Object_VTable;
}
String_VTable;

typedef struct String_Static_
{
    String (*New)(const char*, int);
}
String_Static;

typedef struct String_Type_
{
    const int ObjectSize;
    const String* const Name;
}
String_Type;

typedef struct TypeOfString_
{
    const int ObjectSize;
    const String* const Name;
}
TypeOfString;
