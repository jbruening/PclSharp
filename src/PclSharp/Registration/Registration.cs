using System;

namespace PclSharp.Registration
{
    public abstract class Registration<PointSource, PointTarget> : PclBase<PointSource>
    {
        public abstract int MaximumIterations { get; set; }
        public abstract double MaxCorrespondenceDistance { get; set; }
        public abstract double RANSACOutlierRejectionThreshold { get; set; }
        public abstract double TransformationEpsilon { get; set; }
        public abstract double TransformationRotationEpsilon { get; set; }
        public abstract double EuclideanFitnessEpsilon { get; set; }

        public abstract PointCloud<PointSource> InputSource { get; set; }
        public abstract PointCloud<PointTarget> InputTarget { get; set; }

        public abstract void Align(PointCloud<PointSource> output);
        public abstract void Align(PointCloud<PointSource> output, Eigen.Matrix4f guess);
    }
}
