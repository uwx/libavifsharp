namespace LibAvifSharp;

internal enum AvifChromaUpsampling
{
    AVIF_CHROMA_UPSAMPLING_AUTOMATIC = 0,    // Chooses best trade off of speed/quality (uses BILINEAR libyuv if available,
                                             // or falls back to NEAREST libyuv if available, or falls back to BILINEAR built-in)
    AVIF_CHROMA_UPSAMPLING_FASTEST = 1,      // Chooses speed over quality (same as NEAREST)
    AVIF_CHROMA_UPSAMPLING_BEST_QUALITY = 2, // Chooses the best quality upsampling, given settings (same as BILINEAR)
    AVIF_CHROMA_UPSAMPLING_NEAREST = 3,      // Uses nearest-neighbor filter
    AVIF_CHROMA_UPSAMPLING_BILINEAR = 4      // Uses bilinear filter
}