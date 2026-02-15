using System.Runtime.InteropServices;

namespace testexport.vtables;

[StructLayout(LayoutKind.Sequential, Pack = 8)]
public unsafe struct MyExportVTable4
{
    public nint GetCurrentUserId;
    public nint Start;
    public nint Stop;
    public nint Run;
    public nint ETestCall;
    public nint InputTest;
    public nint RefTest;
}