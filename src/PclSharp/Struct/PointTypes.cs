using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace PclSharp.Struct
{
    [StructLayout(LayoutKind.Sequential, Size =16)]
    public struct PointXYZRGBA
    {
        public float X, Y, Z;
        public uint RGBA;
    }

    [StructLayout(LayoutKind.Sequential, Size = 16)]
    public struct PointNormal
    {
        public float X, Y, Z, W;
    }

    [StructLayout(LayoutKind.Explicit, Size =16)]
    public struct Normal
    {
        [FieldOffset(0)]
        public float Curvature;
        [FieldOffset(0)]
        public float X;
        [FieldOffset(4)]
        public float Y;
        [FieldOffset(8)]
        public float Z;
    }
}
