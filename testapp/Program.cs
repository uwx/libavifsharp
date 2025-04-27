using LibAvifSharp;
using SkiaSharp;

using var bitmap = SKBitmap.Decode("/home/spacy/Pictures/image (1).jpg");
Encoder.Encode(bitmap, "/home/spacy/Pictures/image.avif", settings =>
{
    settings.PixelFormat = AvifPixelFormat.AVIF_PIXEL_FORMAT_YUV420;
    settings.CodecChoice = AvifCodecChoice.AVIF_CODEC_CHOICE_SVT;
});