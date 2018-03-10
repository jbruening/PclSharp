using PclSharp.Struct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace PclSharp.Utils
{
    public static unsafe class PointSizes
    {
        [DllImport(Native.DllName, CallingConvention = Native.CallingConvention)]
        private static extern int* GetSizes(ref int count);
        private static int[] _sizes;

        static PointSizes()
        {
            int count = 0;
            var sizes = GetSizes(ref count);
            _sizes = new int[count];
            for (var i = 0; i < count; i++)
                _sizes[i] = sizes[i];

            //fine with leaking the pointer. it's going to be small, and we're doing this once.
            AssertSize<PointXYZ>(0);
            AssertSize<PointXYZRGBA>(1);
            AssertSize<Normal>(2);
            AssertSize<PointNormal>(3);
            AssertSize<PointXYZL>(4);
        }

        static void AssertSize<PointT>(int idx)
        {
            var size = _sizes[idx];

            var msize = Marshal.SizeOf<PointT>();
            if (msize != size)
                throw new DataMisalignedException($"dll returned sizeof({typeof(PointT)}) as {size}, but managed size was {msize}");
        }

        /// <summary>
        /// do nothing, but the .cctor will throw an exception if we have bad sizes.
        /// </summary>
        public static void Init() { }
    }
}
