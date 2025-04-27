using System.Runtime.InteropServices;

namespace LibAvifSharp.NativeTypes;

[StructLayout(LayoutKind.Sequential)]
internal struct AvifPixelAspectRatioBox
{
    public uint HSpacing;
    public uint VSpacing;

}