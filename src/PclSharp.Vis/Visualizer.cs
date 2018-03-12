using PclSharp.Struct;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace PclSharp.Vis
{
    public static partial class Invoke
    {
        [DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
        public static extern IntPtr visualizer_ctor(string name, bool createInteractor);
        [DllImport(Native.DllName, CallingConvention = Native.CallingConvention)]
        public static extern void visualizer_delete(ref IntPtr ptr);

        [DllImport(Native.DllName, CallingConvention = Native.CallingConvention)]
        public static extern void visualizer_setBackgroundColor(IntPtr ptr, byte r, byte g, byte b);

        [DllImport(Native.DllName, CallingConvention = Native.CallingConvention)]
        public static extern void visualizer_addPointCloud_xyz(IntPtr ptr, IntPtr cloud, string name, int viewport);
        [DllImport(Native.DllName, CallingConvention = Native.CallingConvention)]
        public static extern void visualizer_addPointCloud_xyzrgba(IntPtr ptr, IntPtr cloud, string name, int viewport);

        [DllImport(Native.DllName, CallingConvention = Native.CallingConvention)]
        public static extern void visualizer_setPointCloudRenderingProperties_1x(IntPtr ptr, int property, double value, string name, int viewport);

        [DllImport(Native.DllName, CallingConvention = Native.CallingConvention)]
        public static extern void visualizer_spin(IntPtr ptr);
        [DllImport(Native.DllName, CallingConvention = Native.CallingConvention)]
        public static extern void visualizer_spinOnce(IntPtr ptr, int time, bool forceRedraw);

        [DllImport(Native.DllName, CallingConvention = Native.CallingConvention)]
        public static extern bool visualizer_contains(IntPtr ptr, string id);

        [DllImport(Native.DllName, CallingConvention = Native.CallingConvention)]
        public static extern bool visualizer_wasStopped(IntPtr ptr);
    }

    public class Visualizer : UnmanagedObject
    {
        public Visualizer(string windowName = "", bool createInteractor =true)
        {
            _ptr = Invoke.visualizer_ctor(windowName, createInteractor);
        }

        public void SetBackgroundColor(byte r, byte g, byte b)
            => Invoke.visualizer_setBackgroundColor(_ptr, r, g, b);

        public void AddPointCloud(PointCloud<PointXYZ> cloud, string name = "cloud", int viewport = 0)
            => Invoke.visualizer_addPointCloud_xyz(_ptr, cloud, name, viewport);

        public void AddPointCloud(PointCloud<PointXYZRGBA> cloud, string name = "cloud", int viewport = 0)
            => Invoke.visualizer_addPointCloud_xyzrgba(_ptr, cloud, name, viewport);

        public void SetPointCloudRenderingProperties(RenderingProperties property, double value, string name = "cloud", int viewport = 0)
            => Invoke.visualizer_setPointCloudRenderingProperties_1x(_ptr, (int)property, value, name, viewport);

        public void Spin()
            => Invoke.visualizer_spin(_ptr);

        public void SpinOnce(int time = 1, bool forceRedraw = false)
            => Invoke.visualizer_spinOnce(_ptr, time, forceRedraw);

        public bool Contains(string id)
            => Invoke.visualizer_contains(_ptr, id);

        public bool WasStopped
            => Invoke.visualizer_wasStopped(_ptr);

        protected override void DisposeObject()
        {
            Invoke.visualizer_delete(ref _ptr);
        }
    }
}
