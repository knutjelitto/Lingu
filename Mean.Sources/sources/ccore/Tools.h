#pragma once

#include <stdint.h>

typedef unsigned int bool;

#define STRLEN(s) (sizeof(s)/sizeof(s[0])-sizeof(s[0]))

#define Commons(type)\
    typedef struct type##_ type;\
    typedef struct type##_VTable_ type##_VTable;\
    typedef struct type##_Static_ type##_Static;\
    typedef struct type##_Type_ type##_Type;\
    typedef struct TypeOf##type##_ TypeOf##type;\
    extern const type##_VTable _##type##_VTable;\
    extern const type##_Static _##type##_Static;\
    extern const type##_Type _##type##_Type;\
    extern const TypeOf##type _TypeOf##type


#define BaseType(type, base)\
    (const base##_Type*)&_##type##_Type
