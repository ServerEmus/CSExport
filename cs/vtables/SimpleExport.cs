using System.Runtime.InteropServices;

namespace testexport.vtables;

[StructLayout(LayoutKind.Sequential, Pack = 8)]
public unsafe struct SimpleExport
{
    public nint VTable; // Our VTable
    public int version; // VTable version.
}