using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using PclSharp.Struct;
using PclSharp.Std;
using PclSharp.SampleConsensus;
using PclSharp.Common;
using PclSharp.Search;

namespace PclSharp.Segmentation
{
	public static partial class Invoke
	{
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern IntPtr segmentation_euclideanclusterextraction_xyz_ctor();
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void segmentation_euclideanclusterextraction_xyz_delete(ref IntPtr ptr);

		//methods
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void segmentation_euclideanclusterextraction_xyz_setInputCloud(IntPtr ptr, IntPtr cloud);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void segmentation_euclideanclusterextraction_xyz_setIndices(IntPtr ptr, IntPtr indices);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void segmentation_euclideanclusterextraction_xyz_setSearchMethod(IntPtr ptr, IntPtr search);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void segmentation_euclideanclusterextraction_xyz_extract(IntPtr ptr, IntPtr clusters);

		//properties
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void segmentation_euclideanclusterextraction_xyz_setClusterTolerance(IntPtr ptr, double value);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern double segmentation_euclideanclusterextraction_xyz_getClusterTolerance(IntPtr ptr);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void segmentation_euclideanclusterextraction_xyz_setMinClusterSize(IntPtr ptr, int value);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern int segmentation_euclideanclusterextraction_xyz_getMinClusterSize(IntPtr ptr);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void segmentation_euclideanclusterextraction_xyz_setMaxClusterSize(IntPtr ptr, int value);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern int segmentation_euclideanclusterextraction_xyz_getMaxClusterSize(IntPtr ptr);
	}

	public class EuclideanClusterExtractionOfXYZ : EuclideanClusterExtraction<PointXYZ>
	{
		public double ClusterTolerance
		{
			get { return Invoke.segmentation_euclideanclusterextraction_xyz_getClusterTolerance(_ptr); }
            set { Invoke.segmentation_euclideanclusterextraction_xyz_setClusterTolerance(_ptr, value); }
		}

		public int MinClusterSize
		{
			get { return Invoke.segmentation_euclideanclusterextraction_xyz_getMinClusterSize(_ptr); }
            set { Invoke.segmentation_euclideanclusterextraction_xyz_setMinClusterSize(_ptr, value); }
		}

		public int MaxClusterSize
		{
			get { return Invoke.segmentation_euclideanclusterextraction_xyz_getMaxClusterSize(_ptr); }
            set { Invoke.segmentation_euclideanclusterextraction_xyz_setMaxClusterSize(_ptr, value); }
		}

		public EuclideanClusterExtractionOfXYZ()
		{
			_ptr = Invoke.segmentation_euclideanclusterextraction_xyz_ctor();
		}

		public override void SetInputCloud(PointCloud<PointXYZ> cloud)
		{
			Invoke.segmentation_euclideanclusterextraction_xyz_setInputCloud(_ptr, cloud);
		}

		public override void SetIndices(VectorOfInt indices)
			=> Invoke.segmentation_euclideanclusterextraction_xyz_setIndices(_ptr, indices);

		public override void SetSearchMethod(Search<PointXYZ> search)
		{
			Invoke.segmentation_euclideanclusterextraction_xyz_setSearchMethod(_ptr, search);
		}

		public override void Extract(Vector<PointIndices> clusters)
		{
			Invoke.segmentation_euclideanclusterextraction_xyz_extract(_ptr, clusters);
		}

		public override ref PointXYZ this[int idx]
		{
			get { return ref this.Index(idx); }
		}

		protected override void DisposeObject()
		{
			Invoke.segmentation_euclideanclusterextraction_xyz_delete(ref _ptr);
		}
	}
}
