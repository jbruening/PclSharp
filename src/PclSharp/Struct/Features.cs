using System;

namespace PclSharp.Struct
{
    public unsafe struct PFHSignature125
    {
        public fixed float Histogram[125];

        public static readonly int DescriptorSize = 125;
    }

    public unsafe struct PFHRGBSignature250
    {
        public fixed float Histogram[250];

        public static readonly int DescriptorSize = 250;
    }

    public unsafe struct FPFHSignature33
    {
        public fixed float Histogram[33];

        public static readonly int DescriptorSize = 33;
    }

    public unsafe struct VFHSignature308
    {
        public fixed float Histogram[308];

        public static readonly int DescriptorSize = 308;
    }

    public unsafe struct GRSDSignature21
    {
        public fixed float Histogram[21];

        public static readonly int DescriptorSize = 21;
    }
}
