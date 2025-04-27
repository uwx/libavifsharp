using System;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential)]
public struct AvifRWData
{
    public IntPtr Data; // Corresponds to uint8_t * data;
    public UIntPtr Size; // Corresponds to size_t size;
}