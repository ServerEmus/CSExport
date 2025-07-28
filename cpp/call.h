#pragma once
#include "test.h"

#define API_DLL extern "C" __declspec( dllimport ) 

API_DLL IMyExport* CreateMyExportInstance();
API_DLL unsigned IMyExport_GetCurrentUserId(IMyExport* ptr);
API_DLL void MyExport_Start(IMyExport* ptr);
API_DLL void MyExport_Stop(IMyExport* ptr);
API_DLL void DestroyMyExportInstance(IMyExport* ptr);