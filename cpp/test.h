#ifndef IMYEXPORT_H
#define IMYEXPORT_H
#pragma once

enum ETest
{
    k_TEST_Invalid = 0,
    k_TEST_Testing = 1,
    k_TEST_Max = 2
};

struct SteamIPAddress_t
{
    union {

        unsigned int			m_unIPv4;		// Host order
        unsigned char			m_rgubIPv6[16];		// Network order! Same as inaddr_in6.  (0011:2233:4455:6677:8899:aabb:ccdd:eeff)

        // Internal use only
        unsigned long			m_ipv6Qword[2];	// big endian
    };

    int m_eType;
};


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
    virtual void ETestCall(ETest tt) = 0;
    virtual unsigned InputTest(int e) = 0;
};

class IMyExportV4 : IMyExport
{
public:
    virtual unsigned GetCurrentUserId() = 0;
    virtual void Start() = 0;
    virtual void Stop() = 0;
    virtual void Run() = 0;
    virtual void ETestCall(ETest tt) = 0;
    virtual unsigned InputTest(int e) = 0;
    virtual void RefTest(int* e) = 0;
};



#endif // IMYEXPORT_H