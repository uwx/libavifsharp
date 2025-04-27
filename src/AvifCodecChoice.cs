public enum AvifCodecChoice
{
    /// <summary>
    /// Use the default codec choice for the current platform.
    /// </summary>
    AVIF_CODEC_CHOICE_AUTO = 0,

    /// <summary>
    /// Use the AOM AV1 encoder and decoder.
    /// </summary>
    AVIF_CODEC_CHOICE_AOM,

    /// <summary>
    /// DAV1D decoder (decode only)
    /// </summary>
    AVIF_CODEC_CHOICE_DAV1D,   // Decode only

    /// <summary>
    /// LIBGAV1 decoder (decode only)
    /// </summary>
    AVIF_CODEC_CHOICE_LIBGAV1, // Decode only

    /// <summary>
    /// RAVI1E encoder (encode only)
    /// </summary>
    AVIF_CODEC_CHOICE_RAV1E,   // Encode only

    /// <summary>
    /// Use the SVT AV1 encoder and decoder, really fast but only YUV420 and produces slightly larger files.
    /// </summary>
    AVIF_CODEC_CHOICE_SVT,     // Encode only

    /// <summary>
    /// AV2 experimental codec choice.
    /// </summary>
    AVIF_CODEC_CHOICE_AVM      // Experimental (AV2)
}