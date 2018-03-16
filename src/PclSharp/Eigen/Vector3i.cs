using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PclSharp.Eigen
{
    [DebuggerDisplay("{X}, {Y}, {Z}")]
    [StructLayout(LayoutKind.Explicit, Size = 16)]
    public unsafe struct Vector3i
    {
        [FieldOffset(0)]
        public int X;
        [FieldOffset(4)]
        public int Y;
        [FieldOffset(8)]
        public int Z;

        [FieldOffset(0)]
        public fixed int data[4];
    }
}
