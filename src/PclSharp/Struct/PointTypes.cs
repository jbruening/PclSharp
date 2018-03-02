using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PclSharp.Struct
{
    [StructLayout(LayoutKind.Sequential, Size =16)]
    public struct PointXYZRGBA
    {
        public float X, Y, Z;
        public uint RGBA;
    }
}
