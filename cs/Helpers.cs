using System.Runtime.InteropServices;

internal static class Helpers
{

    public static IntPtr ToIntPtr<T>(this T struct_t) where T : struct
    {
        var ptr = Marshal.AllocHGlobal(Marshal.SizeOf<T>());
        Marshal.StructureToPtr(struct_t, ptr, false);
        return ptr;
    }

}
