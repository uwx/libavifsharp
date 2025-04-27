using LibAvifSharp;
using SkiaSharp;

using var bitmap = SKBitmap.Decode("/home/spacy/Pictures/image (1).jpg");
Encoder.Encode(bitmap, "/home/spacy/Pictures/image.avif", 60);