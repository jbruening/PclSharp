namespace PclSharp.Filters
{
    public abstract class FilterIndices<PointT> : Filter<PointT>
    {
        public abstract bool Negative { get; set; }
        public abstract bool KeepOrganized { get; set; }
    }
}
