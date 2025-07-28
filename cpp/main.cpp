#include <iostream>
//#include "test.h"
#include "call.h"

int main() 
{
    std::cout << "test" << "\n";

    IMyExport* ptr = CreateMyExportInstance();

    std::cout << "ptr!" << (void*)ptr << "\n";

    std::cout << ptr->GetCurrentUserId() << "\n";

    ptr->Start();
    std::cout << "Start!" << "\n";

    ptr->Stop();
    std::cout << "Stop!" << "\n";

    DestroyMyExportInstance(ptr);
    std::cout << "Free!" << "\n";


	return 0;
}