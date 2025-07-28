

#include "test.h"

class TestImp :
public IMyExport
{
public:
	unsigned GetCurrentUserId();
    void Start();
    void Stop();
}