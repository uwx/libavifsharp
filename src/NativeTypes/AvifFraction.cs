using System.Runtime.InteropServices;

namespace LibAvifSharp.NativeTypes;

[StructLayout(LayoutKind.Sequential)]
internal struct AvifFraction
{
    int Numerator;
    int Denomninator;
}