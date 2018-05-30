using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using PclSharp.Struct;
using PclSharp.Std;
using PclSharp.SampleConsensus;
using PclSharp.Common;

namespace PclSharp.Segmentation
{
	public static partial class Invoke
	{
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern IntPtr segmentation_sacsegmentation_xyz_ctor(bool random);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void segmentation_sacsegmentation_xyz_delete(ref IntPtr ptr);

		//methods
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void segmentation_sacsegmentation_xyz_setInputCloud(IntPtr ptr, IntPtr cloud);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void segmentation_sacsegmentation_xyz_setIndices(IntPtr ptr, IntPtr indices);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void segmentation_sacsegmentation_xyz_segment(IntPtr ptr, IntPtr inliers, IntPtr coefficients);

		//properties
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void segmentation_sacsegmentation_xyz_setMethodType(IntPtr ptr, SACMethod value);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern SACMethod segmentation_sacsegmentation_xyz_getMethodType(IntPtr ptr);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void segmentation_sacsegmentation_xyz_setModelType(IntPtr ptr, SACModel value);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern SACModel segmentation_sacsegmentation_xyz_getModelType(IntPtr ptr);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void segmentation_sacsegmentation_xyz_setOptimizeCoefficients(IntPtr ptr, bool value);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern bool segmentation_sacsegmentation_xyz_getOptimizeCoefficients(IntPtr ptr);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void segmentation_sacsegmentation_xyz_setMaxIterations(IntPtr ptr, int value);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern int segmentation_sacsegmentation_xyz_getMaxIterations(IntPtr ptr);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void segmentation_sacsegmentation_xyz_setDistanceThreshold(IntPtr ptr, double value);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern double segmentation_sacsegmentation_xyz_getDistanceThreshold(IntPtr ptr);
	}

	public class SACSegmentationOfXYZ : SACSegmentation<PointXYZ>
	{
		public SACSegmentationOfXYZ(bool random = false)
		{
			_ptr = Invoke.segmentation_sacsegmentation_xyz_ctor(random);
		}

		public bool OptimizeCoefficients
		{
			get { return Invoke.segmentation_sacsegmentation_xyz_getOptimizeCoefficients(_ptr); }
            set { Invoke.segmentation_sacsegmentation_xyz_setOptimizeCoefficients(_ptr, value); }
		}

		public override SACModel ModelType
		{
			get { return Invoke.segmentation_sacsegmentation_xyz_getModelType(_ptr); }
            set { Invoke.segmentation_sacsegmentation_xyz_setModelType(_ptr, value); }
		}

		public override int MaxIterations
		{
			get { return Invoke.segmentation_sacsegmentation_xyz_getMaxIterations(_ptr); }
            set { Invoke.segmentation_sacsegmentation_xyz_setMaxIterations(_ptr, value); }
		}

		public override SACMethod MethodType
		{
			get { return Invoke.segmentation_sacsegmentation_xyz_getMethodType(_ptr); }
            set { Invoke.segmentation_sacsegmentation_xyz_setMethodType(_ptr, value); }
		}

		public override double DistanceThreshold
		{
			get { return Invoke.segmentation_sacsegmentation_xyz_getDistanceThreshold(_ptr); }
            set { Invoke.segmentation_sacsegmentation_xyz_setDistanceThreshold(_ptr, value); }
		}

		public override void SetInputCloud(PointCloud<PointXYZ> cloud)
		{
			Invoke.segmentation_sacsegmentation_xyz_setInputCloud(_ptr, cloud);
		}

		public override void SetIndices(VectorOfInt indices)
			=> Invoke.segmentation_sacsegmentation_xyz_setIndices(_ptr, indices);

		public override void Segment(PointIndices inliers, ModelCoefficients coefficients)
		{
			Invoke.segmentation_sacsegmentation_xyz_segment(_ptr, inliers, coefficients);
		}

		public override ref PointXYZ this[int idx]
		{
			get { return ref this.Index(idx); }
		}

		protected override void DisposeObject()
		{
			Invoke.segmentation_sacsegmentation_xyz_delete(ref _ptr);
		}
	}
}
