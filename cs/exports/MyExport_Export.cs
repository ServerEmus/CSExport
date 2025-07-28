using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

public static unsafe class MyExportExports
{
    static MyExportVTable vtable = new MyExportVTable
    {
        GetCurrentUserId = &GetCurrentUserIdImpl,
        Start = &StartImpl,
        Stop = &StopImpl
    };

    [UnmanagedCallersOnly(EntryPoint = "CreateMyExportInstance")]
    public static MyExportInstance* CreateMyExportInstance()
    {
        var instance = new MyExport();
        var handle = GCHandle.Alloc(instance);
        var native = (MyExportInstance*)NativeMemory.Alloc((nuint)sizeof(MyExportInstance));
        native->VTable = &vtable;
        native->Handle = handle;
        return native;
    }

    [UnmanagedCallersOnly]
    public static uint GetCurrentUserIdImpl(IntPtr pThis)
    {
        var inst = (MyExportInstance*)pThis;
        var obj = (MyExport)inst->Handle.Target!;
        return obj.GetCurrentUserId();
    }

    [UnmanagedCallersOnly]
    public static void StartImpl(IntPtr pThis)
    {
        var inst = (MyExportInstance*)pThis;
        var obj = (MyExport)inst->Handle.Target!;
        obj.Start();
    }

    [UnmanagedCallersOnly]
    public static void StopImpl(IntPtr pThis)
    {
        var inst = (MyExportInstance*)pThis;
        var obj = (MyExport)inst->Handle.Target!;
        obj.Stop();
    }

    [UnmanagedCallersOnly(EntryPoint = "DestroyMyExportInstance")]
    public static void DestroyMyExportInstance(MyExportInstance* pThis)
    {
        if (pThis == null) return;
        pThis->Handle.Free();
        NativeMemory.Free(pThis);
    }
}