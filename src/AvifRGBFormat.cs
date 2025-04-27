
namespace LibAvifSharp;

internal enum AvifRGBFormat
{
    AVIF_RGB_FORMAT_RGB = 0,
    AVIF_RGB_FORMAT_RGBA, // This is the default format set in avifRGBImageSetDefaults().
    AVIF_RGB_FORMAT_ARGB,
    AVIF_RGB_FORMAT_BGR,
    AVIF_RGB_FORMAT_BGRA,
    AVIF_RGB_FORMAT_ABGR,
    // RGB_565 format uses five bits for the red and blue components and six
    // bits for the green component. Each RGB pixel is 16 bits (2 bytes), which
    // is packed as follows:
    //   uint16_t: [r4 r3 r2 r1 r0 g5 g4 g3 g2 g1 g0 b4 b3 b2 b1 b0]
    //   r4 and r0 are the MSB and LSB of the red component respectively.
    //   g5 and g0 are the MSB and LSB of the green component respectively.
    //   b4 and b0 are the MSB and LSB of the blue component respectively.
    // This format is only supported for YUV -> RGB conversion and when
    // avifRGBImage.depth is set to 8.
    AVIF_RGB_FORMAT_RGB_565,
    AVIF_RGB_FORMAT_GRAY,
    AVIF_RGB_FORMAT_GRAYA,
    AVIF_RGB_FORMAT_AGRAY,
    AVIF_RGB_FORMAT_COUNT
}