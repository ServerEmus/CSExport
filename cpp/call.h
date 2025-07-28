#ifndef CALL_H
#define CALL_H
#pragma once

#ifdef WIN32
#define WIN32_LEAN_AND_MEAN
#include <windows.h>
#endif

#include <string>
#include <tchar.h>

#define CALLTYPE __cdecl
#define API_DLL extern "C" __declspec( dllimport )

#include "test.h"

API_DLL IMyExport* CALLTYPE CreateMyExport(int version);
API_DLL unsigned CALLTYPE MyExport_GetCurrentUserId( IMyExport* ptr );
API_DLL void CALLTYPE MyExport_Start( IMyExport* ptr );
API_DLL void CALLTYPE MyExport_Stop( IMyExport* ptr);
API_DLL void CALLTYPE MyExport_Run(IMyExport* ptr);
API_DLL void CALLTYPE FreeMyExport( IMyExport* ptr );


#endif // CALL_H