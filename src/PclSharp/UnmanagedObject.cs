using System;
using System.Threading;

namespace PclSharp
{
    public abstract class UnmanagedObject : DisposableObject
    {
        protected IntPtr _ptr;
        public IntPtr Ptr => _ptr;

        public static implicit operator IntPtr(UnmanagedObject obj)
            => obj == null ? IntPtr.Zero : obj._ptr;
    }

    public abstract class DisposableObject : IDisposable
    {
        private int _disposed;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~DisposableObject()
        {
            Dispose(false);
        }

        private void Dispose(bool disposing)
        {
            if (Interlocked.Exchange(ref _disposed, 1) == 0)
            {
                if (disposing)
                    RelaseManagedResources();
                DisposeObject();
            }
        }

        protected virtual void RelaseManagedResources()
        { }

        protected abstract void DisposeObject();
    }
}
