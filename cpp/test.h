#ifndef IMYEXPORT_H
#define IMYEXPORT_H
#pragma once

class IMyExport
{
public:
    virtual unsigned GetCurrentUserId() = 0;
    virtual void Start() = 0;
    virtual void Stop() = 0;
};

class IMyExportV2 : IMyExport
{
public:
    virtual unsigned GetCurrentUserId() = 0;
    virtual void Start() = 0;
    virtual void Stop() = 0;
    virtual void Run() = 0;
};

#endif // IMYEXPORT_H