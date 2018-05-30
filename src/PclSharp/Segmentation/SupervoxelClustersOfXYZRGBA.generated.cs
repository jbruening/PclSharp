using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using PclSharp.Struct;
namespace PclSharp.Segmentation
{
	public static partial class Invoke
	{
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern IntPtr segmentation_supervoxelclusters_xyzrgba_ctor();
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void segmentation_supervoxelclusters_xyzrgba_delete(ref IntPtr ptr);

		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern IntPtr segmentation_supervoxelclusters_xyzrgba_at(IntPtr ptr, uint key);

		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern int segmentation_supervoxelclusters_xyzrgba_count(IntPtr ptr);
	}

	public class SupervoxelClustersOfXYZRGBA : SupervoxelClusters<PointXYZRGBA>
	{
		public override int Count => Invoke.segmentation_supervoxelclusters_xyzrgba_count(_ptr);

		public SupervoxelClustersOfXYZRGBA()
		{
			_ptr = Invoke.segmentation_supervoxelclusters_xyzrgba_ctor();
		}

		public SupervoxelOfXYZRGBA At(uint key)
			=> new SupervoxelOfXYZRGBA(Invoke.segmentation_supervoxelclusters_xyzrgba_at(_ptr, key));

		protected override void DisposeObject()
		{
			Invoke.segmentation_supervoxelclusters_xyzrgba_delete(ref _ptr);
		}
	}
}
