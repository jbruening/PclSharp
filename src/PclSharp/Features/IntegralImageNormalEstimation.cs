using System;
using System.Collections.Generic;
using static PclSharp.Features.IntegralImageNormalEstimation;

namespace PclSharp.Features
{
    public static class IntegralImageNormalEstimation
    {
        public enum BorderPolicy
        {
            Ignore,
            Mirror
        }

        public enum NormalEstimationMethod
        {
            CovarianceMatrix,
            Average3DGradient,
            AverageDepthChange,
            Simple3DGradient
        }
    }

    public abstract class IntegralImageNormalEstimation<PointInT, PointOutT> : Feature<PointInT, PointOutT>
    {
        public abstract void SetRectSize(int width, int height);
        public abstract void SetBorderPolicy(BorderPolicy policy);
        public abstract void SetNormalEstimationMethod(NormalEstimationMethod method);
        public abstract void SetMaxDepthChangeFactor(float factor);
        public abstract void SetNormalSmoothingSize(float size);
    }
}
