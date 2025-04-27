using System.Runtime.InteropServices;
using LibAvifSharp;

[StructLayout(LayoutKind.Sequential)]
internal struct AvifScalingMode
{
    AvifFraction Horizontal;
    AvifFraction Vertical;
}