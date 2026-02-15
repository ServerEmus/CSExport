namespace testexport.StaticCalls;

internal static class MyExportCalls
{
    public enum FunctionCalls
    {
        GetCurrentUserId,
        Start,
        Stop,
        Run,
        ETestCall,
        InputTest,
        RefTest,
        MAX
    }

    public static nint[] FunctionPointers = new nint[(int)FunctionCalls.MAX];

    static MyExportCalls()
    {
        unsafe
        {
            FunctionPointers[(int)FunctionCalls.GetCurrentUserId] = (nint)(delegate* unmanaged[Cdecl]<nint, uint>)&MyExportExports.EXPORT_MyExport_GetCurrentUserId;
            FunctionPointers[(int)FunctionCalls.Start] = (nint)(delegate* unmanaged[Cdecl]<nint, void>)&MyExportExports.EXPORT_MyExport_Start;
            FunctionPointers[(int)FunctionCalls.Stop] = (nint)(delegate* unmanaged[Cdecl]<nint, void>)&MyExportExports.EXPORT_MyExport_Stop;
            FunctionPointers[(int)FunctionCalls.Run] = (nint)(delegate* unmanaged[Cdecl]<nint, void>)&MyExportExports.EXPORT_MyExport_Run;
            FunctionPointers[(int)FunctionCalls.ETestCall] = (nint)(delegate* unmanaged[Cdecl]<nint, ETest, void>)&MyExportExports.EXPORT_MyExport_ETestCall;
            FunctionPointers[(int)FunctionCalls.InputTest] = (nint)(delegate* unmanaged[Cdecl]<nint, int, uint>)&MyExportExports.EXPORT_MyExport_InputTest;
            FunctionPointers[(int)FunctionCalls.RefTest] = (nint)(delegate* unmanaged[Cdecl]<nint, nint, void>)&MyExportExports.EXPORT_MyExport_RefTest;
        }
    }

    public static uint GetCurrentUserId(IntPtr pThis)
    {
        return MyExport.GetCurrentUserId();
    }

    public static void Start(IntPtr pThis)
    {
        MyExport.Start();
    }

    public static void Stop(IntPtr pThis)
    {
        MyExport.Stop();
    }

    public static void Run(IntPtr pThis)
    {
        MyExport.Run();
    }

    public static void ETestCall(IntPtr pThis, ETest test)
    {
        MyExport.ETestCall(test);
    }

    public static uint InputTest(IntPtr pThis, int e)
    {
        return MyExport.InputTest(e);
    }

    public static void RefTest(IntPtr pThis, ref int ref_int_test)
    {
        MyExport.RefTest(ref ref_int_test);
    }
}
