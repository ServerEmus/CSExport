
#include "test_imp.h"

static unsigned id = 0;

unsigned TestImp::GetCurrentUserId()
{
    return id++;
}

void TestImp::Start()
{

}

void TestImp::Stop()
{
    
}