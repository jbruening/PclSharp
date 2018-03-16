using PclSharp.Eigen;
using System;
using System.Collections.Generic;

namespace PclSharp.SampleConsensus
{
    public enum SACModel
    {
        Plane,
        Line,
        Circle2d,
        Circle3d,
        Sphere,
        Cylinder,
        Cone,
        Torus,
        ParallelLine,
        PerpendicularPlane,
        ParallelLines,
        NormalPlane,
        NormalSphere,
        Registration,
        Registration2d,
        ParallelPlane,
        NormalParallelPlane,
        Stick
    }

    public enum SACMethod
    {
        RANSAC = 0,
        LMEDS = 1,
        MSAC = 2,
        RRANSAC = 3,
        RMSAC = 4,
        MLESAC = 5,
        PROSAC = 6
    }

    public abstract class SampleConsensusModel<PointT> : UnmanagedObject
    {
        public abstract void SetInputCloud(PointCloud<PointT> cloud);
        public abstract void SetIndices(Std.VectorOfInt indices);
        public abstract void GetSamples(int iterations, Std.VectorOfInt samples);
        public abstract bool ComputeModelCoefficients(Std.VectorOfInt samples, VectorXf modelCoefficients);
        public abstract void OptimizeModelCoefficients(Std.VectorOfInt inliers, VectorXf modelCoefficients, VectorXf optimizedCoefficients);
        public abstract void SelectWithinDistance(VectorXf modelCoefficients, double distance, Std.VectorOfInt inliers);
    }
}
