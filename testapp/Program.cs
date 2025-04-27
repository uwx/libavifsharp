using LibAvifSharp;
using LibAvifSharp.NativeTypes;
using SkiaSharp;

using var bitmap = SKBitmap.Decode("/home/spacy/Pictures/image (1).jpg");
AvifEncoder.Encode(bitmap, "out_sv1.avif", settings =>
{
    settings.PixelFormat = AvifPixelFormat.AVIF_PIXEL_FORMAT_YUV420;
    settings.CodecChoice = AvifCodecChoice.AVIF_CODEC_CHOICE_SVT;
});

AvifEncoder.Encode(bitmap, "out_aom.avif");