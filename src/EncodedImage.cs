using System.Buffers;
using LibAvifSharp.NativeTypes;

public sealed class EncodedImage : MemoryManager<byte>
{
    private AvifRWData rwData;

    private bool _disposed = false;

    internal EncodedImage(AvifRWData rwData)
    {
        this.rwData = rwData;
    }

    public Span<byte> MemorySpan
    {
        get
        {
            if (_disposed)
                throw new ObjectDisposedException(nameof(EncodedImage));

            unsafe
            {
                // Create a Span<byte> over the unmanaged memory
                return new Span<byte>(rwData.Data.ToPointer(), (int)rwData.Size);
            }
        }
    }

    public override Span<byte> GetSpan()
    {
        return MemorySpan;
    }

    // Implement IDisposable
    public override unsafe MemoryHandle Pin(int elementIndex = 0)
    {
        if (_disposed)
            throw new ObjectDisposedException(nameof(EncodedImage));

        return new MemoryHandle((byte*)rwData.Data.ToPointer() + elementIndex);
    }

    public override void Unpin()
    {
    }

    protected override void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            // Release unmanaged resources
            if (rwData.Data != IntPtr.Zero)
            {
                NativeInterop.avifRWDataFree(ref rwData);
            }

            _disposed = true;
        }
    }
}