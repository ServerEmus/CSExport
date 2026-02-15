public static class MyExport
{
    static uint UserId = 42;
    static bool IsRunning = false;
    static int count = 0;

    public static uint GetCurrentUserId()
    {
        return UserId;
    }
    public static void Start()
    {
        UserId++;
        IsRunning = true;
    }
    public static void Stop()
    {
        IsRunning = false;
    }

    public static void Run()
    {
        if (IsRunning)
            count++;
    }

    public static void ETestCall(ETest etest)
    {

    }

    public static uint InputTest(int e)
    {
        var ret = e += 1;
        return (uint)ret;
    }

    public static void RefTest(ref int ref_int_test)
    {
        ref_int_test += 1;
    }
}

public enum ETest
{
    k_TEST_Invalid = 0,
    k_TEST_Testing = 1,
    k_TEST_Max = 2
};