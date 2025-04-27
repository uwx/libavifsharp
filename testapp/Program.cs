using LibAvifSharp;
using LibAvifSharp.NativeTypes;
using SkiaSharp;

var bitmap = SKBitmap.Decode("/home/spacy/Pictures/image (1).jpg");

var ds = AvifEncoder.Encode(bitmap, settings =>
{
    settings.PixelFormat = AvifPixelFormat.AVIF_PIXEL_FORMAT_YUV420;
    settings.CodecChoice = AvifCodecChoice.AVIF_CODEC_CHOICE_SVT;
});

 File.WriteAllBytes("test.avif", ds.MemorySpan);

var ds2 = AvifEncoder.Encode(bitmap);
File.WriteAllBytes("test2.avif", ds2.MemorySpan);

Console.WriteLine("Done");