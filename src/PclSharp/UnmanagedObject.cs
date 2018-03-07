using System;

namespace PclSharp
{
    public abstract class UnmanagedObject : IDisposable
    {
        protected IntPtr _ptr;
        public IntPtr Ptr => _ptr;

        public abstract void Dispose();
    }
}
