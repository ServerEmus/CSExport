#ifndef COMMON_H
#define COMMON_H
#pragma once

#ifdef WIN32
#define WIN32_LEAN_AND_MEAN
#include <windows.h>
#endif

#include <string>
#include <tchar.h>

#define CALLTYPE __cdecl
#define DLL __declspec( dllexport )

#include "test.h"

DLL IMyExport* CALLTYPE CreateMyExportInstance();
DLL unsigned CALLTYPE MyExport_GetCurrentUserId( IMyExport* ptr );
DLL void CALLTYPE MyExport_Start( IMyExport* ptr );
DLL void CALLTYPE MyExport_Stop( IMyExport* ptr );
DLL void CALLTYPE DestroyMyExportInstance( IMyExport* ptr );

#endif // COMMON_H