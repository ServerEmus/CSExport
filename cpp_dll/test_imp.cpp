#include "test_imp.h"

static unsigned id = 0;

TestImp::TestImp()
{
    std::cout << "TestImp" << "\n";
}

unsigned TestImp::GetCurrentUserId()
{
    std::cout << "TestImp.GetCurrentUserId" << "\n";
    return id++;
}

void TestImp::Start()
{
    std::cout << "TestImp.Start" << "\n";
}

void TestImp::Stop()
{
    std::cout << "TestImp.Stop" << "\n";
}