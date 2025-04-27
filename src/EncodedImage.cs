using LibAvifSharp.NativeTypes;

public class EncodedImage : IDisposable
{
    private AvifRWData rwData;

    private bool _disposed = false;

    internal EncodedImage(AvifRWData rwData)
    {
        this.rwData = rwData;
    }

    public Span<byte> MemorySpan {
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

    // Implement IDisposable
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this); // Prevent finalizer from being called if Dispose was called
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                // Release any managed resources here (if any)
            }

            // Release unmanaged resources
            if (rwData.Data != IntPtr.Zero)
            {
                NativeInterop.avifRWDataFree(ref rwData);
            }

            _disposed = true;
        }
    }

    // Finalizer (destructor) - only called if Dispose was NOT called
    ~EncodedImage()
    {
        Dispose(false); // Call Dispose with disposing = false, as managed resources might already be garbage collected
    }
}