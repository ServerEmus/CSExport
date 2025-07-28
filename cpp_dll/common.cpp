#include "common.h"

IMyExport* CreateMyExportInstance()
{
    return NULL;
}

unsigned MyExport_GetCurrentUserId( IMyExport* ptr )
{
    return 0;
}

void MyExport_Start( IMyExport* ptr )
{

}

void MyExport_Stop( IMyExport* ptr )
{

}

void DestroyMyExportInstance( IMyExport* ptr )
{

}