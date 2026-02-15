using System.Runtime.InteropServices;

internal static class Helpers
{
    public static unsafe nint ToIntPtr<T>(this T struct_t) where T : unmanaged
    {
        nint allocatedPointer = Marshal.AllocHGlobal(sizeof(T));
        T* typeTPointer = (T*)allocatedPointer;
        *typeTPointer = struct_t;
        return allocatedPointer;
    }
}
