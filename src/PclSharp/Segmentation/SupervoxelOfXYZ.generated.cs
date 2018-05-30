using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using PclSharp.Struct;

namespace PclSharp.Segmentation
{
	public static unsafe partial class Invoke
	{
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern IntPtr segmentation_supervoxel_xyz_ctor();
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void segmentation_supervoxel_xyz_delete(ref IntPtr ptr);

		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern IntPtr segmentation_supervoxel_xyz_getVoxels(IntPtr ptr);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern IntPtr segmentation_supervoxel_xyz_getNormals(IntPtr ptr);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void segmentation_supervoxel_xyz_setNormal(IntPtr ptr, ref Normal value);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern Normal* segmentation_supervoxel_xyz_getNormal(IntPtr ptr);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void segmentation_supervoxel_xyz_setCentroid(IntPtr ptr, ref PointXYZRGBA value);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern PointXYZRGBA* segmentation_supervoxel_xyz_getCentroid(IntPtr ptr);
	}

	public class SupervoxelOfXYZ : Supervoxel<PointXYZ>
	{
		private bool _suppressDispose;

		public unsafe override Normal Normal
		{
			get { return *Invoke.segmentation_supervoxel_xyz_getNormal(_ptr); }
            set { Invoke.segmentation_supervoxel_xyz_setNormal(_ptr, ref value); }
		}

		public unsafe override PointXYZRGBA Centroid
		{
			get { return *Invoke.segmentation_supervoxel_xyz_getCentroid(_ptr); }
            set { Invoke.segmentation_supervoxel_xyz_setCentroid(_ptr, ref value); }
		}

		public override IntPtr Voxels
			=> Invoke.segmentation_supervoxel_xyz_getVoxels(_ptr);

		public override IntPtr Normals
			=> Invoke.segmentation_supervoxel_xyz_getNormals(_ptr);

		public SupervoxelOfXYZ()
		{
			_ptr = Invoke.segmentation_supervoxel_xyz_ctor();
		}

		internal SupervoxelOfXYZ(IntPtr ptr)
		{
			_suppressDispose = true;
			_ptr = ptr;
		}

		protected override void DisposeObject()
		{
			if (_suppressDispose) return;
			Invoke.segmentation_supervoxel_xyz_delete(ref _ptr);
		}
	}
}
