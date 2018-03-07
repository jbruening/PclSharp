using System;
using System.Numerics;
using System.Runtime.InteropServices;

namespace PclSharp.Struct
{
    [StructLayout(LayoutKind.Explicit, Size = 16)]
    public struct PointXYZ
    {
        [FieldOffset(0)]
        public float X;
        [FieldOffset(4)]
        public float Y;
        [FieldOffset(8)]
        public float Z;

        [FieldOffset(0)]
        public Vector3 V;

        public static implicit operator PointXYZ(Vector3 v)
            => new PointXYZ { V = v };

        public static implicit operator Vector3(PointXYZ v)
            => v.V;
    }

    [StructLayout(LayoutKind.Explicit, Size = 16)]
    public struct PointXYZRGBA
    {
        [FieldOffset(0)]
        public float X;
        [FieldOffset(4)]
        public float Y;
        [FieldOffset(8)]
        public float Z;

        [FieldOffset(0)]
        public Vector3 V;

        [FieldOffset(12)]
        public uint RGBA;
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
