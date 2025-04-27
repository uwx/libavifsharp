using System.Runtime.InteropServices;

namespace LibAvifSharp;

[StructLayout(LayoutKind.Sequential)]
internal struct AvifRGBImage
{
    public uint Width;
    public uint Height;
    public uint Depth;
    public AvifRGBFormat Format;
    public AvifChromaUpsampling ChromaUpsampling;
    public AvifChromaDownsampling ChromaDownsampling;
    public AvifBool AvoidLibYUV;
    public AvifBool IgnoreAlpha;
    public AvifBool AlphaPremultiplied;
    public AvifBool IsFloat;
    public int MaxThreads;

    public IntPtr Pixels; // Corresponds to uint8_t * pixels;
    public uint RowBytes;
}