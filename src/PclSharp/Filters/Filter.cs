using PclSharp.Std;
using System;
using System.Collections.Generic;

namespace PclSharp.Filters
{
    public abstract class Filter<PointT> : UnmanagedObject
    {
        public abstract void filter(PointCloud<PointT> output);
        public abstract void SetInputCloud(PointCloud<PointT> cloud);
        public abstract VectorOfInt Indices { get; set; }
    }
}
