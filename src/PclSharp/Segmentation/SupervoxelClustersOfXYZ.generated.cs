using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using PclSharp.Struct;
namespace PclSharp.Segmentation
{
	public static partial class Invoke
	{
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern IntPtr segmentation_supervoxelclusters_xyz_ctor();
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void segmentation_supervoxelclusters_xyz_delete(ref IntPtr ptr);

		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern IntPtr segmentation_supervoxelclusters_xyz_at(IntPtr ptr, uint key);

		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern int segmentation_supervoxelclusters_xyz_count(IntPtr ptr);
	}

	public class SupervoxelClustersOfXYZ : SupervoxelClusters<PointXYZ>
	{
		public override int Count => Invoke.segmentation_supervoxelclusters_xyz_count(_ptr);

		public SupervoxelClustersOfXYZ()
		{
			_ptr = Invoke.segmentation_supervoxelclusters_xyz_ctor();
		}

		public SupervoxelOfXYZ At(uint key)
			=> new SupervoxelOfXYZ(Invoke.segmentation_supervoxelclusters_xyz_at(_ptr, key));

		protected override void DisposeObject()
		{
			Invoke.segmentation_supervoxelclusters_xyz_delete(ref _ptr);
		}
	}
}
