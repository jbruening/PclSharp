using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using PclSharp.Struct;
using PclSharp.Std;

namespace PclSharp.Segmentation
{
	public static partial class Invoke
	{
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern IntPtr segmentation_supervoxelclustering_xyzrgba_ctor(float voxelResolution, float seedResolution);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void segmentation_supervoxelclustering_xyzrgba_delete(ref IntPtr ptr);

		//methods
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void segmentation_supervoxelclustering_xyzrgba_setInputCloud(IntPtr ptr, IntPtr cloud);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void segmentation_supervoxelclustering_xyzrgba_setIndices(IntPtr ptr, IntPtr indices);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void segmentation_supervoxelclustering_xyzrgba_setNormalCloud(IntPtr ptr, IntPtr cloud);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void segmentation_supervoxelclustering_xyzrgba_extract(IntPtr ptr, IntPtr clusters);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void segmentation_supervoxelclustering_xyzrgba_setColorImportance(IntPtr ptr, float value);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void segmentation_supervoxelclustering_xyzrgba_setNormalImportance(IntPtr ptr, float value);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void segmentation_supervoxelclustering_xyzrgba_setSpatialImportance(IntPtr ptr, float value);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void segmentation_supervoxelclustering_xyzrgba_setUseSingleCameraTransform(IntPtr ptr, bool value);

		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void segmentation_supervoxelclustering_xyzrgba_refineSupervoxels(IntPtr ptr, int iterations, IntPtr supervoxels);

		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern IntPtr segmentation_supervoxelclustering_xyzrgba_getLabeledCloud(IntPtr ptr);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void segmentation_supervoxelclustering_xyzrgba_getSupervoxelAdjacency(IntPtr ptr, IntPtr adjacency);

		//properties
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void segmentation_supervoxelclustering_xyzrgba_setVoxelResolution(IntPtr ptr, float value);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern float segmentation_supervoxelclustering_xyzrgba_getVoxelResolution(IntPtr ptr);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void segmentation_supervoxelclustering_xyzrgba_setSeedResolution(IntPtr ptr, float value);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern float segmentation_supervoxelclustering_xyzrgba_getSeedResolution(IntPtr ptr);
	}

	public class SupervoxelClusteringOfXYZRGBA : SupervoxelClustering<PointXYZRGBA>
	{
		public override float VoxelResolution
		{
			get { return Invoke.segmentation_supervoxelclustering_xyzrgba_getVoxelResolution(_ptr); }
            set { Invoke.segmentation_supervoxelclustering_xyzrgba_setVoxelResolution(_ptr, value); }
		}

		public override float SeedResolution
		{
			get { return Invoke.segmentation_supervoxelclustering_xyzrgba_getSeedResolution(_ptr); }
            set { Invoke.segmentation_supervoxelclustering_xyzrgba_setSeedResolution(_ptr, value); }
		}

		public override bool UseSingleCameraTransform
		{ set { Invoke.segmentation_supervoxelclustering_xyzrgba_setUseSingleCameraTransform(_ptr, value); } }

		public override float ColorImportance
		{ set { Invoke.segmentation_supervoxelclustering_xyzrgba_setColorImportance(_ptr, value); } }

		public override float NormalImportance
		{ set { Invoke.segmentation_supervoxelclustering_xyzrgba_setNormalImportance(_ptr, value); } }

		public override float SpatialImportance
		{ set { Invoke.segmentation_supervoxelclustering_xyzrgba_setSpatialImportance(_ptr, value); } }

		public SupervoxelClusteringOfXYZRGBA(float voxelResolution, float seedResolution)
		{
			_ptr = Invoke.segmentation_supervoxelclustering_xyzrgba_ctor(voxelResolution, seedResolution);
		}

		public override void SetInputCloud(PointCloud<PointXYZRGBA> cloud)
		{
			Invoke.segmentation_supervoxelclustering_xyzrgba_setInputCloud(_ptr, cloud);
		}

		public override void SetIndices(VectorOfInt indices)
			=> Invoke.segmentation_supervoxelclustering_xyzrgba_setIndices(_ptr, indices);

		public override void SetNormalCloud(PointCloud<Normal> cloud)
			=> Invoke.segmentation_supervoxelclustering_xyzrgba_setNormalCloud(_ptr, cloud);

		public override void Extract(SupervoxelClusters<PointXYZRGBA> clusters)
		{
			Invoke.segmentation_supervoxelclustering_xyzrgba_extract(_ptr, clusters);
		}

		public override void RefineSupervoxels(int iterations, SupervoxelClusters<PointXYZRGBA> clusters)
			=> Invoke.segmentation_supervoxelclustering_xyzrgba_refineSupervoxels(_ptr, iterations, clusters);

		public override PointCloud<PointXYZL> GetLabeledCloud()
			=> new PointCloudOfXYZL(Invoke.segmentation_supervoxelclustering_xyzrgba_getLabeledCloud(_ptr), true);

		public override void GetSupervoxelAdjacency(MultiMap<uint, uint> adjacency)
			=> Invoke.segmentation_supervoxelclustering_xyzrgba_getSupervoxelAdjacency(_ptr, adjacency);

		public override ref PointXYZRGBA this[int idx]
		{
			get { return ref this.Index(idx); }
		}

		protected override void DisposeObject()
		{
			Invoke.segmentation_supervoxelclustering_xyzrgba_delete(ref _ptr);
		}
	}
}
