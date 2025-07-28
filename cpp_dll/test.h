#ifndef IMYEXPORT_H
#define IMYEXPORT_H
#pragma once

#include <iostream>

class IMyExport
{
public:
	virtual unsigned GetCurrentUserId() = 0;
    virtual void Start() = 0;
    virtual void Stop() = 0;
};

#endif // IMYEXPORT_H