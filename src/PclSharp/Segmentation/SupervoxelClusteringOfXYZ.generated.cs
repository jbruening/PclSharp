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
		public static extern IntPtr segmentation_supervoxelclustering_xyz_ctor(float voxelResolution, float seedResolution);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void segmentation_supervoxelclustering_xyz_delete(ref IntPtr ptr);

		//methods
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void segmentation_supervoxelclustering_xyz_setInputCloud(IntPtr ptr, IntPtr cloud);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void segmentation_supervoxelclustering_xyz_setIndices(IntPtr ptr, IntPtr indices);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void segmentation_supervoxelclustering_xyz_setNormalCloud(IntPtr ptr, IntPtr cloud);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void segmentation_supervoxelclustering_xyz_extract(IntPtr ptr, IntPtr clusters);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void segmentation_supervoxelclustering_xyz_setColorImportance(IntPtr ptr, float value);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void segmentation_supervoxelclustering_xyz_setNormalImportance(IntPtr ptr, float value);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void segmentation_supervoxelclustering_xyz_setSpatialImportance(IntPtr ptr, float value);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void segmentation_supervoxelclustering_xyz_setUseSingleCameraTransform(IntPtr ptr, bool value);

		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void segmentation_supervoxelclustering_xyz_refineSupervoxels(IntPtr ptr, int iterations, IntPtr supervoxels);

		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern IntPtr segmentation_supervoxelclustering_xyz_getLabeledCloud(IntPtr ptr);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void segmentation_supervoxelclustering_xyz_getSupervoxelAdjacency(IntPtr ptr, IntPtr adjacency);

		//properties
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void segmentation_supervoxelclustering_xyz_setVoxelResolution(IntPtr ptr, float value);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern float segmentation_supervoxelclustering_xyz_getVoxelResolution(IntPtr ptr);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void segmentation_supervoxelclustering_xyz_setSeedResolution(IntPtr ptr, float value);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern float segmentation_supervoxelclustering_xyz_getSeedResolution(IntPtr ptr);
	}

	public class SupervoxelClusteringOfXYZ : SupervoxelClustering<PointXYZ>
	{
		public override float VoxelResolution
		{
			get { return Invoke.segmentation_supervoxelclustering_xyz_getVoxelResolution(_ptr); }
            set { Invoke.segmentation_supervoxelclustering_xyz_setVoxelResolution(_ptr, value); }
		}

		public override float SeedResolution
		{
			get { return Invoke.segmentation_supervoxelclustering_xyz_getSeedResolution(_ptr); }
            set { Invoke.segmentation_supervoxelclustering_xyz_setSeedResolution(_ptr, value); }
		}

		public override bool UseSingleCameraTransform
		{ set { Invoke.segmentation_supervoxelclustering_xyz_setUseSingleCameraTransform(_ptr, value); } }

		public override float ColorImportance
		{ set { Invoke.segmentation_supervoxelclustering_xyz_setColorImportance(_ptr, value); } }

		public override float NormalImportance
		{ set { Invoke.segmentation_supervoxelclustering_xyz_setNormalImportance(_ptr, value); } }

		public override float SpatialImportance
		{ set { Invoke.segmentation_supervoxelclustering_xyz_setSpatialImportance(_ptr, value); } }

		public SupervoxelClusteringOfXYZ(float voxelResolution, float seedResolution)
		{
			_ptr = Invoke.segmentation_supervoxelclustering_xyz_ctor(voxelResolution, seedResolution);
		}

		public override void SetInputCloud(PointCloud<PointXYZ> cloud)
		{
			Invoke.segmentation_supervoxelclustering_xyz_setInputCloud(_ptr, cloud);
		}

		public override void SetIndices(VectorOfInt indices)
			=> Invoke.segmentation_supervoxelclustering_xyz_setIndices(_ptr, indices);

		public override void SetNormalCloud(PointCloud<Normal> cloud)
			=> Invoke.segmentation_supervoxelclustering_xyz_setNormalCloud(_ptr, cloud);

		public override void Extract(SupervoxelClusters<PointXYZ> clusters)
		{
			Invoke.segmentation_supervoxelclustering_xyz_extract(_ptr, clusters);
		}

		public override void RefineSupervoxels(int iterations, SupervoxelClusters<PointXYZ> clusters)
			=> Invoke.segmentation_supervoxelclustering_xyz_refineSupervoxels(_ptr, iterations, clusters);

		public override PointCloud<PointXYZL> GetLabeledCloud()
			=> new PointCloudOfXYZL(Invoke.segmentation_supervoxelclustering_xyz_getLabeledCloud(_ptr), true);

		public override void GetSupervoxelAdjacency(MultiMap<uint, uint> adjacency)
			=> Invoke.segmentation_supervoxelclustering_xyz_getSupervoxelAdjacency(_ptr, adjacency);

		public override ref PointXYZ this[int idx]
		{
			get { return ref this.Index(idx); }
		}

		protected override void DisposeObject()
		{
			Invoke.segmentation_supervoxelclustering_xyz_delete(ref _ptr);
		}
	}
}
