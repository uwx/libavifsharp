namespace LibAvifSharp;

public enum Result
{
    OK = 0,
    UNKNOWN_ERROR = 1,
    INVALID_FTYP = 2,
    NO_CONTENT = 3,
    NO_YUV_FORMAT_SELECTED = 4,
    REFORMAT_FAILED = 5,
    UNSUPPORTED_DEPTH = 6,
    ENCODE_COLOR_FAILED = 7,
    ENCODE_ALPHA_FAILED = 8,
    BMFF_PARSE_FAILED = 9,
    MISSING_IMAGE_ITEM = 10,
    DECODE_COLOR_FAILED = 11,
    DECODE_ALPHA_FAILED = 12,
    COLOR_ALPHA_SIZE_MISMATCH = 13,
    ISPE_SIZE_MISMATCH = 14,
    NO_CODEC_AVAILABLE = 15,
    NO_IMAGES_REMAINING = 16,
    INVALID_EXIF_PAYLOAD = 17,
    INVALID_IMAGE_GRID = 18,
    INVALID_CODEC_SPECIFIC_OPTION = 19,
    TRUNCATED_DATA = 20,
    IO_NOT_SET = 21, // the avifIO field of avifDecoder is not set
    IO_ERROR = 22,
    WAITING_ON_IO = 23, // similar to EAGAIN/EWOULDBLOCK, this means the avifIO doesn't have necessary data available yet
    INVALID_ARGUMENT = 24, // an argument passed into this function is invalid
    NOT_IMPLEMENTED = 25,  // a requested code path is not (yet) implemented
    OUT_OF_MEMORY = 26,
    CANNOT_CHANGE_SETTING = 27, // a setting that can't change is changed during encoding
    INCOMPATIBLE_IMAGE = 28,    // the image is incompatible with already encoded images
    INTERNAL_ERROR = 29,        // some invariants have not been satisfied (likely a bug in libavif)
    ENCODE_GAIN_MAP_FAILED = 30,
    DECODE_GAIN_MAP_FAILED = 31,
    INVALID_TONE_MAPPED_IMAGE = 32,
    ENCODE_SAMPLE_TRANSFORM_FAILED = 33,
    DECODE_SAMPLE_TRANSFORM_FAILED = 34,
}
