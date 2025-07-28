using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Pack = 8)]
public struct MyExportVTable
{
    public IntPtr GetCurrentUserId;
    public IntPtr Start;
    public IntPtr Stop;
}

[StructLayout(LayoutKind.Sequential, Pack = 8)]
public struct MyExportVTable2
{
    public IntPtr GetCurrentUserId;
    public IntPtr Start;
    public IntPtr Stop;
    public IntPtr Run;
}


[StructLayout(LayoutKind.Sequential)]
public struct SimpleExport
{
    public IntPtr VTable; // Our VTable
    public GCHandle Handle; // Holds the C# object instance
}