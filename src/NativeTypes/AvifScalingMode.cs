using System.Runtime.InteropServices;

namespace LibAvifSharp.NativeTypes;

[StructLayout(LayoutKind.Sequential)]
internal struct AvifScalingMode
{
    AvifFraction Horizontal;
    AvifFraction Vertical;
}