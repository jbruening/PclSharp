using PclSharp.Std;

namespace PclSharp
{
    public abstract class PclBase<PointT> : UnmanagedObject
    {
        public abstract void SetInputCloud(PointCloud<PointT> cloud);
        public abstract void SetIndices(VectorOfInt indices);

        public abstract ref PointT this[int idx] { get; }
    }
}
