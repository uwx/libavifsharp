using System.Runtime.InteropServices;

namespace LibAvifSharp;

[StructLayout(LayoutKind.Sequential)]
internal struct AvifEncoder
{
    // Defaults to AVIF_CODEC_CHOICE_AUTO: Preference determined by order in availableCodecs table (avif.c)
    public AvifCodecChoice CodecChoice;

    // Defaults to 1. If < 2, multithreading is disabled. See also 'Understanding maxThreads' above.
    public int MaxThreads;

    // Speed range: [AVIF_SPEED_SLOWEST - AVIF_SPEED_FASTEST]. Slower should make for a better quality
    // image in fewer bytes. AVIF_SPEED_DEFAULT means "Leave the AV1 codec to its default speed settings".
    // If avifEncoder uses rav1e, the speed value is directly passed through (0-10). If libaom is used,
    // a combination of settings are tweaked to simulate this speed range.
    public int Speed;

    // For image sequences (animations), maximum interval between keyframes. Any set of |keyframeInterval|
    // consecutive frames will have at least one keyframe. When it is 0, no restriction is applied.
    public int KeyframeInterval;

    // For image sequences (animations), timescale of the media in Hz, i.e. the number of time units per second.
    public ulong Timescale;
    // For image sequences, number of times the image sequence should be repeated. This can also be set to
    // AVIF_REPETITION_COUNT_INFINITE for infinite repetitions.
    // Essentially, if repetitionCount is a non-negative integer `n`, then the image sequence should be
    // played back `n + 1` times. Defaults to AVIF_REPETITION_COUNT_INFINITE.
    public int RepetitionCount;

    // EXPERIMENTAL: A non-zero value indicates a layered (progressive) image.
    // Range: [0 - (AVIF_MAX_AV1_LAYER_COUNT-1)].
    // To encode a progressive image, set `extraLayerCount` to the number of extra images, then call
    // `avifEncoderAddImage()` or `avifEncoderAddImageGrid()` exactly `encoder->extraLayerCount+1` times.
    public uint ExtraLayerCount;

    // Encode quality for the YUV image, in [AVIF_QUALITY_WORST - AVIF_QUALITY_BEST].
    public int Quality;
    // Encode quality for the alpha layer if present, in [AVIF_QUALITY_WORST - AVIF_QUALITY_BEST].
    public int QualityAlpha;
    public int MinQuantizer;      // Deprecated, use `quality` instead.
    public int MaxQuantizer;      // Deprecated, use `quality` instead.
    public int MinQuantizerAlpha; // Deprecated, use `qualityAlpha` instead.
    public int MaxQuantizerAlpha; // Deprecated, use `qualityAlpha` instead.

    // Tiling splits the image into a grid of smaller images (tiles), allowing parallelization of
    // encoding/decoding and/or incremental decoding. Tiling also allows encoding larger images.
    // To enable tiling, set tileRowsLog2 > 0 and/or tileColsLog2 > 0, or set autoTiling to AVIF_TRUE.
    // Range: [0-6], where the value indicates a request for 2^n tiles in that dimension.
    public int TileRowsLog2;
    public int TileColsLog2;
    // If autoTiling is set to AVIF_TRUE, libavif ignores tileRowsLog2 and tileColsLog2 and
    // automatically chooses suitable tiling values.
    public AvifBool AutoTiling;

    // Up/down scaling of the image to perform before encoding.
    public AvifScalingMode ScalingMode;

    // --------------------------------------------------------------------------------------------
    // Outputs

    // Stats from the most recent write.
    public AvifIOStats IoStats;

    // Additional diagnostics (such as detailed error state).
    public AvifDiagnostics Diag;

    // --------------------------------------------------------------------------------------------
    // Internals

    //struct avifEncoderData * data;
    public IntPtr AvifEncoderData;
    //struct avifCodecSpecificOptions * csOptions;
    public IntPtr AvifCodecSpecificOptions;

    // Version 1.0.0 ends here.
    // --------------------------------------------------------------------------------------------

    // Defaults to AVIF_HEADER_DEFAULT
    AvifHeaderFormatFlags headerFormat; // Changeable encoder setting.

    // Version 1.1.0 ends here.
    // --------------------------------------------------------------------------------------------

    // Encode quality for the gain map image if present, in [AVIF_QUALITY_WORST - AVIF_QUALITY_BEST].
    public int QualityGainMap; // Changeable encoder setting.

    // Version 1.2.0 ends here. Add any new members after this line.
    // --------------------------------------------------------------------------------------------

/*
#if defined(AVIF_ENABLE_EXPERIMENTAL_SAMPLE_TRANSFORM)
    // Perform extra steps at encoding and decoding to extend AV1 features using bundled additional image items.
    avifSampleTransformRecipe sampleTransformRecipe; // Changeable encoder setting.
#endif
*/
}