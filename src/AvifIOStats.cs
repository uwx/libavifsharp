using System.Runtime.InteropServices;

namespace LibAvifSharp;

[StructLayout(LayoutKind.Sequential)]
internal struct AvifIOStats
{
    // Size in bytes of the AV1 image item or track data containing color samples.
    nuint ColorOBUSize;
    // Size in bytes of the AV1 image item or track data containing alpha samples.
    nuint AlphaOBUSize;
} 