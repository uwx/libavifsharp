using System.Reflection;
using System.Runtime.InteropServices;
using LibAvifSharp.NativeTypes;

internal static partial class NativeInterop
{
    [LibraryImport("libavif")]
    public static partial IntPtr avifImageCreate(uint width, uint height, uint depth, AvifPixelFormat yuvFormat);

    [LibraryImport("libavif")]
    public static partial IntPtr avifEncoderCreate();

    [LibraryImport("libavif")]
    public static partial AvifResult avifEncoderAddImage(IntPtr encoder, IntPtr image, ulong duration, AvifAddImageFlag flags);

    [LibraryImport("libavif")]
    public static partial  AvifResult avifEncoderFinish(IntPtr encoder, ref AvifRWData output);

    [LibraryImport("libavif")]
    public static partial int avifEncoderDestroy(IntPtr encoder);

    [LibraryImport("libavif")]
    public static partial void avifRGBImageSetDefaults(in AvifRGBImage rgb, IntPtr image);

    [LibraryImport("libavif")]
    public static partial AvifResult avifImageRGBToYUV(IntPtr image, in AvifRGBImage rgb);

    [LibraryImport("libavif")]
    public static partial void avifImageDestroy(IntPtr image);

    [LibraryImport("libavif")]
    public static partial void avifRWDataFree(ref AvifRWData data);

    [LibraryImport("libavif")]
    public static partial void avifRGBImageFreePixels(ref AvifRGBImage rgb);


    private static object _lock = new object();
    private static bool resolverSet = false;
    
    public static void EnsureNativeLibraryLoaderRegistered()
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

                var path = typeof(NativeInterop).Assembly.Location;
                if (!string.IsNullOrEmpty (path))
                {
					path = Path.GetDirectoryName (path);

                    if(!string.IsNullOrEmpty (path))
                    {
                        var libraryPath = Path.Combine(path, "runtimes", BasicRID, "native", "libavif.so.16.2.1");
                        if(File.Exists(libraryPath))
                        {
                            return NativeLibrary.Load(libraryPath, assembly, searchPath);
                        }
                    }
                }
            }
        }

        // Otherwise, fallback to default import resolver.
        return IntPtr.Zero;
    }

    private static string BasicRID => $"{OSIdentifier}-{RuntimeInformation.ProcessArchitecture.ToString().ToLowerInvariant()}";

    private static string OSIdentifier
    {
        get
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) return "win";
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux)) return "linux";
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX)) return "osx";
            return "unknown";
        }
    }
}