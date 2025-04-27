using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential)]
internal struct AvifPixelAspectRatioBox
{
    public uint HSpacing;
    public uint VSpacing;

}