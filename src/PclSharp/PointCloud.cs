using PclSharp.Std;
using System;
using System.Collections.Generic;

namespace PclSharp
{
    public abstract class PointCloud<PointT> : UnmanagedObject
    {
        public abstract int Width { get; set; }
        public abstract int Height { get; set; }
        public abstract bool IsDense { get; set; }
        public abstract Vector<PointT> Points { get; }
        public abstract int Count { get; }
        public abstract bool IsOrganized { get; }

        public abstract ref PointT At(int col, int row);
        public abstract void Add(PointT value);
    }

    public static class PointCloudExtensions
    {
        public static unsafe void CopyTo(this PointCloudOfXYZ @this, PointCloudOfXYZL other)
        {
            if (@this.Count != other.Count)
                throw new ArgumentOutOfRangeException(nameof(other), "lengths must match");

            var count = @this.Count;

            var tptr = @this.Data;
            var optr = other.Data;
            for(var i = 0; i < count; i++)
                (optr + i)->V = (tptr + i)->V;
        }

        public static unsafe void CopyTo(this PointCloudOfXYZ @this, PointCloudOfXYZRGBA other)
        {
            if (@this.Count != other.Count)
                throw new ArgumentOutOfRangeException(nameof(other), "lengths must match");

            var count = @this.Count;

            var tptr = @this.Data;
            var optr = other.Data;
            for (var i = 0; i < count; i++)
                (optr + i)->V = (tptr + i)->V;
        }

        public static unsafe void CopyTo(this PointCloudOfXYZRGBA @this, PointCloudOfXYZ other)
        {
            if (@this.Count != other.Count)
                throw new ArgumentOutOfRangeException(nameof(other), "lengths must match");

            var count = @this.Count;

            var tptr = @this.Data;
            var optr = other.Data;
            for (var i = 0; i < count; i++)
                (optr + i)->V = (tptr + i)->V;
        }
    }
}
