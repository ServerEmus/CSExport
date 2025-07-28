#ifndef TESTIMP_H
#define TESTIMP_H

#include "test.h"

class TestImp :
public IMyExport
{
public:
    TestImp();
	unsigned GetCurrentUserId();
    void Start();
    void Stop();
};

#endif // TESTIMP_H