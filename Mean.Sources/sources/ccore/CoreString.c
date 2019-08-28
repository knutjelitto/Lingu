#include <stdint.h>
#include "CoreString.h"

static int GetHashCode(const Object* string)
{
#pragma ref string
    return 43;
}

static const String* ToString(const Object* string)
{
    uint64_t x;
    return (const String*)string;
}


static String New(const char* chars, int length)
{
    String string = { &_String_VTable, length, chars };
    return string;
}

const String_VTable _String_VTable =
{ 
    BaseType(String, Object),
    &GetHashCode,
    &ToString
};

const String_Static _String_Static =
{
    &New
};

static const String _name = STRING("Core.String");

const String_Type _String_Type =
{
    sizeof(String),
    &_name
};

const TypeOfString _TypeOfString =
{
    sizeof(String),
    &_name
};
