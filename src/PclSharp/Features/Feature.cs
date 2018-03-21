namespace PclSharp.Features
{
    public abstract class Feature<PointInT, PointOutT> : PclBase<PointInT>
    {
        public abstract void Compute(PointCloud<PointOutT> cloud);
    }
}
