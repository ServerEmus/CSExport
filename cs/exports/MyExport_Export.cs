using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using testexport.StaticCalls;
using testexport.vtables;

public static unsafe class MyExportExports
{
    [UnmanagedCallersOnly(EntryPoint = "CreateMyExport", CallConvs = [typeof(CallConvCdecl)])]
    public static IntPtr CreateMyExport(int version)
    {
        SimpleExport export = new()
        {
            version = version,
            VTable = CreateMyExportPTRVersion(version)
        };
        return export.ToIntPtr();
    }

    [UnmanagedCallersOnly(EntryPoint = "MyExport_GetCurrentUserId", CallConvs = [typeof(CallConvCdecl)])]
    public static uint EXPORT_MyExport_GetCurrentUserId(IntPtr pThis)
    {
        return MyExportCalls.GetCurrentUserId(pThis);
    }

    [UnmanagedCallersOnly(EntryPoint = "MyExport_Start", CallConvs = [typeof(CallConvCdecl)])]
    public static void EXPORT_MyExport_Start(IntPtr pThis)
    {
        MyExportCalls.Start(pThis);
    }

    [UnmanagedCallersOnly(EntryPoint = "MyExport_Stop", CallConvs = [typeof(CallConvCdecl)])]
    public static void EXPORT_MyExport_Stop(IntPtr pThis)
    {
        MyExportCalls.Stop(pThis);
    }

    [UnmanagedCallersOnly(EntryPoint = "MyExport_Run", CallConvs = [typeof(CallConvCdecl)])]
    public static void EXPORT_MyExport_Run(IntPtr pThis)
    {
        MyExportCalls.Run(pThis);
    }

    [UnmanagedCallersOnly(EntryPoint = "MyExport_ETestCall", CallConvs = [typeof(CallConvCdecl)])]
    public static void EXPORT_MyExport_ETestCall(IntPtr pThis, ETest etest)
    {
        MyExportCalls.ETestCall(pThis, etest);
    }

    [UnmanagedCallersOnly(EntryPoint = "MyExport_InputTest", CallConvs = [typeof(CallConvCdecl)])]
    public static uint EXPORT_MyExport_InputTest(IntPtr ptr, int e)
    {
        return MyExportCalls.InputTest(ptr, e);
    }

    [UnmanagedCallersOnly(EntryPoint = "MyExport_RefTest", CallConvs = [typeof(CallConvCdecl)])]
    public static void EXPORT_MyExport_RefTest(IntPtr ptr, IntPtr e)
    {
        int _e = Marshal.ReadInt32(e);
        MyExportCalls.RefTest(ptr, ref _e);
        Marshal.WriteInt32(e, _e);
    }

    [UnmanagedCallersOnly(EntryPoint = "FreeMyExport", CallConvs = [typeof(CallConvCdecl)])]
    public static void FreeMyExport(IntPtr pThis)
    {
        if (pThis == IntPtr.Zero) 
            return;
        Marshal.FreeHGlobal(pThis);
    }
   
    public static IntPtr CreateMyExportPTRVersion(int version)
    {
        return version switch
        {
            1 => new MyExportVTable()
            {
                GetCurrentUserId = MyExportCalls.FunctionPointers[(int)MyExportCalls.FunctionCalls.GetCurrentUserId],
                Start = MyExportCalls.FunctionPointers[(int)MyExportCalls.FunctionCalls.Start],
                Stop = MyExportCalls.FunctionPointers[(int)MyExportCalls.FunctionCalls.Stop],
            }.ToIntPtr(),
            2 => new MyExportVTable2()
            {
                GetCurrentUserId = MyExportCalls.FunctionPointers[(int)MyExportCalls.FunctionCalls.GetCurrentUserId],
                Start = MyExportCalls.FunctionPointers[(int)MyExportCalls.FunctionCalls.Start],
                Stop = MyExportCalls.FunctionPointers[(int)MyExportCalls.FunctionCalls.Stop],
                Run = MyExportCalls.FunctionPointers[(int)MyExportCalls.FunctionCalls.Run],
                ETestCall = MyExportCalls.FunctionPointers[(int)MyExportCalls.FunctionCalls.ETestCall],
                InputTest = MyExportCalls.FunctionPointers[(int)MyExportCalls.FunctionCalls.InputTest],
            }.ToIntPtr(),
            3 => new MyExportVTable3()
            {
                GetCurrentUserId = MyExportCalls.FunctionPointers[(int)MyExportCalls.FunctionCalls.GetCurrentUserId],
                Start = MyExportCalls.FunctionPointers[(int)MyExportCalls.FunctionCalls.Start],
                Stop = MyExportCalls.FunctionPointers[(int)MyExportCalls.FunctionCalls.Stop],
                Run = MyExportCalls.FunctionPointers[(int)MyExportCalls.FunctionCalls.Run],
                ETestCall = MyExportCalls.FunctionPointers[(int)MyExportCalls.FunctionCalls.ETestCall],
                InputTest = MyExportCalls.FunctionPointers[(int)MyExportCalls.FunctionCalls.InputTest],
            }.ToIntPtr(),
            4 => new MyExportVTable4()
            {
                GetCurrentUserId = MyExportCalls.FunctionPointers[(int)MyExportCalls.FunctionCalls.GetCurrentUserId],
                Start = MyExportCalls.FunctionPointers[(int)MyExportCalls.FunctionCalls.Start],
                Stop = MyExportCalls.FunctionPointers[(int)MyExportCalls.FunctionCalls.Stop],
                Run = MyExportCalls.FunctionPointers[(int)MyExportCalls.FunctionCalls.Run],
                ETestCall = MyExportCalls.FunctionPointers[(int)MyExportCalls.FunctionCalls.ETestCall],
                InputTest = MyExportCalls.FunctionPointers[(int)MyExportCalls.FunctionCalls.InputTest],
                RefTest = MyExportCalls.FunctionPointers[(int)MyExportCalls.FunctionCalls.RefTest],
            }.ToIntPtr(),
            _ => 0,
        };
    }
}