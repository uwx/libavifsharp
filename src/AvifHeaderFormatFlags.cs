namespace LibAvifSharp;

[Flags]
internal enum AvifHeaderFormatFlags
{
    AVIF_HEADER_DEFAULT = 0x0,
    AVIF_HEADER_MINI = 0x1,
    AVIF_HEADER_EXTENDED_PIXI = 0x2,

    AVIF_HEADER_FULL = AVIF_HEADER_DEFAULT,
}