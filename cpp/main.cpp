#include <iostream>
//#include "test.h"
#include "call.h"

struct My_Struct {
    uint64_t x3 = 3333;
    uint64_t y3 = 33333333;

    virtual void MyFn_3()
    {
        std::cout << "I'm My_Struct::MyFn_3()" << std::endl;
    }

    virtual void MyOtherFn_3()
    {
        std::cout << "I'm My_Struct::MyOtherFn_3()" << std::endl;
    }
};

int main() 
{
    std::cout << "test" << "\n";

    My_Struct ss1{};
    IMyExport* ptr = CreateMyExport(1);

    std::cout << ptr->GetCurrentUserId() << "\n";
    ptr->Start();
    std::cout << ptr->GetCurrentUserId() << "\n";
    ptr->Stop();

    IMyExportV2* ptr2 = (IMyExportV2*)CreateMyExport(2);

    std::cout << ptr2->GetCurrentUserId() << "\n";
    ptr2->Start();
    std::cout << ptr2->GetCurrentUserId() << "\n";
    ptr2->Stop();
    ptr2->Run();

    
    std::cout << "ptr!" << (void*)ptr << "\n";

    std::cout << "IMyExport size " << sizeof(IMyExport) << std::endl;
    std::cout << "My_Struct size " << sizeof(My_Struct) << std::endl;

    uint64_t* layout = (uint64_t*)(void*)ptr;

    uint64_t* layout_ms = (uint64_t*)(void*)&ss1;

    // print the layout of
    for (int i = 0; i < 3; ++i) {
        std::cout << "layout [" << i << "] = " << layout[i] << std::endl;
    }
    std::cout << "=========" << std::endl;

    // print the layout of
    for (int i = 0; i < 3; ++i) {
        std::cout << "layout [" << i << "] = " << layout_ms[i] << std::endl;
    }
    std::cout << "=========" << std::endl;

    uint64_t* vtable = (uint64_t*)layout[0];

    for (int i = 0; i < 8; ++i) {
        std::cout << "vtable [" << i << "] = " << vtable[i] << std::endl;
    }

    std::cout << "=========" << std::endl;

    uint64_t* vtable_ms = (uint64_t*)layout_ms[0];

    for (int i = 0; i < 8; ++i) {
        std::cout << "vtable [" << i << "] = " << vtable_ms[i] << std::endl;
    }
    
    FreeMyExport(ptr);
    std::cout << "Free!" << "\n";


	return 0;
}