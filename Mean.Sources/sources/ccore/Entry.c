#include <windows.h>

#include "Tools.h"
#include "CoreConsole.h"
#include "CoreString.h"

int Entry(void)
{
    SetConsoleCP(65001);
    SetConsoleOutputCP(65001);

    String string = STRING("XYZäöü");

    _Console_Static.Write(&string);

    return _String_VTable.GetHashCode((Object*)& string);
}

//int __cdecl atexit(void(__cdecl* x)(void) ) { return 0; }

