namespace LibAvifSharp;

internal enum AvifChromaDownsampling
{
    AVIF_CHROMA_DOWNSAMPLING_AUTOMATIC = 0,    // Chooses best trade off of speed/quality (same as AVERAGE)
    AVIF_CHROMA_DOWNSAMPLING_FASTEST = 1,      // Chooses speed over quality (same as AVERAGE)
    AVIF_CHROMA_DOWNSAMPLING_BEST_QUALITY = 2, // Chooses the best quality upsampling (same as AVERAGE)
    AVIF_CHROMA_DOWNSAMPLING_AVERAGE = 3,      // Uses averaging filter
    AVIF_CHROMA_DOWNSAMPLING_SHARP_YUV = 4     // Uses sharp yuv filter (libsharpyuv), available for 4:2:0 only, ignored for 4:2:2
}