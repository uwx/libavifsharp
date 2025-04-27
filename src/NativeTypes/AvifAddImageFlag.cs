namespace LibAvifSharp.NativeTypes;

[Flags]
internal enum AvifAddImageFlag  {
    AVIF_ADD_IMAGE_FLAG_NONE = 0,

    // Force this frame to be a keyframe (sync frame).
    AVIF_ADD_IMAGE_FLAG_FORCE_KEYFRAME = (1 << 0),

    // Use this flag when encoding a single frame, single layer image.
    // Signals "still_picture" to AV1 encoders, which tweaks various compression rules.
    // This is enabled automatically when using the avifEncoderWrite() single-image encode path.
    AVIF_ADD_IMAGE_FLAG_SINGLE = (1 << 1)
}