using System;
using System.Runtime.InteropServices;
using PclSharp.Struct;
using PclSharp.Eigen;
using PclSharp.Std;

namespace PclSharp.Registration
{
	public static partial class Invoke
	{
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern IntPtr registration_icp_pointxyz_pointxyz_ctor();
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void registration_icp_pointxyz_pointxyz_delete(ref IntPtr ptr);

		//methods
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void registration_icp_pointxyz_pointxyz_align(IntPtr ptr, IntPtr output);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void registration_icp_pointxyz_pointxyz_alignGuess(IntPtr ptr, IntPtr output, IntPtr guess);

		//properties
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void registration_icp_pointxyz_pointxyz_setMaximumIterations(IntPtr ptr, int value);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern int registration_icp_pointxyz_pointxyz_getMaximumIterations(IntPtr ptr);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void registration_icp_pointxyz_pointxyz_setUseReciprocalCorrespondences(IntPtr ptr, bool value);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern bool registration_icp_pointxyz_pointxyz_getUseReciprocalCorrespondences(IntPtr ptr);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void registration_icp_pointxyz_pointxyz_setMaxCorrespondenceDistance(IntPtr ptr, double value);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern double registration_icp_pointxyz_pointxyz_getMaxCorrespondenceDistance(IntPtr ptr);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void registration_icp_pointxyz_pointxyz_setRANSACOutlierRejectionThreshold(IntPtr ptr, double value);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern double registration_icp_pointxyz_pointxyz_getRANSACOutlierRejectionThreshold(IntPtr ptr);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void registration_icp_pointxyz_pointxyz_setTransformationEpsilon(IntPtr ptr, double value);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern double registration_icp_pointxyz_pointxyz_getTransformationEpsilon(IntPtr ptr);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void registration_icp_pointxyz_pointxyz_setEuclideanFitnessEpsilon(IntPtr ptr, double value);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern double registration_icp_pointxyz_pointxyz_getEuclideanFitnessEpsilon(IntPtr ptr);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void registration_icp_pointxyz_pointxyz_setInputSource(IntPtr ptr, IntPtr value);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern IntPtr registration_icp_pointxyz_pointxyz_getInputSource(IntPtr ptr);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void registration_icp_pointxyz_pointxyz_setInputTarget(IntPtr ptr, IntPtr value);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern IntPtr registration_icp_pointxyz_pointxyz_getInputTarget(IntPtr ptr);
	}

	public class IterativeClosestPointOfPointXYZ_PointXYZ : IterativeClosestPoint<PointXYZ, PointXYZ>
	{
		public override int MaximumIterations
		{ 
			get { return Invoke.registration_icp_pointxyz_pointxyz_getMaximumIterations(_ptr); }
            set { Invoke.registration_icp_pointxyz_pointxyz_setMaximumIterations(_ptr, value); } 
		}
		public override bool UseReciprocalCorrespondences
		{ 
			get { return Invoke.registration_icp_pointxyz_pointxyz_getUseReciprocalCorrespondences(_ptr); }
            set { Invoke.registration_icp_pointxyz_pointxyz_setUseReciprocalCorrespondences(_ptr, value); } 
		}
        public override double MaxCorrespondenceDistance
		{
			get { return Invoke.registration_icp_pointxyz_pointxyz_getMaxCorrespondenceDistance(_ptr); }
            set { Invoke.registration_icp_pointxyz_pointxyz_setMaxCorrespondenceDistance(_ptr, value); } 
		}
        public override double RANSACOutlierRejectionThreshold
		{
			get { return Invoke.registration_icp_pointxyz_pointxyz_getRANSACOutlierRejectionThreshold(_ptr); }
            set { Invoke.registration_icp_pointxyz_pointxyz_setRANSACOutlierRejectionThreshold(_ptr, value); } 
		}
        public override double TransformationEpsilon
		{
			get { return Invoke.registration_icp_pointxyz_pointxyz_getTransformationEpsilon(_ptr); }
            set { Invoke.registration_icp_pointxyz_pointxyz_setTransformationEpsilon(_ptr, value); } 
		}
        public override double EuclideanFitnessEpsilon
		{
			get { return Invoke.registration_icp_pointxyz_pointxyz_getEuclideanFitnessEpsilon(_ptr); }
            set { Invoke.registration_icp_pointxyz_pointxyz_setEuclideanFitnessEpsilon(_ptr, value); } 
		}
        public override PointCloud<PointXYZ> InputSource
		{
			get { return new PointCloudOfXYZ(Invoke.registration_icp_pointxyz_pointxyz_getInputSource(_ptr), true); }
			set { Invoke.registration_icp_pointxyz_pointxyz_setInputSource(_ptr, value); }
		}
        public override PointCloud<PointXYZ> InputTarget
		{
			get { return new PointCloudOfXYZ(Invoke.registration_icp_pointxyz_pointxyz_getInputTarget(_ptr), true); }
			set { Invoke.registration_icp_pointxyz_pointxyz_setInputTarget(_ptr, value); }
		}

		public override double TransformationRotationEpsilon
		{
			get => throw new NotImplementedException();
			set => throw new NotImplementedException();
		}

        public override void Align(PointCloud<PointXYZ> output)
			=> Invoke.registration_icp_pointxyz_pointxyz_align(_ptr, output);

        public override void Align(PointCloud<PointXYZ> output, Matrix4f guess)
			=> Invoke.registration_icp_pointxyz_pointxyz_alignGuess(_ptr, output, guess);

        public override void SetIndices(VectorOfInt indices)
        {
            throw new NotImplementedException();
        }

        public override void SetInputCloud(PointCloud<PointXYZ> cloud)
        {
            this.InputSource = cloud;
        }

		public override ref PointXYZ this[int idx]
		{
			get { return ref this.Index(idx); }
		}

        protected override void DisposeObject()
		{
			Invoke.registration_icp_pointxyz_pointxyz_delete(ref _ptr);
		}
	}
}
