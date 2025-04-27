using System.Reflection;
using System.Runtime.InteropServices;
using SkiaSharp;

namespace LibAvifSharp;

public unsafe static partial class Encoder
{

    public static void Encode(SKBitmap bm, string outputPath, Action<EncoderSetttings>? settings = null)
    {
        var encoderSettings = new EncoderSetttings();
        if(settings != null)
        {
            settings(encoderSettings);
        }

        RegisterNativeLibraryLoader();
        var pixels = bm.GetPixels();

        var image = avifImageCreate((uint)bm.Width, (uint)bm.Height, (uint)(bm.ColorType == SKColorType.Bgra8888 ? 8 : 16), encoderSettings.PixelFormat);
    

        var rgb = new AvifRGBImage();

        avifRGBImageSetDefaults(ref rgb, image);

        rgb.Pixels = pixels;
        rgb.RowBytes = (uint)bm.RowBytes;
        rgb.Format = AvifRGBFormat.AVIF_RGB_FORMAT_BGRA;

        var result = avifImageRGBToYUV(image, ref rgb);
        if(result != AvifResult.AVIF_RESULT_OK)
        {
            throw new Exception($"Failed to convert RGB to YUV: {result}");
        }

        var encoder = avifEncoderCreate();

        encoder->Quality = encoderSettings.Quality;
        encoder->QualityAlpha = encoderSettings.QualityAlpha;
        encoder->CodecChoice = encoderSettings.CodecChoice;
        // encoder->Speed = 4;

        // Marshal.StructureToPtr(managedEncoder, encoder, false);

        AvifResult addImageResult = avifEncoderAddImage(encoder, image, 1, AvifAddImageFlag.AVIF_ADD_IMAGE_FLAG_SINGLE);

        AvifRWData output = new AvifRWData();
        avifEncoderFinish(encoder, ref output);

        var data = new Span<byte>(output.Data.ToPointer(), (int)output.Size);

        File.WriteAllBytes("out.avif", data);

        avifEncoderDestroy(encoder);
    }

    [DllImport("libavif", CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr avifImageCreate(uint width, uint height, uint depth, AvifPixelFormat yuvFormat);

    [DllImport("libavif", CallingConvention = CallingConvention.Cdecl)]
    private static extern AvifEncoder* avifEncoderCreate();

    [DllImport("libavif", CallingConvention = CallingConvention.Cdecl)]
    private static extern AvifResult avifEncoderAddImage(AvifEncoder* encoder, IntPtr image, ulong duration, AvifAddImageFlag flags);

    [DllImport("libavif", CallingConvention = CallingConvention.Cdecl)]
    private static extern  AvifResult avifEncoderFinish(AvifEncoder * encoder, ref AvifRWData output);

    [LibraryImport("libavif")]
    private static partial int avifEncoderDestroy(AvifEncoder* encoder);

    [DllImport("libavif", CallingConvention = CallingConvention.Cdecl)]
    private static extern void avifRGBImageSetDefaults([In] ref AvifRGBImage rgb, IntPtr image);

    [DllImport("libavif", CallingConvention = CallingConvention.Cdecl)]
    private static extern AvifResult avifImageRGBToYUV(IntPtr image, [In] ref AvifRGBImage rgb);


    private static void RegisterNativeLibraryLoader()
    {
        NativeLibrary.SetDllImportResolver(Assembly.GetExecutingAssembly(), DllImportResolver);
    }

    private static IntPtr DllImportResolver(string libraryName, Assembly assembly, DllImportSearchPath? searchPath)
    {
        if (libraryName == "libavif")
        {
            // On systems with AVX2 support, load a different library.
            if (System.Runtime.Intrinsics.X86.Avx2.IsSupported)
            {
                return NativeLibrary.Load("/home/spacy/src/libavif/build/libavif.so.16.2.1", assembly, searchPath);
            }
        }

        // Otherwise, fallback to default import resolver.
        return IntPtr.Zero;
    }
}