namespace LibAvifSharp;

public enum AvifHeaderFormat
{
    AVIF_HEADER_DEFAULT = 0x0,

    // AVIF file with a "mif3" brand and a MinimizedImageBox to reduce the encoded file size.
    // This is based on the w24144 "Low-overhead image file format" MPEG proposal for HEIF.
    // WARNING: Experimental feature. Produces files that are incompatible with older decoders.
    // If this flag is omitted or if MinimizedImageBox cannot be used at encoding, falls back to an
    // AVIF file with an "avif" brand, a MetaBox and all its required boxes for maximum compatibility.
    AVIF_HEADER_MINI = 0x1,

    // Use the full syntax of the PixelInformationProperty from HEIF 3rd edition Amendment 2.
    // WARNING: Experimental feature. Produces files that may be incompatible with older decoders.
    // Only relevant if a MetaBox is used. No effect if a MinimizedImageBox is used.
    AVIF_HEADER_EXTENDED_PIXI = 0x2,

    // Deprecated.
    AVIF_HEADER_FULL = AVIF_HEADER_DEFAULT,
}