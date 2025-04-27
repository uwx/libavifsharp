using System.Runtime.InteropServices;

namespace LibAvifSharp;

[StructLayout(LayoutKind.Sequential)]
internal struct AvifFraction
{
    int Numerator;
    int Denomninator;
}