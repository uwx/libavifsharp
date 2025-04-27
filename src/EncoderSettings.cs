namespace LibAvifSharp;

public class EncoderSetttings
{
    public int Quality { get; set; } = 60;
    public int QualityAlpha { get; set; } = Constants.AVIF_QUALITY_LOSSLESS;
    public int Speed { get; set; } = 4;
    public AvifPixelFormat PixelFormat { get; set; } = AvifPixelFormat.AVIF_PIXEL_FORMAT_YUV444;

    public AvifCodecChoice CodecChoice { get; set; } = AvifCodecChoice.AVIF_CODEC_CHOICE_AOM;
}