using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using PclSharp.Struct;

namespace PclSharp.Segmentation
{
	public static unsafe partial class Invoke
	{
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern IntPtr segmentation_supervoxel_xyzrgba_ctor();
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void segmentation_supervoxel_xyzrgba_delete(ref IntPtr ptr);

		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern IntPtr segmentation_supervoxel_xyzrgba_getVoxels(IntPtr ptr);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern IntPtr segmentation_supervoxel_xyzrgba_getNormals(IntPtr ptr);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void segmentation_supervoxel_xyzrgba_setNormal(IntPtr ptr, ref Normal value);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern Normal* segmentation_supervoxel_xyzrgba_getNormal(IntPtr ptr);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void segmentation_supervoxel_xyzrgba_setCentroid(IntPtr ptr, ref PointXYZRGBA value);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern PointXYZRGBA* segmentation_supervoxel_xyzrgba_getCentroid(IntPtr ptr);
	}

	public class SupervoxelOfXYZRGBA : Supervoxel<PointXYZRGBA>
	{
		private bool _suppressDispose;

		public unsafe override Normal Normal
		{
			get { return *Invoke.segmentation_supervoxel_xyzrgba_getNormal(_ptr); }
            set { Invoke.segmentation_supervoxel_xyzrgba_setNormal(_ptr, ref value); }
		}

		public unsafe override PointXYZRGBA Centroid
		{
			get { return *Invoke.segmentation_supervoxel_xyzrgba_getCentroid(_ptr); }
            set { Invoke.segmentation_supervoxel_xyzrgba_setCentroid(_ptr, ref value); }
		}

		public override IntPtr Voxels
			=> Invoke.segmentation_supervoxel_xyzrgba_getVoxels(_ptr);

		public override IntPtr Normals
			=> Invoke.segmentation_supervoxel_xyzrgba_getNormals(_ptr);

		public SupervoxelOfXYZRGBA()
		{
			_ptr = Invoke.segmentation_supervoxel_xyzrgba_ctor();
		}

		internal SupervoxelOfXYZRGBA(IntPtr ptr)
		{
			_suppressDispose = true;
			_ptr = ptr;
		}

		protected override void DisposeObject()
		{
			if (_suppressDispose) return;
			Invoke.segmentation_supervoxel_xyzrgba_delete(ref _ptr);
		}
	}
}
