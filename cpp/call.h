#ifndef CALL_H
#define CALL_H
#pragma once

#include <string>

#ifdef WIN32
#define WIN32_LEAN_AND_MEAN
#include <windows.h>
#endif

#define CALLTYPE __cdecl
#define DLL __declspec( dllimport )

#include "test.h"

#pragma comment(lib, "../Out/LIB/testexport.lib")
/*
#ifdef __cplusplus
extern "C"
{
#endif

DLL IMyExport* CALLTYPE CreateMyExportInstance();


#ifdef __cplusplus
}
#endif*/
//#define API_DLL extern "C" __declspec( dllimport )
/*
API_DLL IMyExport* CALLTYPE CreateMyExportInstance();
API_DLL unsigned CALLTYPE MyExport_GetCurrentUserId( IMyExport* ptr );
API_DLL void CALLTYPE MyExport_Start( IMyExport* ptr );
API_DLL void CALLTYPE MyExport_Stop( IMyExport* ptr) ;
API_DLL void CALLTYPE DestroyMyExportInstance( IMyExport* ptr );
*/
#endif // CALL_H