namespace LibAvifSharp;

internal enum AvifRange
{
    // avifRange is only applicable to YUV planes. RGB and alpha planes are always full range.
    AVIF_RANGE_LIMITED = 0, /**<- Y  [16..235],  UV  [16..240]  (bit depth 8) */
                            /**<- Y  [64..940],  UV  [64..960]  (bit depth 10) */
                            /**<- Y [256..3760], UV [256..3840] (bit depth 12) */
    AVIF_RANGE_FULL = 1     /**<- [0..255]  (bit depth 8) */
                            /**<- [0..1023] (bit depth 10) */
                            /**<- [0..4095] (bit depth 12) */
}