using PclSharp.Std;
using System;
using System.Collections.Generic;

namespace PclSharp.Filters
{
    public abstract class Filter<PointT> : PclBase<PointT>
    {
        public abstract void filter(PointCloud<PointT> output);
    }
}
