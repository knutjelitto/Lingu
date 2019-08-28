#pragma once

#include "Tools.h"

typedef struct String_ String;

Commons(Object);

typedef struct Object_
{
    const Object_VTable* _vtable;
}
Object;

typedef struct Object_VTable_
{
    const Object_Type* Type;
    int (*GetHashCode)(const Object*);
    const String* (*ToString)(const Object*);
}
Object_VTable;

typedef struct Object_Static_
{
    const Object* (*New)(void);
}
Object_Static;

typedef struct Object_Type_
{
    const int ObjectSize;
    const String* const Name;
}
Object_Type;

extern int Object_GetHashCode(const Object* object);
extern const String* Object_ToString(const Object* object);
