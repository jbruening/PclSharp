using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PclSharp.Registration
{
    public abstract class TransformationEstimation<PointSource, PointTarget> : UnmanagedObject
    {
        public abstract void EstimateRigidTransformation(PointCloud<PointSource> cloudSrc, PointCloud<PointTarget> cloudTgt);
    }
}
