#pragma once
#include "test.h"
#include <string.h>

#ifdef WIN32
#define WIN32_LEAN_AND_MEAN
#include <windows.h>
#endif

#define CALLTYPE __cdecl
#define API_DLL extern "C" __declspec( dllimport ) 

API_DLL IMyExport* CALLTYPE CreateMyExportInstance();
API_DLL unsigned CALLTYPE MyExport_GetCurrentUserId( IMyExport* ptr );
API_DLL void CALLTYPE MyExport_Start( IMyExport* ptr );
API_DLL void CALLTYPE MyExport_Stop( IMyExport* ptr) ;
API_DLL void CALLTYPE DestroyMyExportInstance( IMyExport* ptr );