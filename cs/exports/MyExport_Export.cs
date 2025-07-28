using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

public static unsafe class MyExportExports
{

    public delegate uint GetCurrentUserId(IntPtr ptr);
    public delegate void GenericVoidCall(IntPtr ptr);

    [UnmanagedCallersOnly(EntryPoint = "CreateMyExport", CallConvs = [typeof(CallConvCdecl)])]
    public static IntPtr CreateMyExport(int version)
    {
        SimpleExport export = new()
        { 
            Handle = GCHandle.Alloc(new MyExport()),
            VTable = CreateMyExportPTRVersion(version)
        };
        return export.ToIntPtr();
    }

    [UnmanagedCallersOnly(EntryPoint = "MyExport_GetCurrentUserId", CallConvs = [typeof(CallConvCdecl)])]
    public static uint EXPORT_MyExport_GetCurrentUserId(IntPtr pThis)
    {
        return MyExport_GetCurrentUserId(pThis);
    }

    [UnmanagedCallersOnly(EntryPoint = "MyExport_Start", CallConvs = [typeof(CallConvCdecl)])]
    public static void EXPORT_MyExport_Start(IntPtr pThis)
    {
        MyExport_Start(pThis);
    }

    [UnmanagedCallersOnly(EntryPoint = "MyExport_Stop", CallConvs = [typeof(CallConvCdecl)])]
    public static void EXPORT_MyExport_Stop(IntPtr pThis)
    {
        MyExport_Stop(pThis);
    }

    [UnmanagedCallersOnly(EntryPoint = "MyExport_Run", CallConvs = [typeof(CallConvCdecl)])]
    public static void EXPORT_MyExport_Run(IntPtr pThis)
    {
        MyExport_Run(pThis);
    }

    [UnmanagedCallersOnly(EntryPoint = "FreeMyExport", CallConvs = [typeof(CallConvCdecl)])]
    public static void FreeMyExport(IntPtr pThis)
    {
        if (pThis == IntPtr.Zero) return;
        SimpleExport export = Marshal.PtrToStructure<SimpleExport>(pThis);
        export.Handle.Free();
        Marshal.FreeHGlobal(pThis);
    }

    public static IntPtr CreateMyExportPTRVersion(int version)
    {
        return version switch 
        { 
            1 => new MyExportVTable()
            {
                GetCurrentUserId = Marshal.GetFunctionPointerForDelegate(new GetCurrentUserId(MyExport_GetCurrentUserId)),
                Start = Marshal.GetFunctionPointerForDelegate(new GenericVoidCall(MyExport_Start)),
                Stop = Marshal.GetFunctionPointerForDelegate(new GenericVoidCall(MyExport_Stop)),
            }.ToIntPtr(),
            2 => new MyExportVTable2()
            {
                GetCurrentUserId = Marshal.GetFunctionPointerForDelegate(new GetCurrentUserId(MyExport_GetCurrentUserId)),
                Start = Marshal.GetFunctionPointerForDelegate(new GenericVoidCall(MyExport_Start)),
                Stop = Marshal.GetFunctionPointerForDelegate(new GenericVoidCall(MyExport_Stop)),
                Run = Marshal.GetFunctionPointerForDelegate(new GenericVoidCall(MyExport_Run)),
            }.ToIntPtr(),
            _ => 0,
        };
    }


    public static uint MyExport_GetCurrentUserId(IntPtr pThis)
    {
        SimpleExport export = Marshal.PtrToStructure<SimpleExport>(pThis);
        var obj = (MyExport)export.Handle.Target!;
        return obj.GetCurrentUserId();
    }

    public static void MyExport_Start(IntPtr pThis)
    {
        SimpleExport export = Marshal.PtrToStructure<SimpleExport>(pThis);
        var obj = (MyExport)export.Handle.Target!;
        obj.Start();
    }

    public static void MyExport_Stop(IntPtr pThis)
    {
        SimpleExport export = Marshal.PtrToStructure<SimpleExport>(pThis);
        var obj = (MyExport)export.Handle.Target!;
        obj.Stop();
    }

    public static void MyExport_Run(IntPtr pThis)
    {
        SimpleExport export = Marshal.PtrToStructure<SimpleExport>(pThis);
        var obj = (MyExport)export.Handle.Target!;
        obj.Run();
    }
}