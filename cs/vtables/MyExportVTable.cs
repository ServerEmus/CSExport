using System.Runtime.InteropServices;

namespace testexport.vtables;

[StructLayout(LayoutKind.Sequential, Pack = 8)]
public unsafe struct MyExportVTable
{
    public nint GetCurrentUserId;
    public nint Start;
    public nint Stop;
}