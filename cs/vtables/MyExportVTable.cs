using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct MyExportVTable
{
    public delegate* unmanaged[Cdecl]<IntPtr, uint> GetCurrentUserId;
    public delegate* unmanaged[Cdecl]<IntPtr, void> Start;
    public delegate* unmanaged[Cdecl]<IntPtr, void> Stop;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct MyExportInstance
{
    public MyExportVTable* VTable;
    public GCHandle Handle; // Holds the C# object instance
}