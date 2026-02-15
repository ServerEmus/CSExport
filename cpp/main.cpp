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
    ptr2->ETestCall(ETest::k_TEST_Invalid);
    MyExport_ETestCall((IMyExport*)ptr2, ETest::k_TEST_Testing);
    ptr2->ETestCall(ETest::k_TEST_Invalid);


    IMyExportV4* ptr4 = (IMyExportV4*)CreateMyExport(4);
    int ee = 555;
    ptr4->RefTest(&ee);
    std::cout << "ee:" << ee << "\n";
    int e = 5;
    unsigned ret = ptr2->InputTest(e);
    std::cout << "e:" << e << "\n";
    std::cout << "ret:" << ret << "\n";

    std::cout << "ptr!" << (void*)ptr2 << "\n";

    std::cout << "IMyExportV2 size " << sizeof(IMyExportV2) << std::endl;

    uint64_t* layout = (uint64_t*)(void*)ptr2;

    // print the layout of
    for (int i = 0; i < 3; ++i) {
        std::cout << "layout [" << i << "] = " << layout[i] << std::endl;
    }
    std::cout << "=========" << std::endl;

    uint64_t* vtable = (uint64_t*)layout[0];

    for (int i = 0; i < 8; ++i) {
        std::cout << "vtable [" << i << "] = " << vtable[i] << std::endl;
    }

    std::cout << "=========" << std::endl;

    FreeMyExport(ptr);
    std::cout << "Free!" << "\n";


	return 0;
}