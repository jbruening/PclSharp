using System;
using System.Diagnostics;
using System.Numerics;
using System.Runtime.InteropServices;

namespace PclSharp.Struct
{
    [DebuggerDisplay("{V}")]
    [StructLayout(LayoutKind.Explicit, Size = 16)]
    public unsafe struct PointXYZ
    {
        [FieldOffset(0)]
        public float X;
        [FieldOffset(4)]
        public float Y;
        [FieldOffset(8)]
        public float Z;

        [FieldOffset(0)]
        public Vector3 V;
        [FieldOffset(0)]
        public fixed float data[4];

        public static implicit operator PointXYZ(Vector3 v)
            => new PointXYZ { V = v };

        public static implicit operator Vector3(PointXYZ v)
            => v.V;
    }

    [DebuggerDisplay("{V}, {RGBA.ToString(\"X8\")}")]
    [StructLayout(LayoutKind.Explicit, Size = 32)]
    public unsafe struct PointXYZRGBA
    {
        [FieldOffset(0)]
        public float X;
        [FieldOffset(4)]
        public float Y;
        [FieldOffset(8)]
        public float Z;

        [FieldOffset(0)]
        public Vector3 V;
        [FieldOffset(0)]
        public fixed float data[4];

        [FieldOffset(16)]
        public uint RGBA;
        [FieldOffset(16)]
        public fixed float data_c[4];
    }

    [DebuggerDisplay("{N}, {Curvature}")]
    [StructLayout(LayoutKind.Explicit, Size = 32)]
    public unsafe struct Normal
    {
        [FieldOffset(0)]
        public float NormalX;
        [FieldOffset(4)]
        public float NormalY;
        [FieldOffset(8)]
        public float NormalZ;
        [FieldOffset(0)]
        public fixed float data_n[4];

        [FieldOffset(0)]
        public Vector3 N;

        [FieldOffset(16)]
        public float Curvature;
        [FieldOffset(16)]
        public fixed float data_c[4];
    }

    [DebuggerDisplay("{V}, N:({NormalX}, {NormalY}, {NormalZ}, {Curvature})")]
    [StructLayout(LayoutKind.Explicit, Size = 48)]
    public unsafe struct PointNormal
    {
        [FieldOffset(0)]
        public float X;
        [FieldOffset(4)]
        public float Y;
        [FieldOffset(8)]
        public float Z;

        [FieldOffset(0)]
        public fixed float data[4];
        [FieldOffset(0)]
        public Vector3 V;
        
        [FieldOffset(16)]
        public float NormalX;
        [FieldOffset(20)]
        public float NormalY;
        [FieldOffset(24)]
        public float NormalZ;
        [FieldOffset(16)]
        public fixed float data_n[4];

        [FieldOffset(32)]
        public float Curvature;
        [FieldOffset(32)]
        public fixed float data_c[4];
    }

    [DebuggerDisplay("{V}, {Label}")]
    [StructLayout(LayoutKind.Explicit, Size = 32)]
    public unsafe struct PointXYZL
    {
        [FieldOffset(0)]
        public float X;
        [FieldOffset(4)]
        public float Y;
        [FieldOffset(8)]
        public float Z;

        [FieldOffset(0)]
        public fixed float data[4];
        [FieldOffset(0)]
        public Vector3 V;

        [FieldOffset(16)]
        public uint Label;
    }
}
