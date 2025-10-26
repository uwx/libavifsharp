using System.Reflection;
using System.Runtime.InteropServices;
using LibAvifSharp.NativeTypes;

internal static partial class NativeInterop
{
    [LibraryImport("avif")]
    public static partial IntPtr avifImageCreate(uint width, uint height, uint depth, AvifPixelFormat yuvFormat);

    [LibraryImport("avif")]
    public static partial IntPtr avifEncoderCreate();

    [LibraryImport("avif")]
    public static partial AvifResult avifEncoderAddImage(IntPtr encoder, IntPtr image, ulong duration, AvifAddImageFlag flags);

    [LibraryImport("avif")]
    public static partial  AvifResult avifEncoderFinish(IntPtr encoder, ref AvifRWData output);

    [LibraryImport("avif")]
    public static partial int avifEncoderDestroy(IntPtr encoder);

    [LibraryImport("avif")]
    public static partial void avifRGBImageSetDefaults(in AvifRGBImage rgb, IntPtr image);

    [LibraryImport("avif")]
    public static partial AvifResult avifImageRGBToYUV(IntPtr image, in AvifRGBImage rgb);

    [LibraryImport("avif")]
    public static partial void avifImageDestroy(IntPtr image);

    [LibraryImport("avif")]
    public static partial void avifRWDataFree(ref AvifRWData data);

    [LibraryImport("avif")]
    public static partial void avifRGBImageFreePixels(ref AvifRGBImage rgb);
}