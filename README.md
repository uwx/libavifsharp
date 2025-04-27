This wraps libavif in order to encode .avif image from SkiaSharp SKImage and SKBitmap objects.
Currently only linux-x64 is included as a native component. All other platforms are unsupported as of now.

Usage

```csharp
var bitmap = SKBitmap.Decode("/home/spacy/Pictures/image (1).jpg");
var ds = AvifEncoder.Encode(bitmap, settings =>
{
    settings.PixelFormat = AvifPixelFormat.AVIF_PIXEL_FORMAT_YUV420;
    settings.CodecChoice = AvifCodecChoice.AVIF_CODEC_CHOICE_SVT;
});

File.WriteAllBytes("test.avif", ds.MemorySpan);
```

The included libavif .so object is build with, so the AOM and SVT-AV1 encoders are included!
```bash
cmake -DAVIF_CODEC_SVT=LOCAL -DAVIF_CODEC_AOM=LOCAL -DAVIF_LIBYUV=LOCAL -DTD_ENABLE_LTO=ON -DCMAKE_CXX_FLAGS="-fuse-ld=lld" ..
```
