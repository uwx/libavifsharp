using System.Runtime.InteropServices;

namespace LibAvifSharp.NativeTypes;

[StructLayout(LayoutKind.Sequential)]
internal struct AvifDiagnostics
{
    private const int AVIF_DIAGNOSTICS_ERROR_BUFFER_SIZE = 256;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = AVIF_DIAGNOSTICS_ERROR_BUFFER_SIZE)]
    public string Error;
}