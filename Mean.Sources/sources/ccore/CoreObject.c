#include "Tools.h"
#include "CoreObject.h"
#include "CoreString.h"

extern int Object_GetHashCode(const Object* object)
{
    return ((int*)object)[0] ^ ((int*)object)[1];
}

extern const String* Object_ToString(const Object* object)
{
    return object->_vtable->Type->Name;
}

const Object ObjectInstance =
{
    &_Object_VTable
};


const Object* New(void)
{
    return &ObjectInstance;
}

const Object_VTable _Object_VTable =
{ 
    &_Object_Type,
    &Object_GetHashCode,
    &Object_ToString,
};

const Object_Static _Object_Static =
{
    &New
};

static const String _name = STRING("Core.Object");

const Object_Type _Object_Type =
{
    sizeof(Object),
    & _name
};
