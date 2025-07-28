using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

public static unsafe class MyExportExports
{

    [UnmanagedCallersOnly(EntryPoint = "CreateMyExportInstance", CallConvs = [typeof(CallConvCdecl)])]
    public static MyExportInstance* CreateMyExportInstance() // we might need to make it as InPtr.
    {
        var instance = new MyExport();
        var handle = GCHandle.Alloc(instance);
        var native = (MyExportInstance*)NativeMemory.Alloc((nuint)sizeof(MyExportInstance));
        MyExportVTable vtable = new()
        {
            GetCurrentUserId = &MyExport_GetCurrentUserId,
            Start = &MyExport_Start,
            Stop = &MyExport_Stop
        };
        native->VTable = &vtable;
        native->Handle = handle;
        return native;
    }

    [UnmanagedCallersOnly(EntryPoint = "MyExport_GetCurrentUserId", CallConvs = [typeof(CallConvCdecl)])]
    public static uint MyExport_GetCurrentUserId(IntPtr pThis)
    {
        var inst = (MyExportInstance*)pThis;
        var obj = (MyExport)inst->Handle.Target!;
        return obj.GetCurrentUserId();
    }

    [UnmanagedCallersOnly(EntryPoint = "MyExport_Start", CallConvs = [typeof(CallConvCdecl)])]
    public static void MyExport_Start(IntPtr pThis)
    {
        var inst = (MyExportInstance*)pThis;
        var obj = (MyExport)inst->Handle.Target!;
        obj.Start();
    }

    [UnmanagedCallersOnly(EntryPoint = "MyExport_Stop", CallConvs = [typeof(CallConvCdecl)])]
    public static void MyExport_Stop(IntPtr pThis)
    {
        var inst = (MyExportInstance*)pThis;
        var obj = (MyExport)inst->Handle.Target!;
        obj.Stop();
    }

    [UnmanagedCallersOnly(EntryPoint = "DestroyMyExportInstance", CallConvs = [typeof(CallConvCdecl)])]
    public static void DestroyMyExportInstance(MyExportInstance* pThis) // this might not work here.
    {
        if (pThis == null) return;
        pThis->Handle.Free();
        NativeMemory.Free(pThis);
    }
}