#include "common.h"
#include "test_imp.h"

IMyExport* CreateMyExportInstance()
{
    std::cout << "CreateMyExportInstance" << "\n";
    TestImp* test = (TestImp*)malloc(sizeof(TestImp));
    return static_cast<IMyExport *>(test);
}

unsigned MyExport_GetCurrentUserId( IMyExport* ptr )
{
    std::cout << "MyExport_GetCurrentUserId" << "\n";
    return ptr->GetCurrentUserId();
}

void MyExport_Start( IMyExport* ptr )
{
    std::cout << "MyExport_Start" << "\n";
    ptr->Start();
}

void MyExport_Stop( IMyExport* ptr )
{
    std::cout << "MyExport_Stop" << "\n";
    ptr->Stop();
}

void DestroyMyExportInstance( IMyExport* ptr )
{
    std::cout << "DestroyMyExportInstance" << "\n";
    free(ptr);
}