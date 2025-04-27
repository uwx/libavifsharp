using System.Reflection;
using System.Runtime.InteropServices;
using LibAvifSharp.NativeTypes;
using SkiaSharp;

namespace LibAvifSharp;

public unsafe static partial class AvifEncoder
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

        var encoderPtr = avifEncoderCreate();

        var encoder = Marshal.PtrToStructure<NativeTypes.AvifEncoder>(encoderPtr);

        encoder.Quality = encoderSettings.Quality;
        encoder.QualityAlpha = encoderSettings.QualityAlpha;
        encoder.CodecChoice = encoderSettings.CodecChoice;
        encoder.Speed = encoderSettings.Speed;

        Marshal.StructureToPtr(encoder, encoderPtr, false);

        AvifResult addImageResult = avifEncoderAddImage(encoderPtr, image, 1, AvifAddImageFlag.AVIF_ADD_IMAGE_FLAG_SINGLE);
        if (addImageResult != AvifResult.AVIF_RESULT_OK)
        {
            throw new Exception($"Failed to add image: {addImageResult}");
        }

        AvifRWData output = new AvifRWData();
        avifEncoderFinish(encoderPtr, ref output);

        var data = new Span<byte>(output.Data.ToPointer(), (int)output.Size);

        File.WriteAllBytes(outputPath, data);

        avifEncoderDestroy(encoderPtr);
    }

    [LibraryImport("libavif")]
    private static partial IntPtr avifImageCreate(uint width, uint height, uint depth, AvifPixelFormat yuvFormat);

    [LibraryImport("libavif")]
    private static partial IntPtr avifEncoderCreate();

    [LibraryImport("libavif")]
    private static partial AvifResult avifEncoderAddImage(IntPtr encoder, IntPtr image, ulong duration, AvifAddImageFlag flags);

    [LibraryImport("libavif")]
    private static partial  AvifResult avifEncoderFinish(IntPtr encoder, ref AvifRWData output);

    [LibraryImport("libavif")]
    private static partial int avifEncoderDestroy(IntPtr encoder);

    [LibraryImport("libavif")]
    private static partial void avifRGBImageSetDefaults(in AvifRGBImage rgb, IntPtr image);

    [LibraryImport("libavif")]
    private static partial AvifResult avifImageRGBToYUV(IntPtr image, in AvifRGBImage rgb);


    private static object _lock = new object();
    private static bool resolverSet = false;
    private static void RegisterNativeLibraryLoader()
    {
        lock(_lock)
        {
            if(resolverSet)
                return;

            resolverSet = true;
            NativeLibrary.SetDllImportResolver(Assembly.GetExecutingAssembly(), DllImportResolver);
        }
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