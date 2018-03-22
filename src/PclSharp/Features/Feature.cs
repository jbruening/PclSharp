namespace PclSharp.Features
{
    public abstract class Feature<PointInT, PointOutT> : PclBase<PointInT>
    {
        public abstract int KSearch { get; set; }
        public abstract double RadiusSearch { get; set; }

        public abstract void Compute(PointCloud<PointOutT> cloud);
    }

    public abstract class FeatureFromNormals<PointInT, PointNT, PointOutT> : Feature<PointInT, PointOutT>
    {
        public abstract void SetInputNormals(PointCloud<PointNT> normals);
    }
}
